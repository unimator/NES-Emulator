namespace NES_Emulator.Instructions
{
    public class BRK : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 7;
        public override byte OpCode => 0x00;

        public override void Execute()
        {
            CPU.Push(NES.NES.Higher((ushort)(CPU.PC + 2)));
            CPU.Push(NES.NES.Lower((ushort)(CPU.PC + 2)));

            CPU.Push((byte)(CPU.P | ProcessorStatus.BreakCommand));

            CPU.PC = (ushort)(CPU.Memory[0xFFFE] + (CPU.Memory[0xFFFF] << 8));
        }

        public BRK(CPU cpu) : base(cpu)
        {
        }
    }

    public class RTI : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x40;

        public override void Execute()
        {
            CPU.P = (ProcessorStatus)CPU.Pop();

            CPU.PC = CPU.Pop();
            CPU.PC += (ushort)(CPU.Pop() << 8); 
        }

        public RTI(CPU cpu) : base(cpu)
        {
        }
    }

    public class RTS : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 6;
        public override byte OpCode => 0x60;

        public override void Execute()
        {
            CPU.PC = CPU.Pop();
            CPU.PC += (ushort)(CPU.Pop() << 8);

            CPU.PC += 1;
        }

        public RTS(CPU cpu) : base(cpu)
        {
        }
    }

    public class NOP : Instruction
    {
        public override byte NoBytes => 1;
        public override byte NoCycles => 2;
        public override byte OpCode => 0xEA;

        public override void Execute()
        {
        }

        public NOP(CPU cpu) : base(cpu)
        {
        }
    }
}
