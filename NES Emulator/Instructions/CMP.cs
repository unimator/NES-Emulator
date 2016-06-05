using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class CMP : Instruction
    {
        public void Operation_CMP(byte M)
        {
            byte RES = (byte)(nes.cpu.A - M);

            Flags(RES, ProcessorStatus.Zero | ProcessorStatus.Negative);

            if (nes.cpu.A < M) nes.cpu.P &= ~ProcessorStatus.Carry;
            else nes.cpu.P |= ProcessorStatus.Carry;
        }
    }

    public class CMP_Immediate : CMP
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xC9; } }

        public override void Operation()
        {
            Operation_CMP(Immediate);
        }
    }

    public class CMP_ZeroPage : CMP
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0xC5; } }

        public override void Operation()
        {
            Operation_CMP(ZeroPage);
        }
    }

    public class CMP_ZeroPageX : CMP
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xD5; } }

        public override void Operation()
        {
            Operation_CMP(ZeroPageX);
        }
    }

    public class CMP_Absolute : CMP
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xCD; } }

        public override void Operation()
        {
            Operation_CMP(Absolute);
        }
    }

    public class CMP_AbsoluteX : CMP
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xDD; } }

        public override void Operation()
        {
            Operation_CMP(AbsoluteX);
        }
    }

    public class CMP_AbsoluteY : CMP
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xD9; } }

        public override void Operation()
        {
            Operation_CMP(AbsoluteY);
        }
    }

    public class CMP_IndirectX : CMP
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0xC1; } }

        public override void Operation()
        {
            Operation_CMP(IndirectX);
        }
    }

    public class CMP_IndirectY : CMP
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OPCode { get { return 0xD1; } }

        public override void Operation()
        {
            Operation_CMP(IndirectY);
        }
    }
}
