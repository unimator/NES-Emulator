namespace NES_Emulator.Instructions
{
    public class DEC_ZeroPage : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0xC6;

        public override void Execute()
        {
            ZeroPage = (byte)(ZeroPage - 1);
            Flags(ZeroPage, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public DEC_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class DEC_ZeroPageX : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0xD6;

        public override void Execute()
        {
            ZeroPageX = (byte)(ZeroPageX - 1);
            Flags(ZeroPageX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public DEC_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class DEC_Absolute : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 6;
        public override byte OpCode => 0xCE;

        public override void Execute()
        {
            Absolute = (byte)(Absolute - 1);
            Flags(Absolute, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public DEC_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class DEC_AbsoluteX : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 7;
        public override byte OpCode => 0xDE;

        public override void Execute()
        {
            AbsoluteX = (byte)(AbsoluteX - 1);
            Flags(AbsoluteX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public DEC_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class DEX : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xCA;

        public override void Execute()
        {
            CPU.X = (byte)(CPU.X - 1);
            Flags(CPU.X, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public DEX(CPU cpu) : base(cpu)
        {
        }
    }

    public class DEY : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x88;

        public override void Execute()
        {
            CPU.Y = (byte)(CPU.Y - 1);
            Flags(CPU.Y, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public DEY(CPU cpu) : base(cpu)
        {
        }
    }
}
