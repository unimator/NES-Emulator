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
        public override byte OpCode { get { return 0xAA; } }

        public override void Operation()
        {
            Nes.CPU.X = Nes.CPU.A;

            Flags(Nes.CPU.X, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TAY : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xA8; } }

        public override void Operation()
        {
            Nes.CPU.Y = Nes.CPU.A;

            Flags(Nes.CPU.Y, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TXA : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x8A; } }

        public override void Operation()
        {
            Nes.CPU.A = Nes.CPU.X;

            Flags(Nes.CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TYA : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x98; } }

        public override void Operation()
        {
            Nes.CPU.A = Nes.CPU.Y;

            Flags(Nes.CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TSX : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xBA; } }

        public override void Operation()
        {
            Nes.CPU.X = Nes.CPU.SP;

            Flags(Nes.CPU.X, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class TXS : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x9A; } }

        public override void Operation()
        {
            Nes.CPU.SP = Nes.CPU.X;

            Flags(Nes.CPU.SP, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }
}
