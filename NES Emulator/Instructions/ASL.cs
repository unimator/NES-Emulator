namespace NES_Emulator.Instructions
{
    public abstract class ASL : Instruction
    {
        protected void Operation_ASL(byte M)
        {

        }

        protected ASL(CPU cpu) : base(cpu)
        {
        }
    }

    public class ASL_Accumulator : ASL
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x0A;

        public override void Execute()
        {
            var result = (byte)(CPU.A << 1);

            if ((CPU.A & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            Flags(result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            CPU.A = result;
        }

        public ASL_Accumulator(CPU cpu) : base(cpu)
        {
        }
    }

    public class ASL_ZeroPage : ASL
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x06;

        public override void Execute()
        {
            var result = (byte)(ZeroPage << 1);

            if ((ZeroPage & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            Flags(result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            ZeroPage = result;
        }

        public ASL_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class ASL_ZeroPageX : ASL
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x16;

        public override void Execute()
        {
            var result = (byte)(ZeroPageX << 1);

            if ((ZeroPageX & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            Flags(result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            ZeroPageX = result;
        }

        public ASL_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ASL_Absolute : ASL
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x0E;

        public override void Execute()
        {
            var result = (byte)(Absolute << 1);

            if ((Absolute & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            Flags(result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            Absolute = result;
        }

        public ASL_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class ASL_AbsoluteX : ASL
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 7;
        public override byte OpCode => 0x1E;

        public override void Execute()
        {
            var result = (byte)(AbsoluteX << 1);

            if ((AbsoluteX & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Carry;
            else CPU.P &= ~ProcessorStatus.Carry;

            Flags(result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            AbsoluteX = result;
        }

        public ASL_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }
}
