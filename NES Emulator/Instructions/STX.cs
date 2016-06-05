using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public class STX_ZeroPage : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0x86; } }

        public override void Operation()
        {
            ZeroPage = nes.cpu.X;
        }
    }

    public class STX_ZeroPageY : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x96; } }

        public override void Operation()
        {
            ZeroPageY = nes.cpu.X;
        }
    }

    public class STX_Absolute : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x8E; } }

        public override void Operation()
        {
            Absolute = nes.cpu.X;
        }
    }
}
