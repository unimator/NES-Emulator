using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NES_Emulator
{
    public class NES
    {
        private static readonly ushort StackOffset = 0x100;

        public Debugger debugger;
        public CPU cpu;
        public PPU ppu;
        public InstructionSet instructionSet = new InstructionSet();

        MainWindow mainWindow;

        public byte[] RAM  = new byte[0x10000];
        public byte[] VRAM = new byte[0x10000];
        

        public NES()
        {
            Instruction.nes = this;
            cpu = new CPU();
            ppu = new PPU();
            debugger = new Debugger();
            Thread t = new Thread(() =>
            {
                mainWindow = new MainWindow(RAM);
                mainWindow.ShowDialog();
            });
            t.Start();
            for(int i = 0; i < 0x10000; ++i)
            {
                RAM[i] = 0x00;
            }
        }

        public void LoadDataToRAM(byte [] source, ushort destination)
        {
            ushort i = 0;
            while(i < source.Length)
            {
                RAM[destination] = source[i];
                ++i;
                ++destination;
            }
        }

        public void MainLoop()
        {
            while (true)
            {
                //Thread.Sleep(1);
                Random random = new Random();
                RAM[0xFE] = (byte)random.Next();

                byte OPCode = RAM[cpu.PC];
                ushort prevPC = cpu.PC;

                Instruction instruction = instructionSet.Instructions[OPCode];
                if (instruction != null) debugger.Debug(cpu, RAM, instruction.GetType().Name);
                else debugger.Debug(cpu, RAM, String.Format("Unknown (0x{0:X})", OPCode));

                if (instruction == null)
                {
                    throw new NullReferenceException("Invalid instruction: " + OPCode + "\nLine: " + String.Format("0x{0:X}", cpu.PC));
                }
                else instruction.Operation();

                if (cpu.PC == prevPC) cpu.PC += instruction.NoBytes;
            }
        }

        public byte Pop()
        {
            return RAM[++cpu.SP + StackOffset];
        }

        public void Push(byte Data)
        {
            RAM[cpu.SP-- + StackOffset] = Data;
        }

        public static byte Higher(ushort Reg)
        {
            return (byte)(Reg >> 8);
        }

        public static byte Lower(ushort Reg)
        {
            return (byte)Reg;
        }
    }
}
