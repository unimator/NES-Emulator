namespace NES_Emulator.Instructions
{
    public class STA_ZeroPage : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x85;

        public override void Execute()
        {
            ZeroPage = CPU.A;
        }

        public STA_ZeroPage(CPU cpu) : base(cpu)
        {
        }
    }

    public class STA_ZeroPageX : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x95;

        public override void Execute()
        {
            ZeroPageX = CPU.A;
        }

        public STA_ZeroPageX(CPU cpu) : base(cpu)
        {
        }
    }

    public class STA_Absolute : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 4;
        public override byte OpCode => 0x8D;

        public override void Execute()
        {
            Absolute = CPU.A;
        }

        public STA_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class STA_AbsoluteX : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x9D;

        public override void Execute()
        {
            AbsoluteX = CPU.A;
        }

        public STA_AbsoluteX(CPU cpu) : base(cpu)
        {
        }
    }

    public class STA_AbsoluteY : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x99;

        public override void Execute()
        {
            AbsoluteY = CPU.A;
        }

        public STA_AbsoluteY(CPU cpu) : base(cpu)
        {
        }
    }

    public class STA_IndirectX : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x81;

        public override void Execute()
        {
            IndirectX = CPU.A;
        }

        public STA_IndirectX(CPU cpu) : base(cpu)
        {
        }
    }

    public class STA_IndirectY : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x91;

        public override void Execute()
        {
            IndirectY = CPU.A;
        }

        public STA_IndirectY(CPU cpu) : base(cpu)
        {
        }
    }
}
