using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class ORA : Instruction
    {
        protected void Operation_ORA(byte M)
        {
            // A | M -> A
            byte A = nes.cpu.A;
            byte RES = (byte)(A | M);

            Flags(RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            nes.cpu.A = RES;
        }
    }

    public class ORA_Immediate : ORA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0x09; } }

        public override void Operation()
        {
            Operation_ORA(Immediate);
        }
    }

    public class ORA_ZeroPage : ORA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0x05; } }

        public override void Operation()
        {
            Operation_ORA(ZeroPage);
        }
    }

    public class ORA_ZeroPageX : ORA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x15; } }

        public override void Operation()
        {
            Operation_ORA(ZeroPageX);
        }
    }

    public class ORA_Absolute : ORA
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x0D; } }

        public override void Operation()
        {
            Operation_ORA(Absolute);
        }
    }

    public class ORA_AbsoluteX : ORA
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x1D; } }

        public override void Operation()
        {
            Operation_ORA(AbsoluteX);
        }
    }

    public class ORA_AbsoluteY : ORA
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x19; } }

        public override void Operation()
        {
            Operation_ORA(AbsoluteY);
        }
    }

    public class ORA_IndirectX : ORA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x01; } }

        public override void Operation()
        {
            Operation_ORA(IndirectX);
        }
    }

    public class ORA_IndirectY : ORA
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OPCode { get { return 0x11; } }

        public override void Operation()
        {
            Operation_ORA(IndirectY);
        }
    }
}
