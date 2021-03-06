﻿namespace NES_Emulator.Instructions
{

    public class INC_ZeroPage : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 5;
        public override byte OpCode => 0xE6;

        public override void Execute()
        {
            ZeroPage = (byte)(ZeroPage + 1);
            Flags(ZeroPage, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public INC_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class INC_ZeroPageX : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0xF6;

        public override void Execute()
        {
            ZeroPageX = (byte)(ZeroPageX + 1);
            Flags(ZeroPageX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public INC_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class INC_Absolute : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 6;
        public override byte OpCode => 0xEE;

        public override void Execute()
        {
            Absolute = (byte)(Absolute + 1);
            Flags(Absolute, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public INC_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class INC_AbsoluteX : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 7;
        public override byte OpCode => 0xFE;

        public override void Execute()
        {
            AbsoluteX = (byte)(AbsoluteX + 1);
            Flags(AbsoluteX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public INC_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class INX : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xE8;

        public override void Execute()
        {
            CPU.X = (byte)(CPU.X + 1);
            Flags(CPU.X, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public INX(CPU cpu) : base(cpu)
        {
        }
    }

    public class INY : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xC8;

        public override void Execute()
        {
            CPU.Y = (byte)(CPU.Y + 1);
            Flags(CPU.Y, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }

        public INY(CPU cpu) : base(cpu)
        {
        }
    }
}
