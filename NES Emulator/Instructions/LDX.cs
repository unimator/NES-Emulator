namespace NES_Emulator.Instructions
{
    public abstract class LDX : Instruction
    {
        public void Operation_LDX(byte M)
        {
            CPU.X = M;

            Flags(CPU.X, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        protected LDX(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDX_Immediate : LDX
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xA2;

        public override void Execute()
        {
            Operation_LDX(Immediate);
        }

        public LDX_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDX_ZeroPage : LDX
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0xA6;

        public override void Execute()
        {
            Operation_LDX(ZeroPage);
        }

        public LDX_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDX_ZeroPageY : LDX
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xB6;

        public override void Execute()
        {
            Operation_LDX(ZeroPageY);
        }

        public LDX_ZeroPageY(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDX_Absolute : LDX
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xAE;

        public override void Execute()
        {
            Operation_LDX(Absolute);
        }

        public LDX_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDX_AbsoluteY : LDX
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xBE;

        public override void Execute()
        {
            Operation_LDX(AbsoluteY);
        }

        public LDX_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }
}
