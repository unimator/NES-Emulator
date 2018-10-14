namespace NES_Emulator.Instructions
{
    class CLC : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x18;

        public override void Execute()
        {
            CPU.P &= ~ProcessorStatus.Carry;
        }

        public CLC(CPU cpu) : base(cpu)
        {
        }
    }

    class CLD : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xD8;

        public override void Execute()
        {
            CPU.P &= ~ProcessorStatus.DecimalMode;
        }

        public CLD(CPU cpu) : base(cpu)
        {
        }
    }

    class CLI : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x58;

        public override void Execute()
        {
            CPU.P &= ~ProcessorStatus.InterruptDisabled;
        }

        public CLI(CPU cpu) : base(cpu)
        {
        }
    }

    class CLV : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xB8;

        public override void Execute()
        {
            CPU.P &= ~ProcessorStatus.Overflow;
        }

        public CLV(CPU cpu) : base(cpu)
        {
        }
    }

    class SEC : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x38;

        public override void Execute()
        {
            CPU.P |= ProcessorStatus.Carry;
        }

        public SEC(CPU cpu) : base(cpu)
        {
        }
    }

    class SED : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xF8;

        public override void Execute()
        {
            CPU.P |= ProcessorStatus.DecimalMode;
        }

        public SED(CPU cpu) : base(cpu)
        {
        }
    }

    class SEI : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x78;

        public override void Execute()
        {
            CPU.P |= ProcessorStatus.InterruptDisabled;
        }

        public SEI(CPU cpu) : base(cpu)
        {
        }
    }
}
