using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class AND : Instruction
    {
        protected void Operation_AND(byte M)
        {
            // A & M -> A
            byte A = Nes.CPU.A;
            byte RES = (byte)(A & M);

            Flags(RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            Nes.CPU.A = RES;
        }
    }

    public class AND_Immediate : AND
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x29; } }

        public override void Operation()
        {
            Operation_AND(Immediate);
        }
    }

    public class AND_ZeroPage : AND
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OpCode { get { return 0x25; } }

        public override void Operation()
        {
            Operation_AND(ZeroPage);
        }
    }

    public class AND_ZeroPageX : AND
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x35; } }

        public override void Operation()
        {
            Operation_AND(ZeroPageX);
        }
    }

    public class AND_Absolute : AND
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x2D; } }

        public override void Operation()
        {
            Operation_AND(Absolute);
        }
    }

    public class AND_AbsoluteX : AND
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x3D; } }

        public override void Operation()
        {
            Operation_AND(AbsoluteX);
        }
    }

    public class AND_AbsoluteY : AND
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x39; } }

        public override void Operation()
        {
            Operation_AND(AbsoluteY);
        }
    }

    public class AND_IndirectX : AND
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x21; } }

        public override void Operation()
        {
            Operation_AND(IndirectX);
        }
    }

    public class AND_IndirectY : AND
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OpCode { get { return 0x31; } }

        public override void Operation()
        {
            Operation_AND(IndirectY);
        }
    }
}
