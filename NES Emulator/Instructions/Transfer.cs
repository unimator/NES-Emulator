using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public class TAX : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xAA; } }

        public override void Operation()
        {
            nes.cpu.X = nes.cpu.A;

            Flags(nes.cpu.X, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TAY : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xA8; } }

        public override void Operation()
        {
            nes.cpu.Y = nes.cpu.A;

            Flags(nes.cpu.Y, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TXA : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0x8A; } }

        public override void Operation()
        {
            nes.cpu.A = nes.cpu.X;

            Flags(nes.cpu.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TYA : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0x98; } }

        public override void Operation()
        {
            nes.cpu.A = nes.cpu.Y;

            Flags(nes.cpu.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TSX : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xBA; } }

        public override void Operation()
        {
            nes.cpu.X = nes.cpu.SP;

            Flags(nes.cpu.X, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TXS : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0x9A; } }

        public override void Operation()
        {
            nes.cpu.SP = nes.cpu.X;

            Flags(nes.cpu.SP, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }
}
