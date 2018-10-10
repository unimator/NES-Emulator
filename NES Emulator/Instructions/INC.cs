namespace NES_Emulator.Instructions
{
    public abstract class INC : Instruction
    {
    }

    public class INC_ZeroPage : INC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OpCode { get { return 0xE6; } }

        public override void Operation()
        {
            ZeroPage = (byte)(ZeroPage + 1);
            Flags(ZeroPage, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class INC_ZeroPageX : INC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0xF6; } }

        public override void Operation()
        {
            ZeroPageX = (byte)(ZeroPageX + 1);
            Flags(ZeroPageX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class INC_Absolute : DEC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0xEE; } }

        public override void Operation()
        {
            Absolute = (byte)(Absolute + 1);
            Flags(Absolute, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class INC_AbsoluteX : DEC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 7; } }
        public override byte OpCode { get { return 0xFE; } }

        public override void Operation()
        {
            AbsoluteX = (byte)(AbsoluteX + 1);
            Flags(AbsoluteX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class INX : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2  ; } }
        public override byte OpCode { get { return 0xE8; } }

        public override void Operation()
        {
            Nes.CPU.X = (byte)(Nes.CPU.X + 1);
            Flags(Nes.CPU.X, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class INY : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xC8; } }

        public override void Operation()
        {
            Nes.CPU.Y = (byte)(Nes.CPU.Y + 1);
            Flags(Nes.CPU.Y, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }
}
