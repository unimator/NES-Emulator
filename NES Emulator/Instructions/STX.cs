namespace NES_Emulator.Instructions
{
    public class STX_ZeroPage : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OpCode { get { return 0x86; } }

        public override void Operation()
        {
            ZeroPage = Nes.CPU.X;
        }
    }

    public class STX_ZeroPageY : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x96; } }

        public override void Operation()
        {
            ZeroPageY = Nes.CPU.X;
        }
    }

    public class STX_Absolute : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x8E; } }

        public override void Operation()
        {
            Absolute = Nes.CPU.X;
        }
    }
}
