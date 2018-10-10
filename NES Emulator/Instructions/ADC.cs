namespace NES_Emulator.Instructions
{
    public abstract class ADC : Instruction
    {
        protected void Operation_ADC(byte M)
        {
            // A + M + C -> A
            byte A = Nes.CPU.A;
            byte C = (Nes.CPU.P & ProcessorStatus.Carry) != 0 ? (byte)1 : (byte)0;
            ushort RES = (ushort)(A + M + C);

            if (RES < 0xFF) Nes.CPU.P &= ~ProcessorStatus.Carry;
            else Nes.CPU.P |= ProcessorStatus.Carry;

            if ((~(A ^ M) & (A ^ RES) & (1 << 7)) != 0) Nes.CPU.P |= ProcessorStatus.Overflow;
            else Nes.CPU.P &= ~ProcessorStatus.Overflow;

            Flags((byte)RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            Nes.CPU.A = (byte)RES;
        }
    }

    public class ADC_Immediate : ADC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x69; } }

        public override void Operation()
        {
            Operation_ADC(Immediate);
        }
    }

    public class ADC_ZeroPage : ADC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OpCode { get { return 0x65; } }

        public override void Operation()
        {
            Operation_ADC(ZeroPage);
        }
    }

    public class ADC_ZeroPageX : ADC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x75; } }


        public override void Operation()
        {
            Operation_ADC(ZeroPageX);
        }
    }

    public class ADC_Absolute : ADC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x6D; } }

        public override void Operation()
        {
            Operation_ADC(Absolute);
        }
    }

    public class ADC_AbsoluteX : ADC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x7D; } }

        public override void Operation()
        {
            Operation_ADC(AbsoluteX);
        }
    }

    public class ADC_AbsoluteY : ADC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OpCode { get { return 0x79; } }

        public override void Operation()
        {
            Operation_ADC(AbsoluteY);
        }
    }

    public class ADC_IndirectX : ADC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x61; } }

        public override void Operation()
        {
            Operation_ADC(IndirectX);
        }
    }

    public class ADC_IndirectY : ADC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OpCode { get { return 0x71; } }

        public override void Operation()
        {
            Operation_ADC(IndirectY);
        }
    }
}
