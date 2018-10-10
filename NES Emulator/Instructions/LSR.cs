namespace NES_Emulator.Instructions
{
    public class LSR_Accumulator : Instruction
    {
        public override byte OpCode { get { return 0x4A; } }
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }

        public override void Operation()
        {
            if ((Nes.CPU.A & 1) == 1) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;

            Nes.CPU.A >>= 1;

            Flags(Nes.CPU.A, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class LSR_ZeroPage : Instruction
    {
        public override byte OpCode { get { return 0x46; } }
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }

        public override void Operation()
        {

            if ((ZeroPage & 1) == 1) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;

            ZeroPage = (byte)(ZeroPage >> 1);

            Flags(ZeroPage, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class LSR_ZeroPageX : Instruction
    {
        public override byte OpCode { get { return 0x56; } }
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }

        public override void Operation()
        {

            if ((ZeroPageX & 1) == 1) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;

            ZeroPageX = (byte)(ZeroPageX >> 1);

            Flags(ZeroPageX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class LSR_Absolute : Instruction
    {
        public override byte OpCode { get { return 0x4E; } }
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 6; } }

        public override void Operation()
        {

            if ((Absolute & 1) == 1) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;

            Absolute = (byte)(Absolute >> 1);

            Flags(Absolute, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class LSR_AbsoluteX : Instruction
    {
        public override byte OpCode { get { return 0x5E; } }
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 7; } }

        public override void Operation()
        {

            if ((AbsoluteX & 1) == 1) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;

            AbsoluteX = (byte)(AbsoluteX >> 1);

            Flags(AbsoluteX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }
}
