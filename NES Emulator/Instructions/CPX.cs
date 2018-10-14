namespace NES_Emulator.Instructions
{
    public abstract class CPX : Instruction
    {
        public void Operation_CPX(byte M)
        {
            var result = (byte)(CPU.X - M);

            Flags(result, ProcessorStatus.Zero | ProcessorStatus.Negative);

            if (CPU.X < M) CPU.P &= ~ProcessorStatus.Carry;
            else CPU.P |= ProcessorStatus.Carry;
        }

        protected CPX(CPU cpu) : base(cpu)
        {
        }
    }

    public class CPX_Immediate : CPX
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xE0;

        public override void Execute()
        {
            Operation_CPX(Immediate);
        }

        public CPX_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class CPX_ZeroPage : CPX
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0xE4;

        public override void Execute()
        {
            Operation_CPX(ZeroPage);
        }

        public CPX_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class CPX_Absolute : CPX
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xEC;

        public override void Execute()
        {
            Operation_CPX(Absolute);
        }

        public CPX_Absolute(CPU cpu) : base(cpu)
        {
        }
    }
}
