namespace NES_Emulator.Instructions
{
    class BCC : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x90;

        public override void Execute()
        {
            if ((CPU.P & ProcessorStatus.Carry) == 0)
            {
                var offset = Immediate;
                if (offset < 0x80) CPU.PC = (ushort)(CPU.PC + offset + 2);
                else CPU.PC = (ushort)(CPU.PC + offset - 0xFF + 1);
            }
        }

        public BCC(CPU cpu) : base(cpu)
        {
        }
    }

    class BCS : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xB0;

        public override void Execute()
        {
            if ((CPU.P & ProcessorStatus.Carry) != 0)
            {
                var offset = Immediate;
                if (offset < 0x80) CPU.PC = (ushort)(CPU.PC + offset + 2);
                else CPU.PC = (ushort)(CPU.PC + offset - 0xFF + 1);
            }
        }

        public BCS(CPU cpu) : base(cpu)
        {
        }
    }

    class BEQ : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xF0;

        public override void Execute()
        {
            if ((CPU.P & ProcessorStatus.Zero) != 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) CPU.PC = (ushort)(CPU.PC + offset + 2);
                else CPU.PC = (ushort)(CPU.PC + offset - 0xFF + 1);
            }
        }

        public BEQ(CPU cpu) : base(cpu)
        {
        }
    }

    class BMI : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x30;

        public override void Execute()
        {
            byte offset = Immediate;
            if ((CPU.P & ProcessorStatus.Negative) != 0)
            {
                if (offset < 0x80) CPU.PC = (ushort)(CPU.PC + offset + 2);
                else CPU.PC = (ushort)(CPU.PC + offset - 0xFF + 1);
            }
        }

        public BMI(CPU cpu) : base(cpu)
        {
        }
    }

    class BNE : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xD0;

        public override void Execute()
        {
            if ((CPU.P & ProcessorStatus.Zero) == 0)
            {
                var offset = Immediate;
                if (offset < 0x80) CPU.PC = (ushort)(CPU.PC + offset + 2);
                else CPU.PC = (ushort)(CPU.PC + offset - 0xFF + 1);
            }
        }

        public BNE(CPU cpu) : base(cpu)
        {
        }
    }

    class BPL : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x10;

        public override void Execute()
        {
            if ((CPU.P & ProcessorStatus.Negative) == 0)
            {
                var offset = Immediate;
                if (offset < 0x80) CPU.PC = (ushort)(CPU.PC + offset + 2);
                else CPU.PC = (ushort)(CPU.PC + offset - 0xFF + 1);
            }
        }

        public BPL(CPU cpu) : base(cpu)
        {
        }
    }

    class BVC : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x50;

        public override void Execute()
        {
            if ((CPU.P & ProcessorStatus.Overflow) == 0)
            {
                var offset = Immediate;
                if (offset < 0x80) CPU.PC = (ushort)(CPU.PC + offset + 2);
                else CPU.PC = (ushort)(CPU.PC + offset - 0xFF + 1);
            }
        }

        public BVC(CPU cpu) : base(cpu)
        {
        }
    }

    class BVS : Instruction
    {
        public override byte NoBytes => 2;
        public override byte NoCycles => 2;
        public override byte OpCode => 0x70;

        public override void Execute()
        {
            if ((CPU.P & ProcessorStatus.Overflow) != 0)
            {
                var offset = Immediate;
                if (offset < 0x80) CPU.PC = (ushort)(CPU.PC + offset + 2);
                else CPU.PC = (ushort)(CPU.PC + offset - 0xFF + 1);
            }
        }

        public BVS(CPU cpu) : base(cpu)
        {
        }
    }

}
