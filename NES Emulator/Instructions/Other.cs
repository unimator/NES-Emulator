namespace NES_Emulator.Instructions
{
    public class BRK : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 7; } }
        public override byte OpCode { get { return 0x00; } }

        public override void Operation()
        {
            Nes.Push(NES.NES.Higher((ushort)(Nes.CPU.PC + 2)));
            Nes.Push(NES.NES.Lower((ushort)(Nes.CPU.PC + 2)));

            Nes.Push((byte)(Nes.CPU.P | ProcessorStatus.BreakCommand));

            Nes.CPU.PC = (ushort)(Nes.CPU.Memory[0xFFFE] + (Nes.CPU.Memory[0xFFFF] << 8));
        }
    }

    public class RTI : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x40; } }

        public override void Operation()
        {
            Nes.CPU.P = (ProcessorStatus)Nes.Pop();

            Nes.CPU.PC = Nes.Pop();
            Nes.CPU.PC += (ushort)(Nes.Pop() << 8); 
        }
    }

    public class RTS : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x60; } }

        public override void Operation()
        {
            Nes.CPU.PC = Nes.Pop();
            Nes.CPU.PC += (ushort)(Nes.Pop() << 8);

            Nes.CPU.PC += 1;
        }
    }

    public class NOP : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0xEA; } }

        public override void Operation()
        {
            return;
        }
    }
}
