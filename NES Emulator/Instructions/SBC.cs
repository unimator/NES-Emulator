namespace NES_Emulator.Instructions
{
    public abstract class SBC : Instruction
    {
        protected void Operation_SBC(byte M)
        {
            //         _
            // A - M - C -> A
            var A = CPU.A;
            var result = (byte)(A - M);

            if (M > A) CPU.P &= ~ProcessorStatus.Carry;
            else CPU.P |= ProcessorStatus.Carry;

            if (((A ^ result) & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Overflow;
            else CPU.P &= ~ProcessorStatus.Overflow;

            Flags(result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            CPU.A = result;
        }

        protected SBC(CPU cpu) : base(cpu)
        {
        }
    }

    public class SBC_Immediate : SBC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xE9;

        public override void Execute()
        {
            Operation_SBC(Immediate);
        }

        public SBC_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class SBC_ZeroPage : SBC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0xE5;

        public override void Execute()
        {
            Operation_SBC(ZeroPage);
        }

        public SBC_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class SBC_ZeroPageX : SBC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xF5;


        public override void Execute()
        {
            Operation_SBC(ZeroPageX);
        }

        public SBC_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class SBC_Absolute : SBC
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xED;

        public override void Execute()
        {
            Operation_SBC(Absolute);
        }

        public SBC_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class SBC_AbsoluteX : SBC
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xFD;

        public override void Execute()
        {
            Operation_SBC(AbsoluteX);
        }

        public SBC_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class SBC_AbsoluteY : SBC
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0xF9;

        public override void Execute()
        {
            Operation_SBC(AbsoluteY);
        }

        public SBC_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }

    public class SBC_IndirectX : SBC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0xE1;

        public override void Execute()
        {
            Operation_SBC(IndirectX);
        }

        public SBC_IndirectX(CPU cpu) : base(cpu)
        {
        }
    }

    public class SBC_IndirectY : SBC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0xF1;

        public override void Execute()
        {
            Operation_SBC(IndirectY);
        }

        public SBC_IndirectY(CPU cpu) : base(cpu)
        {
        }
    }
}
