namespace NES_Emulator.Instructions
{
    public class STX_ZeroPage : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x86;

        public override void Execute()
        {
            ZeroPage = CPU.X;
        }

        public STX_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class STX_ZeroPageY : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x96;

        public override void Execute()
        {
            ZeroPageY = CPU.X;
        }

        public STX_ZeroPageY(CPU cpu) : base(cpu)
        {
        }
    }

    public class STX_Absolute : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x8E;

        public override void Execute()
        {
            Absolute = CPU.X;
        }

        public STX_Absolute(CPU cpu) : base(cpu)
        {
        }
    }
}
