namespace NES_Emulator.Instructions
{
    public class STA_ZeroPage : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OpCode { get { return 0x85; } }

        public override void Operation()
        {
            ZeroPage = Nes.CPU.A;
        }
    }

    public class STA_ZeroPageX : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x95; } }

        public override void Operation()
        {
            ZeroPageX = Nes.CPU.A;
        }
    }

    public class STA_Absolute : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x8D; } }

        public override void Operation()
        {
            Absolute = Nes.CPU.A;
        }
    }

    public class STA_AbsoluteX : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OpCode { get { return 0x9D; } }

        public override void Operation()
        {
            AbsoluteX = Nes.CPU.A;
        }
    }

    public class STA_AbsoluteY : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OpCode { get { return 0x99; } }

        public override void Operation()
        {
            AbsoluteY = Nes.CPU.A;
        }
    }

    public class STA_IndirectX : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x81; } }

        public override void Operation()
        {
            IndirectX = Nes.CPU.A;
        }
    }

    public class STA_IndirectY : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x91; } }

        public override void Operation()
        {
            IndirectY = Nes.CPU.A;
        }
    }
}
