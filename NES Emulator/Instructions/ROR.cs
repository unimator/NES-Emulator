namespace NES_Emulator.Instructions
{
    public class ROR_Accumulator : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x6A;

        public override void Execute()
        {
            var b0 = (CPU.A & 1) != 0;

            CPU.A >>= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) CPU.A += 1 << 7;

            if (b0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROR_Accumulator(CPU cpu) : base(cpu)
        {
        }
    }

    public class ROR_ZeroPage : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x66;

        public override void Execute()
        {
            var b0 = (ZeroPage & 1) != 0;

            ZeroPage >>= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) ZeroPage += (1 << 7);

            if (b0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(ZeroPage, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROR_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class ROR_ZeroPageX : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x76;

        public override void Execute()
        {
            var b0 = (ZeroPageX & 1) != 0;

            ZeroPageX >>= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) ZeroPageX += 1 << 7;

            if (b0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(ZeroPageX, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROR_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ROR_Absolute : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x6E;

        public override void Execute()
        {
            var b0 = (Absolute & 1) != 0;

            Absolute >>= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) Absolute += 1 << 7;

            if (b0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(Absolute, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROR_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class ROR_AbsoluteX : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 7;
        public override byte OpCode => 0x7E;

        public override void Execute()
        {
            var b0 = (AbsoluteX & 1) != 0;

            AbsoluteX >>= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) AbsoluteX += 1 << 7;

            if (b0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(AbsoluteX, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROR_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }
}
