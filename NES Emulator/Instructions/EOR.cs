namespace NES_Emulator.Instructions
{
    public abstract class EOR : Instruction
    {
        public void Operation_EOR(byte M)
        {
            CPU.A = (byte)(CPU.A ^ M);
            Flags(CPU.A, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        protected EOR(CPU cpu) : base(cpu)
        {
        }
    }

    public class EOR_Immediate : EOR
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x49;

        public override void Execute()
        {
            Operation_EOR(Immediate);
        }

        public EOR_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class EOR_ZeroPage : EOR
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x45;

        public override void Execute()
        {
            Operation_EOR(ZeroPage);
        }

        public EOR_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class EOR_ZeroPageX : EOR
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x55;

        public override void Execute()
        {
            Operation_EOR(ZeroPageX);
        }

        public EOR_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class EOR_Absolute : EOR
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x4D;

        public override void Execute()
        {
            Operation_EOR(Absolute);
        }

        public EOR_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class EOR_AbsoluteX : EOR
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x5D;

        public override void Execute()
        {
            Operation_EOR(AbsoluteX);
        }

        public EOR_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class EOR_AbsoluteY : EOR
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x59;

        public override void Execute()
        {
            Operation_EOR(AbsoluteY);
        }

        public EOR_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }

    public class EOR_IndirectX : EOR
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x41;

        public override void Execute()
        {
            Operation_EOR(IndirectX);
        }

        public EOR_IndirectX(CPU cpu) : base(cpu)
        {
        }
    }

    public class EOR_IndirectY : EOR
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x51;

        public override void Execute()
        {
            Operation_EOR(IndirectY);
        }

        public EOR_IndirectY(CPU cpu) : base(cpu)
        {
        }
    }
}
