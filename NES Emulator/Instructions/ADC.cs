namespace NES_Emulator.Instructions
{
    public abstract class ADC : Instruction
    {
        protected void Operation_ADC(byte M)
        {
            // A + M + C -> A
            var A = CPU.A;
            var C = (CPU.P & ProcessorStatus.Carry) != 0 ? (byte)1 : (byte)0;
            var result = (ushort)(A + M + C);

            if (result < 0xFF) CPU.P &= ~ProcessorStatus.Carry;
            else CPU.P |= ProcessorStatus.Carry;

            if ((~(A ^ M) & (A ^ result) & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Overflow;
            else CPU.P &= ~ProcessorStatus.Overflow;

            Flags((byte)result, ProcessorStatus.Negative | ProcessorStatus.Zero);

            CPU.A = (byte)result;
        }

        protected ADC(CPU cpu) : base(cpu)
        {
        }
    }

    public class ADC_Immediate : ADC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x69;

        public override void Execute()
        {
            Operation_ADC(Immediate);
        }

        public ADC_Immediate(CPU cpu) : base(cpu)
        {
        }
    }

    public class ADC_ZeroPage : ADC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x65;

        public override void Execute()
        {
            Operation_ADC(ZeroPage);
        }

        public ADC_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class ADC_ZeroPageX : ADC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x75;


        public override void Execute()
        {
            Operation_ADC(ZeroPageX);
        }

        public ADC_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ADC_Absolute : ADC
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x6D;

        public override void Execute()
        {
            Operation_ADC(Absolute);
        }

        public ADC_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class ADC_AbsoluteX : ADC
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x7D;

        public override void Execute()
        {
            Operation_ADC(AbsoluteX);
        }

        public ADC_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ADC_AbsoluteY : ADC
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x79;

        public override void Execute()
        {
            Operation_ADC(AbsoluteY);
        }

        public ADC_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }

    public class ADC_IndirectX : ADC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x61;

        public override void Execute()
        {
            Operation_ADC(IndirectX);
        }

        public ADC_IndirectX(CPU cpu) : base(cpu)
        {
        }
    }

    public class ADC_IndirectY : ADC
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x71;

        public override void Execute()
        {
            Operation_ADC(IndirectY);
        }

        public ADC_IndirectY(CPU cpu) : base(cpu)
        {
        }
    }
}
