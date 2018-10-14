namespace NES_Emulator.Instructions
{
    public class JMP_Absolute : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 3;
        public override byte OpCode => 0x4C;

        public override void Execute()
        {
            CPU.PC = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + (CPU.Memory[(ushort)(CPU.PC + 2)] << 8));
        }

        public JMP_Absolute(CPU cpu) : base(cpu)
        {
        }
    }

    public class JMP_Indirect : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 5;
        public override byte OpCode => 0x6C;

        public override void Execute()
        {
            var Address = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + (CPU.Memory[(ushort)(CPU.PC + 2)] << 8));
            CPU.PC = (ushort)(CPU.Memory[Address] + (CPU.Memory[Address] << 8));
        }

        public JMP_Indirect(CPU cpu) : base(cpu)
        {
        }
    }

    public class JSR : Instruction
    {
        public override byte NoBytes => 3;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x20;

        public override void Execute()
        {
            CPU.Push(NES.NES.Higher((ushort)(CPU.PC + 2)));
            CPU.Push(NES.NES.Lower((ushort)(CPU.PC + 2)));

            CPU.PC = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + (CPU.Memory[(ushort)(CPU.PC + 2)] << 8));
        }

        public JSR(CPU cpu) : base(cpu)
        {
        }
    }


}
