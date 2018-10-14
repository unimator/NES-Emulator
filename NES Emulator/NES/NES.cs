using System;
using System.Diagnostics;
using System.Threading;
using NESEmulator;
using NESEmulator.NES;
using NES_Emulator.Instructions;
using NES_Emulator.Memory;
using InstructionSet = NES_Emulator.Instructions.InstructionSet;

namespace NES_Emulator.NES
{
    public delegate void NesNewLoopBeginningEventHandler(object sender, NESEventArgs e);
    public delegate void NesErrorOccurredEventHandler(object sender, NESEventArgs e);
    public delegate void NesInstructionFetchedEventHandler(object sender, NESEventArgs e);
    public delegate void NesInstructionExecutedEventHandler(object sender, NESEventArgs e);

    public class NES
    {
        private readonly NesROM _nesRom;
        

        public Debugger Debugger;
        public CPU CPU;
        public PPU PPU;
        public InstructionSet InstructionSet;
        
        public event NesNewLoopBeginningEventHandler LoopBeginning;
        public event NesErrorOccurredEventHandler ErrorOccurred;
        public event NesInstructionFetchedEventHandler InstructionFetched;
        public event NesInstructionExecutedEventHandler InstructionExecuted;

        public AutoResetEvent Execution;

        public NES(NesROM nesRom)
        {
            _nesRom = nesRom;
            CPU = new CPU();
            InstructionSet = new InstructionSet(CPU);
            CPU.Reset();
            PPU = new PPU(CPU);

            var mainWindowThread = new Thread(() =>
            {
                var mainWindow = new MainWindow(CPU.Memory);
                mainWindow.ShowDialog();
            });
            mainWindowThread.Start();

            var debuggerThread = new Thread(() =>
            {
                Debugger = new Debugger(this);
                Debugger.Run();
            });
            debuggerThread.Start();

            LoadDataToMemory(CPU.Memory, _nesRom.PRGROM, 0x8000);
            if (_nesRom.PRGROMSize == 0x4000)
            {
                LoadDataToMemory(CPU.Memory, _nesRom.PRGROM, 0xC000);
            }

            Execution = new AutoResetEvent(false);
        }
        
        public void LoadDataToMemory(CPUMemory memory, byte [] source, ushort destination)
        {
            Array.Copy(source, 0, memory.Memory, destination, source.Length);
        }

        public void MainLoop()
        {
            var random = new Random();
            var adjustmentWatch = new Stopwatch();
            var adjustmentFrequency = 100000;
            var opsSinceLastAdjustment = 0;

            adjustmentWatch.Start();

            while (true)
            {
                CPU.Memory[0xFE] = (byte)random.Next(); 
                var opCode = CPU.Memory[CPU.PC];

                OnLoopBeginning(new NESEventArgs { OpCode = opCode });

                var instruction = InstructionSet.InstructionsArray[opCode];
                
                OnInstructionFetched(new NESEventArgs());
                
                if (instruction == null)
                {
                    OnErrorOccured(new NESEventArgs { OpCode = opCode });
                }
                else
                {
                    CPU.PC += instruction.NoBytes;
                    instruction.Execute();
                }
                
                OnInstructionExecuted(new NESEventArgs());

                /*opsSinceLastAdjustment++;
                if (opsSinceLastAdjustment == adjustmentFrequency)
                {
                    adjustmentWatch.Stop();
                    var currentFrequency = (double)adjustmentFrequency / (adjustmentWatch.ElapsedMilliseconds * 1000);
                    Console.WriteLine($"{currentFrequency} MHz");

                    opsSinceLastAdjustment = 0;
                    adjustmentWatch.Reset();
                    adjustmentWatch.Start();
                }*/

                // 1.79MHz, estFreq => estFreq / 1.79MHz 
                // 1 / 1.79MHz * n_of_cycles
                // 1790000 cycles / s
                // 1 op => 1 / 1790000
            }
        }

        public static byte Higher(ushort reg)
        {
            return (byte)(reg >> 8);
        }

        public static byte Lower(ushort reg)
        {
            return (byte)reg;
        }

        protected virtual void OnLoopBeginning(NESEventArgs e)
        {
            if (LoopBeginning != null)
            {
                LoopBeginning.Invoke(this, e);
                Execution.WaitOne();
            }
        }

        protected virtual void OnErrorOccured(NESEventArgs e)
        {
            if (ErrorOccurred != null)
            {
                ErrorOccurred.Invoke(this, e);
                Execution.WaitOne();
            }
        }

        protected virtual void OnInstructionFetched(NESEventArgs e)
        {
            if (InstructionFetched != null)
            {
                InstructionFetched.Invoke(this, e);
                Execution.WaitOne();
            }
        }

        protected virtual void OnInstructionExecuted(NESEventArgs e)
        {
            if (InstructionExecuted != null)
            {
                InstructionExecuted.Invoke(this, e);
                Execution.WaitOne();
            }
        }
    }
}
