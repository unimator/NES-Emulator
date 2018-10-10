namespace NES_Emulator.Instructions
{
    public abstract class LDX : Instruction
    {
        public void Operation_LDX(byte M)
        {
            Nes.CPU.X = M;

            Flags(Nes.CPU.X, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class LDX_Immediate : LDX
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xA2; } }

        public override void Operation()
        {
            Operation_LDX(Immediate);
        }
    }

    public class LDX_ZeroPage : LDX
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OpCode { get { return 0xA6; } }

        public override void Operation()
        {
            Operation_LDX(ZeroPage);
        }
    }

    public class LDX_ZeroPageY : LDX
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0xB6; } }

        public override void Operation()
        {
            Operation_LDX(ZeroPageY);
        }
    }

    public class LDX_Absolute : LDX
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0xAE; } }

        public override void Operation()
        {
            Operation_LDX(Absolute);
        }
    }

    public class LDX_AbsoluteY : LDX
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0xBE; } }

        public override void Operation()
        {
            Operation_LDX(AbsoluteY);
        }
    }
}
