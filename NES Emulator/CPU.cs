using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator
{

    public class CPU
    {
        //Registers
        public ushort PC { get; set; }
        public byte SP { get; set; }
        public byte A { get; set; }
        public byte X { get; set; }
        public byte Y { get; set; }
        public ProcessorStatus P { get; set; }

        public CPU()
        {
            PC = 0x600;
            SP = 0xFF;
            A = 0;
            X = 0;
            Y = 0;
            P = ProcessorStatus.None;
        }

        public void PrintRegs()
        {
            StringBuilder sbP = new StringBuilder();
            if ((P & ProcessorStatus.Negative) != 0) sbP.Append("N");
            else sbP.Append("n");
            if ((P & ProcessorStatus.Overflow) != 0) sbP.Append("V");
            else sbP.Append("v");
            sbP.Append("-");
            if ((P & ProcessorStatus.Break_Command) != 0) sbP.Append("B");
            else sbP.Append("b");
            if ((P & ProcessorStatus.Decimal_Mode) != 0) sbP.Append("D");
            else sbP.Append("d");
            if ((P & ProcessorStatus.Interrupt_Disable) != 0) sbP.Append("I");
            else sbP.Append("i");
            if ((P & ProcessorStatus.Zero) != 0) sbP.Append("Z");
            else sbP.Append("z");
            if ((P & ProcessorStatus.Carry) != 0) sbP.Append("C");
            else sbP.Append("c");

            Console.WriteLine("#---REGS---#");
            Console.WriteLine("# A  = {0} #", A.ToString("X").PadLeft(4));
            Console.WriteLine("# X  = {0} #", X.ToString("X").PadLeft(4));
            Console.WriteLine("# Y  = {0} #", Y.ToString("X").PadLeft(4));
            Console.WriteLine("# PC = {0} #", PC.ToString("X").PadLeft(4));
            Console.WriteLine("# SP = {0} #", SP.ToString("X").PadLeft(4));
            Console.WriteLine("# P  = {0}", sbP.ToString().PadLeft(8));
            Console.WriteLine("#----------#");
        }
    }

    [Flags]
    public enum ProcessorStatus
    {
        None = 0x0,
        Carry = 0x1,
        Zero = 0x2,
        Interrupt_Disable = 0x4,
        Decimal_Mode = 0x8,
        Break_Command = 0x10,
        Reserved = 0x20,
        Overflow = 0x40,
        Negative = 0x80
    }
}
