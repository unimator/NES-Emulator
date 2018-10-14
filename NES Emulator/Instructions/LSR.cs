namespace NES_Emulator.Instructions
{
    public class LSR_Accumulator : Instruction
    {
        public override byte OpCode => 0x4A;
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;

        public override void Execute()
        {
            if ((CPU.A & 1) == 1) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            CPU.A >>= 1;

            Flags(CPU.A, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public LSR_Accumulator(CPU cpu) : base(cpu)
        {
        }
    }

    public class LSR_ZeroPage : Instruction
    {
        public override byte OpCode => 0x46;
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;

        public override void Execute()
        {

            if ((ZeroPage & 1) == 1) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            ZeroPage = (byte)(ZeroPage >> 1);

            Flags(ZeroPage, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public LSR_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class LSR_ZeroPageX : Instruction
    {
        public override byte OpCode => 0x56;
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;

        public override void Execute()
        {

            if ((ZeroPageX & 1) == 1) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            ZeroPageX = (byte)(ZeroPageX >> 1);

            Flags(ZeroPageX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public LSR_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class LSR_Absolute : Instruction
    {
        public override byte OpCode => 0x4E;
        public override byte NoBytes => 3;
        public override byte NoCycles => 6;

        public override void Execute()
        {

            if ((Absolute & 1) == 1) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            Absolute = (byte)(Absolute >> 1);

            Flags(Absolute, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public LSR_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class LSR_AbsoluteX : Instruction
    {
        public override byte OpCode => 0x5E;
        public override byte NoBytes => 3;
        public override byte NoCycles => 7;

        public override void Execute()
        {

            if ((AbsoluteX & 1) == 1) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            AbsoluteX = (byte)(AbsoluteX >> 1);

            Flags(AbsoluteX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public LSR_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }
}
