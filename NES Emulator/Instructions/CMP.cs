namespace NES_Emulator.Instructions
{
    public abstract class CMP : Instruction
    {
        public void Operation_CMP(byte M)
        {
            var result = (byte)(CPU.A - M);

            Flags(result, ProcessorStatus.Zero | ProcessorStatus.Negative);

            if (CPU.A < M) CPU.P &= ~ProcessorStatus.Carry;
            else CPU.P |= ProcessorStatus.Carry;
        }

        protected CMP(CPU cpu) : base(cpu)
        {
        }
    }

    public class CMP_Immediate : CMP
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xC9;

        public override void Execute()
        {
            Operation_CMP(Immediate);
        }

        public CMP_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class CMP_ZeroPage : CMP
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0xC5;

        public override void Execute()
        {
            Operation_CMP(ZeroPage);
        }

        public CMP_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class CMP_ZeroPageX : CMP
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xD5;

        public override void Execute()
        {
            Operation_CMP(ZeroPageX);
        }

        public CMP_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class CMP_Absolute : CMP
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xCD;

        public override void Execute()
        {
            Operation_CMP(Absolute);
        }

        public CMP_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class CMP_AbsoluteX : CMP
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xDD;

        public override void Execute()
        {
            Operation_CMP(AbsoluteX);
        }

        public CMP_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class CMP_AbsoluteY : CMP
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xD9;

        public override void Execute()
        {
            Operation_CMP(AbsoluteY);
        }

        public CMP_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }

    public class CMP_IndirectX : CMP
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0xC1;

        public override void Execute()
        {
            Operation_CMP(IndirectX);
        }

        public CMP_IndirectX(CPU cpu) : base(cpu)
        {
        }
    }

    public class CMP_IndirectY : CMP
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0xD1;

        public override void Execute()
        {
            Operation_CMP(IndirectY);
        }

        public CMP_IndirectY(CPU cpu) : base(cpu)
        {
        }
    }
}
