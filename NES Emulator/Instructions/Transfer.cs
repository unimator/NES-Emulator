namespace NES_Emulator.Instructions
{
    public class TAX : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xAA;

        public override void Execute()
        {
            CPU.X = CPU.A;

            Flags(CPU.X, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public TAX(CPU cpu) : base(cpu)
        {
        }
    }

    public class TAY : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xA8;

        public override void Execute()
        {
            CPU.Y = CPU.A;

            Flags(CPU.Y, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public TAY(CPU cpu) : base(cpu)
        {
        }
    }

    public class TXA : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x8A;

        public override void Execute()
        {
            CPU.A = CPU.X;

            Flags(CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public TXA(CPU cpu) : base(cpu)
        {
        }
    }

    public class TYA : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x98;

        public override void Execute()
        {
            CPU.A = CPU.Y;

            Flags(CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public TYA(CPU cpu) : base(cpu)
        {
        }
    }

    public class TSX : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xBA;

        public override void Execute()
        {
            CPU.X = CPU.SP;

            Flags(CPU.X, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public TSX(CPU cpu) : base(cpu)
        {
        }
    }

    public class TXS : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x9A;

        public override void Execute()
        {
            CPU.SP = CPU.X;

            Flags(CPU.SP, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public TXS(CPU cpu) : base(cpu)
        {
        }
    }
}
