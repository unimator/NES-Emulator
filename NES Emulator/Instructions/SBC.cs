using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class SBC : Instruction
    {
        protected void Operation_SBC(byte M)
        {
            //         _
            // A - M - C -> A
            byte A = nes.cpu.A;
            byte RES = (byte)(A - M);

            if (M > A) nes.cpu.P &= ~ProcessorStatus.Carry;
            else nes.cpu.P |= ProcessorStatus.Carry;

            if (((A ^ RES) & (1 << 7)) != 0) nes.cpu.P |= ProcessorStatus.Overflow;
            else nes.cpu.P &= ~ProcessorStatus.Overflow;

            Flags(RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            nes.cpu.A = RES;
        }
    }

    public class SBC_Immediate : SBC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xE9; } }

        public override void Operation()
        {
            Operation_SBC(Immediate);
        }
    }

    public class SBC_ZeroPage : SBC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0xE5; } }

        public override void Operation()
        {
            Operation_SBC(ZeroPage);
        }
    }

    public class SBC_ZeroPageX : SBC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xF5; } }


        public override void Operation()
        {
            Operation_SBC(ZeroPageX);
        }
    }

    public class SBC_Absolute : SBC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xED; } }

        public override void Operation()
        {
            Operation_SBC(Absolute);
        }
    }

    public class SBC_AbsoluteX : SBC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xFD; } }

        public override void Operation()
        {
            Operation_SBC(AbsoluteX);
        }
    }

    public class SBC_AbsoluteY : SBC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xF9; } }

        public override void Operation()
        {
            Operation_SBC(AbsoluteY);
        }
    }

    public class SBC_IndirectX : SBC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0xE1; } }

        public override void Operation()
        {
            Operation_SBC(IndirectX);
        }
    }

    public class SBC_IndirectY : SBC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OPCode { get { return 0xF1; } }

        public override void Operation()
        {
            Operation_SBC(IndirectY);
        }
    }
}
