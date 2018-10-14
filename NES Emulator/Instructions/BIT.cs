namespace NES_Emulator.Instructions
{
    public abstract class BIT : Instruction
    {
        public void Operation_BIT(byte M)
        {
            var result = (byte)(CPU.A & M);

            if ((M & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Negative;
            else CPU.P &= ~ProcessorStatus.Negative;

            if ((M & (1 << 6)) != 0) CPU.P |= ProcessorStatus.Overflow;
            else CPU.P &= ~ProcessorStatus.Overflow;

            if (result == 0) CPU.P |= ProcessorStatus.Zero;
            else CPU.P &= ~ProcessorStatus.Zero;
            
        }

        protected BIT(CPU cpu) : base(cpu)
        {
        }
    }

    public class BIT_ZeroPage : BIT
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x24;

        public override void Execute()
        {
            Operation_BIT(ZeroPage);
        }

        public BIT_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class BIT_Absolute : BIT
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x2C;

        public override void Execute()
        {
            Operation_BIT(Absolute);
        }

        public BIT_Absolute(CPU cpu) : base(cpu)
        {
        }
    }
}
