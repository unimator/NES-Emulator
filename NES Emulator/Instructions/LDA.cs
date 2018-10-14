namespace NES_Emulator.Instructions
{
    public abstract class LDA : Instruction
    {
        public void Operation_LDA(byte m)
        {
            CPU.A = m;

            Flags(CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        protected LDA(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDA_Immediate : LDA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xA9;

        public override void Execute()
        {
            Operation_LDA(Immediate);
        }

        public LDA_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDA_ZeroPage : LDA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0xA5;

        public override void Execute()
        {
            Operation_LDA(ZeroPage);
        }

        public LDA_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDA_ZeroPageX : LDA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xB5;

        public override void Execute()
        {
            Operation_LDA(ZeroPageX);
        }

        public LDA_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDA_Absolute : LDA
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xAD;

        public override void Execute()
        {
            Operation_LDA(Absolute);
        }

        public LDA_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDA_AbsoluteX : LDA
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xBD;

        public override void Execute()
        {
            Operation_LDA(AbsoluteX);
        }

        public LDA_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDA_AbsoluteY : LDA
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xB9;

        public override void Execute()
        {
            Operation_LDA(AbsoluteY);
        }

        public LDA_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDA_IndirectX : LDA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0xA1;

        public override void Execute()
        {
            Operation_LDA(IndirectX);
        }

        public LDA_IndirectX(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDA_IndirectY : LDA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0xB1;

        public override void Execute()
        {
            Operation_LDA(IndirectY);
        }

        public LDA_IndirectY(CPU cpu) : base(cpu)
        {
        }
    }
}
