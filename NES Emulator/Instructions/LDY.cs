namespace NES_Emulator.Instructions
{
    public abstract class LDY : Instruction
    {
        public void Operation_LDY(byte M)
        {
            CPU.Y = M;

            Flags(CPU.Y, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        protected LDY(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDY_Immediate : LDY
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xA0;

        public override void Execute()
        {
            Operation_LDY(Immediate);
        }

        public LDY_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDY_ZeroPage : LDY
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0xA4;

        public override void Execute()
        {
            Operation_LDY(ZeroPage);
        }

        public LDY_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDY_ZeroPageX : LDY
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xB4;

        public override void Execute()
        {
            Operation_LDY(ZeroPageX);
        }

        public LDY_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDY_Absolute : LDY
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xAC;

        public override void Execute()
        {
            Operation_LDY(Absolute);
        }

        public LDY_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class LDY_AbsoluteX : LDY
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xBC;

        public override void Execute()
        {
            Operation_LDY(AbsoluteX);
        }

        public LDY_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }
}
