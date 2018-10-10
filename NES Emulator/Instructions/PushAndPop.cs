namespace NES_Emulator.Instructions
{
    public class PHA : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OpCode { get { return 0x48; } }

        public override void Operation()
        {
            Nes.Push(Nes.CPU.A);
        }
    }

    public class PHP : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OpCode { get { return 0x08; } }

        public override void Operation()
        {
            Nes.Push((byte)Nes.CPU.P);
        }
    }

    public class PLA : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x68; } }

        public override void Operation()
        {
            Nes.CPU.A = Nes.Pop();
            Flags(Nes.CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class PLP : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x28; } }

        public override void Operation()
        {
            Nes.CPU.P = (ProcessorStatus)Nes.Pop();
        }
    }
}
