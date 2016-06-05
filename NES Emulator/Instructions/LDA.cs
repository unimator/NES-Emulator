using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class LDA : Instruction
    {
        public void Operation_LDA(byte M)
        {
            nes.cpu.A = M;

            Flags(nes.cpu.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class LDA_Immediate : LDA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xA9; } }

        public override void Operation()
        {
            Operation_LDA(Immediate);
        }
    }

    public class LDA_ZeroPage : LDA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0xA5; } }

        public override void Operation()
        {
            Operation_LDA(ZeroPage);
        }
    }

    public class LDA_ZeroPageX : LDA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xB5; } }

        public override void Operation()
        {
            Operation_LDA(ZeroPageX);
        }
    }

    public class LDA_Absolute : LDA
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xAD; } }

        public override void Operation()
        {
            Operation_LDA(Absolute);
        }
    }

    public class LDA_AbsoluteX : LDA
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xBD; } }

        public override void Operation()
        {
            Operation_LDA(AbsoluteX);
        }
    }

    public class LDA_AbsoluteY : LDA
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xB9; } }

        public override void Operation()
        {
            Operation_LDA(AbsoluteY);
        }
    }

    public class LDA_IndirectX : LDA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0xA1; } }

        public override void Operation()
        {
            Operation_LDA(IndirectX);
        }
    }

    public class LDA_IndirectY : LDA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OPCode { get { return 0xB1; } }

        public override void Operation()
        {
            Operation_LDA(IndirectY);
        }
    }
}
