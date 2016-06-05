using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace NES_Emulator
{
    public class Debugger
    {
        private bool DebugMode = true;
        private bool[] BreakPoints;
        private ushort LastBreakpoint;

        public Debugger()
        {
            BreakPoints = new bool[0x1000];
            for(int i = 0; i < 0x1000; ++i)
            {
                BreakPoints[i] = false;
            } 
        }

        public void Debug(CPU cpu, byte [] RAM, String instruction)
        {
            String line = null;
            if (BreakPoints[cpu.PC] == true)
            {
                Console.WriteLine("Break point: 0x{0:X}", cpu.PC);
                DebugMode = true;
            }
            while ("n".Equals(line) == false && DebugMode == true)
            {
                line = Console.ReadLine();

                if (line.Equals("p")) cpu.PrintRegs();
                if (line.Equals("m")) PrintRam(RAM, cpu.PC, 0x20);
                if (line.Equals("q")) PrintRam(RAM, 0x100, 0x100);
                if (line.Equals("i")) Console.WriteLine(instruction);
                if (line.Equals("r")) DebugMode = false;
                if (line.StartsWith("b"))
                {
                    if(line.Length == 1)
                    {
                        Console.WriteLine("Active breakpoints:");
                        for(int i = 0; i < 0x1000; ++i)
                        {
                            if(BreakPoints[i] == true)
                            {
                                Console.Write("0x{0:X}|", i);
                            }
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        char[] delimiters = new char[] { ' ' };
                        String[] args = line.Split(delimiters);
                        ushort breakpoint = ushort.Parse(args[1], NumberStyles.AllowHexSpecifier);
                        BreakPoints[breakpoint] = !BreakPoints[breakpoint];
                    }
                    
                }
            }
        }

        public void PrintRam(byte[] RAM, ushort start, ushort length)
        {
            Console.WriteLine("RAM: 0x{0:X}", start);
            for (int i = 0; i < length; ++i)
            {
                Console.Write("{0:X} ", RAM[start + i]);
            }
            Console.WriteLine();
        }
    }
}
