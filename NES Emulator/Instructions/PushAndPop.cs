namespace NES_Emulator.Instructions
{
    public class PHA : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x48;

        public override void Execute()
        {
            CPU.Push(CPU.A);
        }

        public PHA(CPU cpu) : base(cpu)
        {
        }
    }

    public class PHP : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x08;

        public override void Execute()
        {
            CPU.Push((byte)CPU.P);
        }

        public PHP(CPU cpu) : base(cpu)
        {
        }
    }

    public class PLA : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x68;

        public override void Execute()
        {
            CPU.A = CPU.Pop();
            Flags(CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }

        public PLA(CPU cpu) : base(cpu)
        {
        }
    }

    public class PLP : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x28;

        public override void Execute()
        {
            CPU.P = (ProcessorStatus)CPU.Pop();
        }

        public PLP(CPU cpu) : base(cpu)
        {
        }
    }
}
