using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    class CLC : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x18; } }

        public override void Operation()
        {
            Nes.CPU.P &= ~ProcessorStatus.Carry;
        }
    }

    class CLD : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xD8; } }

        public override void Operation()
        {
            Nes.CPU.P &= ~ProcessorStatus.DecimalMode;
        }
    }

    class CLI : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x58; } }

        public override void Operation()
        {
            Nes.CPU.P &= ~ProcessorStatus.InterruptDisable;
        }
    }

    class CLV : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xB8; } }

        public override void Operation()
        {
            Nes.CPU.P &= ~ProcessorStatus.Overflow;
        }
    }

    class SEC : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x38; } }

        public override void Operation()
        {
            Nes.CPU.P |= ProcessorStatus.Carry;
        }
    }

    class SED : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xF8; } }

        public override void Operation()
        {
            Nes.CPU.P |= ProcessorStatus.DecimalMode;
        }
    }

    class SEI : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x78; } }

        public override void Operation()
        {
            Nes.CPU.P |= ProcessorStatus.InterruptDisable;
        }
    }
}
