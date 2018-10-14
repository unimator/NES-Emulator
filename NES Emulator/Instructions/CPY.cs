namespace NES_Emulator.Instructions
{
    public abstract class CPY : Instruction
    {
        public void Operation_CPY(byte M)
        {
            var result = (byte)(CPU.Y - M);

            Flags(result, ProcessorStatus.Zero | ProcessorStatus.Negative);

            if (CPU.Y < M) CPU.P &= ~ProcessorStatus.Carry;
            else CPU.P |= ProcessorStatus.Carry;
        }

        protected CPY(CPU cpu) : base(cpu)
        {
        }
    }

    public class CPY_Immediate : CPY
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xC0;

        public override void Execute()
        {
            Operation_CPY(Immediate);
        }

        public CPY_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class CPY_ZeroPage : CPY
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0xC4;

        public override void Execute()
        {
            Operation_CPY(ZeroPage);
        }

        public CPY_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class CPY_Absolute : CPY
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xCC;

        public override void Execute()
        {
            Operation_CPY(Absolute);
        }

        public CPY_Absolute(CPU cpu) : base(cpu)
        {
        }
    }
}
