namespace NES_Emulator.Instructions
{
    public class STY_ZeroPage : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x84;

        public override void Execute()
        {
            ZeroPage = CPU.Y;
        }

        public STY_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class STY_ZeroPageX : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x94;

        public override void Execute()
        {
            ZeroPageX = CPU.Y;
        }

        public STY_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class STY_Absolute : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x8C;

        public override void Execute()
        {
            Absolute = CPU.Y;
        }

        public STY_Absolute(CPU cpu) : base(cpu)
        {
        }
    }
}
