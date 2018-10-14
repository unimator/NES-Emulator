namespace NES_Emulator.Instructions
{
    public abstract class AND : Instruction
    {
        protected void Operation_AND(byte M)
        {
            // A & M -> A
            var A = CPU.A;
            var result = (byte)(A & M);

            Flags(result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            CPU.A = result;
        }

        protected AND(CPU cpu) : base(cpu)
        {
        }
    }

    public class AND_Immediate : AND
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x29;

        public override void Execute()
        {
            Operation_AND(Immediate);
        }

        public AND_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class AND_ZeroPage : AND
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x25;

        public override void Execute()
        {
            Operation_AND(ZeroPage);
        }

        public AND_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class AND_ZeroPageX : AND
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x35;

        public override void Execute()
        {
            Operation_AND(ZeroPageX);
        }

        public AND_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class AND_Absolute : AND
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x2D;

        public override void Execute()
        {
            Operation_AND(Absolute);
        }

        public AND_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class AND_AbsoluteX : AND
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x3D;

        public override void Execute()
        {
            Operation_AND(AbsoluteX);
        }

        public AND_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class AND_AbsoluteY : AND
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x39;

        public override void Execute()
        {
            Operation_AND(AbsoluteY);
        }

        public AND_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }

    public class AND_IndirectX : AND
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x21;

        public override void Execute()
        {
            Operation_AND(IndirectX);
        }

        public AND_IndirectX(CPU cpu) : base(cpu)
        {
        }
    }

    public class AND_IndirectY : AND
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x31;

        public override void Execute()
        {
            Operation_AND(IndirectY);
        }

        public AND_IndirectY(CPU cpu) : base(cpu)
        {
        }
    }
}
