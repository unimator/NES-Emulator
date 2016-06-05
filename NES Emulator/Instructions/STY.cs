using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public class STY_ZeroPage : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0x84; } }

        public override void Operation()
        {
            ZeroPage = nes.cpu.Y;
        }
    }

    public class STY_ZeroPageX : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x94; } }

        public override void Operation()
        {
            ZeroPageX = nes.cpu.Y;
        }
    }

    public class STY_Absolute : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x8C; } }

        public override void Operation()
        {
            Absolute = nes.cpu.Y;
        }
    }
}
