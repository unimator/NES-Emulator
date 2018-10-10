using System;
using System.Diagnostics;
using System.Threading;
using NES_Emulator.Instructions;
using NES_Emulator.Memory;

namespace NES_Emulator.NES
{
    public delegate void NesNewLoopBeginningEventHandler(object sender, NESEventArgs e);
    public delegate void NesErrorOccurredEventHandler(object sender, NESEventArgs e);
    public delegate void NesInstructionFetchedEventHandler(object sender, NESEventArgs e);
    public delegate void NesInstructionExecutedEventHandler(object sender, NESEventArgs e);

    public class NES
    {
        private static readonly ushort StackOffset = 0x100;

        public Debugger Debugger;
        public CPU CPU;
        public PPU PPU;
        public InstructionSet InstructionSet = new InstructionSet();
        
        public event NesNewLoopBeginningEventHandler LoopBeginning;
        public event NesErrorOccurredEventHandler ErrorOccurred;
        public event NesInstructionFetchedEventHandler InstructionFetched;
        public event NesInstructionExecutedEventHandler InstructionExecuted;

        public AutoResetEvent Execution;

        public NES()
        {
            Instruction.Nes = this;
            CPU = new CPU();
            PPU = new PPU(CPU);

            Thread mainWindowThread = new Thread(() =>
            {
                var mainWindow = new MainWindow(CPU.Memory);
                mainWindow.ShowDialog();
            });
            mainWindowThread.Start();

            Thread debuggerThread = new Thread(() =>
            {
                Debugger = new Debugger(this);
                Debugger.Run();
            });
            debuggerThread.Start();

            Execution = new AutoResetEvent(false);
        }

        protected virtual void OnLoopBeginning(NESEventArgs e)
        {
            if(LoopBeginning != null)
            {
                LoopBeginning.Invoke(this, e);
                Execution.WaitOne();
            }
        }

        protected virtual void OnErrorOccured(NESEventArgs e)
        {
            if(ErrorOccurred != null)
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

        public void LoadDataToMemory(CPUMemory memory, byte [] source, ushort destination)
        {
            Array.Copy(source, 0, memory.Memory, destination, source.Length);
        }

        public void MainLoop()
        {
            Random random = new Random();
            Stopwatch diagnosticWatch = new Stopwatch();
            long counter = 0;
            diagnosticWatch.Start();

            while (true)
            {
                // diagnostics
                if (counter == 0)
                {
                    diagnosticWatch.Stop();
                    //Console.WriteLine($"{1000000.0 / (diagnosticWatch.ElapsedMilliseconds * 1000)} MHz");
                    diagnosticWatch.Reset();
                    diagnosticWatch.Start();
                    counter = 1000000;
                }
                --counter;
                
                //Event: LoopBeginning
                OnLoopBeginning(new NESEventArgs());
                
                CPU.Memory[0xFE] = (byte)random.Next(); 
                
                byte opCode = CPU.Memory[CPU.PC];
                ushort prevPC = CPU.PC; 

                Instruction instruction = InstructionSet.InstructionsArray[opCode];

                //Event: InstructionFetched
                OnInstructionFetched(new NESEventArgs());

                //Optional Event: ErrorOccured
                if (instruction == null) OnErrorOccured(new NESEventArgs { OpCode = opCode });
                else
                {
                    instruction.Operation();
                    if (CPU.PC == prevPC) CPU.PC += instruction.NoBytes;
                }

                //Event: InstructionCompleted
                OnInstructionExecuted(new NESEventArgs());

                // 1.79MHz, estFreq => estFreq / 1.79MHz 
                // 1 / 1.79MHz * n_of_cycles
                // 1790000 cycles / s
                // 1 op => 1 / 1790000
            }
        }

        public byte Pop()
        {
            return CPU.Memory[CPU.SP++ + StackOffset];
        }

        public void Push(byte data)
        {
            CPU.Memory[--CPU.SP + StackOffset] = data;
        }

        public static byte Higher(ushort reg)
        {
            return (byte)(reg >> 8);
        }

        public static byte Lower(ushort reg)
        {
            return (byte)reg;
        }
    }
}
