namespace NES_Emulator.Instructions
{
    public abstract class ORA : Instruction
    {
        protected void Operation_ORA(byte M)
        {
            // A | M -> A
            var A = CPU.A;
            var result = (byte)(A | M);

            Flags(result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            CPU.A = result;
        }

        protected ORA(CPU cpu) : base(cpu)
        {
        }
    }

    public class ORA_Immediate : ORA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x09;

        public override void Execute()
        {
            Operation_ORA(Immediate);
        }

        public ORA_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class ORA_ZeroPage : ORA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x05;

        public override void Execute()
        {
            Operation_ORA(ZeroPage);
        }

        public ORA_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class ORA_ZeroPageX : ORA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x15;

        public override void Execute()
        {
            Operation_ORA(ZeroPageX);
        }

        public ORA_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ORA_Absolute : ORA
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x0D;

        public override void Execute()
        {
            Operation_ORA(Absolute);
        }

        public ORA_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class ORA_AbsoluteX : ORA
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x1D;

        public override void Execute()
        {
            Operation_ORA(AbsoluteX);
        }

        public ORA_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ORA_AbsoluteY : ORA
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x19;

        public override void Execute()
        {
            Operation_ORA(AbsoluteY);
        }

        public ORA_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }

    public class ORA_IndirectX : ORA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x01;

        public override void Execute()
        {
            Operation_ORA(IndirectX);
        }

        public ORA_IndirectX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ORA_IndirectY : ORA
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x11;

        public override void Execute()
        {
            Operation_ORA(IndirectY);
        }

        public ORA_IndirectY(CPU cpu) : base(cpu)
        {
        }
    }
}
