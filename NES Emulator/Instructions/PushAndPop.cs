using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public class PHA : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0x48; } }

        public override void Operation()
        {
            nes.Push(nes.cpu.A);
        }
    }

    public class PHP : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0x08; } }

        public override void Operation()
        {
            nes.Push((byte)nes.cpu.P);
        }
    }

    public class PLA : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x68; } }

        public override void Operation()
        {
            nes.cpu.A = nes.Pop();
            Flags(nes.cpu.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class PLP : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x28; } }

        public override void Operation()
        {
            nes.cpu.P = (ProcessorStatus)nes.Pop();
        }
    }
}
