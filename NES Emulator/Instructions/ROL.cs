namespace NES_Emulator.Instructions
{
    public class ROL_Accumulator : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x2A;

        public override void Execute()
        {
            var b7 = (CPU.A & (1 << 7)) != 0;

            CPU.A <<= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) CPU.A += 1;

            if (b7) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROL_Accumulator(CPU cpu) : base(cpu)
        {
        }
    }

    public class ROL_ZeroPage : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x26;

        public override void Execute()
        {
            var b7 = (ZeroPage & (1 << 7)) != 0;

            ZeroPage <<= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) ZeroPage += 1;

            if (b7) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(ZeroPage, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROL_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class ROL_ZeroPageX : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x36;

        public override void Execute()
        {
            var b7 = (ZeroPageX & (1 << 7)) != 0;

            ZeroPageX <<= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) ZeroPageX += 1;

            if (b7) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(ZeroPageX, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROL_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ROL_Absolute : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x2E;

        public override void Execute()
        {
            var b7 = (Absolute & (1 << 7)) != 0;

            Absolute <<= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) Absolute += 1;

            if (b7) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(Absolute, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROL_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class ROL_AbsoluteX : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 7;
        public override byte OpCode => 0x3E;

        public override void Execute()
        {
            var b7 = (AbsoluteX & (1 << 7)) != 0;

            AbsoluteX <<= 1;
            if ((CPU.P & ProcessorStatus.Carry) != 0) AbsoluteX += 1;

            if (b7) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;
            Flags(AbsoluteX, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public ROL_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }
}
