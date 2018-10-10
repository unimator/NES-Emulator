namespace NES_Emulator.Instructions
{
    public class JMP_Absolute : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OpCode { get { return 0x4C; } }

        public override void Operation()
        {
            Nes.CPU.PC = (ushort)(Nes.CPU.Memory[Nes.CPU.PC + 1] + (Nes.CPU.Memory[Nes.CPU.PC + 2] << 8));
        }
    }

    public class JMP_Indirect : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OpCode { get { return 0x6C; } }

        public override void Operation()
        {
            ushort Address = (byte)(Nes.CPU.Memory[Nes.CPU.PC + 1] + (Nes.CPU.Memory[Nes.CPU.PC + 2] << 8));
            Nes.CPU.PC = (ushort)(Nes.CPU.Memory[Address] + (Nes.CPU.Memory[Address] << 8));
        }
    }

    public class JSR : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x20; } }

        public override void Operation()
        {
            Nes.Push(NES.NES.Higher((ushort)(Nes.CPU.PC + 2)));
            Nes.Push(NES.NES.Lower((ushort)(Nes.CPU.PC + 2)));

            Nes.CPU.PC = (ushort)(Nes.CPU.Memory[Nes.CPU.PC + 1] + (Nes.CPU.Memory[Nes.CPU.PC + 2] << 8));
        }
    }


}
