using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class EOR : Instruction
    {
        public void Operation_EOR(byte M)
        {
            nes.cpu.A = (byte)(nes.cpu.A ^ M);
            Flags(nes.cpu.A, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class EOR_Immediate : EOR
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0x49; } }

        public override void Operation()
        {
            Operation_EOR(Immediate);
        }
    }

    public class EOR_ZeroPage : EOR
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0x45; } }

        public override void Operation()
        {
            Operation_EOR(ZeroPage);
        }
    }

    public class EOR_ZeroPageX : EOR
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x55; } }

        public override void Operation()
        {
            Operation_EOR(ZeroPageX);
        }
    }

    public class EOR_Absolute : EOR
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x4D; } }

        public override void Operation()
        {
            Operation_EOR(Absolute);
        }
    }

    public class EOR_AbsoluteX : EOR
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x5D; } }

        public override void Operation()
        {
            Operation_EOR(AbsoluteX);
        }
    }

    public class EOR_AbsoluteY : EOR
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x59; } }

        public override void Operation()
        {
            Operation_EOR(AbsoluteY);
        }
    }

    public class EOR_IndirectX : EOR
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x41; } }

        public override void Operation()
        {
            Operation_EOR(IndirectX);
        }
    }

    public class EOR_IndirectY : EOR
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OPCode { get { return 0x51; } }

        public override void Operation()
        {
            Operation_EOR(IndirectY);
        }
    }
}
