using System;
using System.Text;
using System.Threading;
using NESEmulator.Memory;
using NESEmulator.NES;

namespace NES_Emulator
{
    public class Debugger
    {
        private bool debugMode = true;
        private bool[] breakPoints;
        private ushort lastBreakpoint;
        private NES.NES nes;

        private AutoResetEvent nesEventOccured;

        public Debugger(NES.NES nes)
        {
            breakPoints = new bool[0x10000];
            for(int i = 0; i < 0x10000; ++i)
            {
                breakPoints[i] = false;
            }

            nesEventOccured = new AutoResetEvent(false);

            this.nes = nes;
            nes.LoopBeginning += Nes_LoopBeginning;
            nes.ErrorOccurred += Nes_ErrorOccurred;
        }

        private void Nes_LoopBeginning(object sender, NESEventArgs e)
        {
            nesEventOccured.Set();
            Debug(nes.CPU, nes.CPU.Memory.Memory, e.Message);
        }

        private void Nes_ErrorOccurred(object sender, NESEventArgs e)
        {
            nesEventOccured.Set();
            Debug(nes.CPU, nes.CPU.Memory.Memory, e.Message);
        }

        public void Run()
        {
            nes.LoopBeginning += Nes_LoopBeginning;
            while (true)
            {
                nesEventOccured.WaitOne();
                nes.LoopBeginning -= Nes_LoopBeginning;

                if (debugMode == false)
                {
                    Console.WriteLine("Debug mode must be on");
                    continue;
                }
                nes.Execution.Set();
            }
        }

        public void Debug(CPU cpu, byte [] RAM, string instruction)
        {
            string line = null;
            if (breakPoints[cpu.PC] == true)
            {
                Console.WriteLine("Break point: 0x{0:X}", cpu.PC);
                debugMode = true;
            }
            while ("n".Equals(line) == false && debugMode == true)
            {
                Console.WriteLine("waiting for input...");
                line = Console.ReadLine();

                if (line.Equals("p")) PrintRegs();
                if (line.StartsWith("m"))
                {
                    // m <beg> <size>
                    string[] lineSplitted = line.Split(' ');
                    if (lineSplitted.Length == 3)
                    {
                        ushort length = MemoryHelper.AddressResolver(lineSplitted[2]);
                        ushort address = MemoryHelper.StringToAddressResolve(cpu, lineSplitted[1]);
                        PrintRAM(RAM, address, length);
                    }
                }
                if (line.Equals("q")) PrintRAM(RAM, 0x100, 0x100);
                if (line.Equals("i")) Console.WriteLine(instruction);
                if (line.Equals("r")) debugMode = false;
                if (line.StartsWith("b"))
                {
                    if(line.Length == 1)
                    {
                        Console.WriteLine("Active breakpoints:");
                        for(int i = 0; i < 0x1000; ++i)
                        {
                            if(breakPoints[i] == true)
                            {
                                Console.Write("0x{0:X}|", i);
                            }
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        char[] delimiters = new char[] { ' ' };
                        string[] args = line.Split(delimiters);
                        ushort breakpoint = MemoryHelper.AddressResolver(args[1]);
                        breakPoints[breakpoint] = !breakPoints[breakpoint];
                    }
                }
            }
            nes.Execution.Set();
        }

        public void PrintRAM(byte[] RAM, ushort start, ushort length)
        {
            Console.WriteLine($"Memory: 0x{start:X}");
            
            for (int i = 0; i < length; ++i)
            {
                if (i % 0x10 == 0)
                {
                    Console.WriteLine();
                    Console.Write($"{start + i:X}".PadLeft(4, '0') + ": ");
                }
                Console.Write($"{RAM[start + i]:X}".PadLeft(2, '0') + ' ');
            }
            Console.WriteLine();
        }

        public void PrintRegs()
        {
            CPU cpu = nes.CPU;
                
            StringBuilder sbP = new StringBuilder();
            if ((cpu.P & ProcessorStatus.Negative) != 0) sbP.Append("N");
            else sbP.Append("n");
            if ((cpu.P & ProcessorStatus.Overflow) != 0) sbP.Append("V");
            else sbP.Append("v");
            sbP.Append("-");
            if ((cpu.P & ProcessorStatus.BreakCommand) != 0) sbP.Append("B");
            else sbP.Append("b");
            if ((cpu.P & ProcessorStatus.DecimalMode) != 0) sbP.Append("D");
            else sbP.Append("d");
            if ((cpu.P & ProcessorStatus.InterruptDisabled) != 0) sbP.Append("I");
            else sbP.Append("i");
            if ((cpu.P & ProcessorStatus.Zero) != 0) sbP.Append("Z");
            else sbP.Append("z");
            if ((cpu.P & ProcessorStatus.Carry) != 0) sbP.Append("C");
            else sbP.Append("c");

            Console.WriteLine("#------REGS------#");
            Console.WriteLine("# A  = {0} #", cpu.A.ToString("X").PadRight(9));
            Console.WriteLine("# X  = {0} #", cpu.X.ToString("X").PadRight(9));
            Console.WriteLine("# Y  = {0} #", cpu.Y.ToString("X").PadRight(9));
            Console.WriteLine("# PC = {0} #", cpu.PC.ToString("X").PadRight(9));
            Console.WriteLine("# SP = {0} #", cpu.SP.ToString("X").PadRight(9));
            Console.WriteLine("# P  = {0} #", sbP.ToString().PadRight(9));
            Console.WriteLine("#----------------#");
        }
    }
}
