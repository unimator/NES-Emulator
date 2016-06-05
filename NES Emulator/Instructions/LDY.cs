using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class LDY : Instruction
    {
        public void Operation_LDY(byte M)
        {
            nes.cpu.Y = M;

            Flags(nes.cpu.Y, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class LDY_Immediate : LDY
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xA0; } }

        public override void Operation()
        {
            Operation_LDY(Immediate);
        }
    }

    public class LDY_ZeroPage : LDY
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0xA4; } }

        public override void Operation()
        {
            Operation_LDY(ZeroPage);
        }
    }

    public class LDY_ZeroPageX : LDY
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xB4; } }

        public override void Operation()
        {
            Operation_LDY(ZeroPageX);
        }
    }

    public class LDY_Absolute : LDY
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xAC; } }

        public override void Operation()
        {
            Operation_LDY(Absolute);
        }
    }

    public class LDY_AbsoluteX : LDY
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xBC; } }

        public override void Operation()
        {
            Operation_LDY(AbsoluteX);
        }
    }
}
