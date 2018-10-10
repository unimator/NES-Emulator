namespace NES_Emulator.Instructions
{
    class BCC : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x90; } }

        public override void Operation()
        {
            if ((Nes.CPU.P & ProcessorStatus.Carry) == 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset + 2);
                else Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset - 0xFF + 1);
            }
        }
    }

    class BCS : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xB0; } }

        public override void Operation()
        {
            if ((Nes.CPU.P & ProcessorStatus.Carry) != 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset + 2);
                else Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset - 0xFF + 1);
            }
        }
    }

    class BEQ : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xF0; } }

        public override void Operation()
        {
            if ((Nes.CPU.P & ProcessorStatus.Zero) != 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset + 2);
                else Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset - 0xFF + 1);
            }
        }
    }

    class BMI : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x30; } }

        public override void Operation()
        {
            if ((Nes.CPU.P & ProcessorStatus.Negative) != 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset + 2);
                else Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset - 0xFF + 1);
            }
        }
    }

    class BNE : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xD0; } }

        public override void Operation()
        {
            if ((Nes.CPU.P & ProcessorStatus.Zero) == 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset + 2);
                else Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset - 0xFF + 1);
            }
        }
    }

    class BPL : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x10; } }

        public override void Operation()
        {
            if ((Nes.CPU.P & ProcessorStatus.Negative) == 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset + 2);
                else Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset - 0xFF + 1);
            }
        }
    }

    class BVC : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x50; } }

        public override void Operation()
        {
            if ((Nes.CPU.P & ProcessorStatus.Overflow) == 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset + 2);
                else Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset - 0xFF + 1);
            }
        }
    }

    class BVS : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x70; } }

        public override void Operation()
        {
            if ((Nes.CPU.P & ProcessorStatus.Overflow) != 0)
            {
                byte offset = Immediate;
                if (offset < 0x80) Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset + 2);
                else Nes.CPU.PC = (ushort)(Nes.CPU.PC + offset - 0xFF + 1);
            }
        }
    }

}
