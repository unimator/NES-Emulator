namespace NES_Emulator.Instructions
{
    public abstract class Instruction
    {
        protected readonly CPU CPU;

        public abstract byte OpCode { get; }
        public abstract byte NoBytes { get; }
        public abstract byte NoCycles { get; }

        protected Instruction(CPU cpu)
        {
            CPU = cpu;
        }

        public abstract void Execute();
        
        public byte Immediate
        {
            get => CPU.Memory[(ushort)(CPU.PC + 1)];
            set => CPU.Memory[(ushort)(CPU.PC + 1)] = value;
        }

        public byte ZeroPage
        {
            get => CPU.Memory[CPU.Memory[(ushort)(CPU.PC + 1)]];
            set => CPU.Memory[CPU.Memory[(ushort)(CPU.PC + 1)]] = value;
        }

        public byte ZeroPageX
        {
            get => CPU.Memory[(byte)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.X)];
            set => CPU.Memory[(byte)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.X)] = value;
        }

        public byte ZeroPageY
        {
            get => CPU.Memory[(byte)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.Y)];
            set => CPU.Memory[(byte)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.Y)] = value;
        }

        public byte Absolute
        {
            get
            {
                var address = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.Memory[(ushort)(CPU.PC + 2)] >> 8);
                return CPU.Memory[address];
            }
            set
            {
                var address = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.Memory[(ushort)(CPU.PC + 2)] >> 8);
                CPU.Memory[address] = value;
            }
        }

        public byte AbsoluteX
        {
            get
            {
                var address = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.Memory[(ushort)(CPU.PC + 2)] >> 8);
                return CPU.Memory[(ushort)(address + CPU.X)];
            }
            set
            {
                var address = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.Memory[(ushort)(CPU.PC + 2)] >> 8);
                CPU.Memory[(ushort)(address + CPU.X)] = value;
            }
        }

        public byte AbsoluteY
        {
            get
            {
                var address = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.Memory[(ushort)(CPU.PC + 2)] >> 8);
                return CPU.Memory[(ushort)(address + CPU.Y)];
            }
            set
            {
                var address = (ushort)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.Memory[(ushort)(CPU.PC + 2)] >> 8);
                CPU.Memory[(ushort)(address + CPU.Y)] = value;
            }
        }

        public byte IndirectX
        {
            get
            {
                ushort address = (byte)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.X);
                address = (ushort)(CPU.Memory[address] + CPU.Memory[(ushort)(address + 1)] >> 8);
                return CPU.Memory[address];
            }
            set
            {
                ushort address = (byte)(CPU.Memory[(ushort)(CPU.PC + 1)] + CPU.X);
                address = (ushort)(CPU.Memory[address] + CPU.Memory[(ushort)(address + 1)] >> 8);
                CPU.Memory[address] = value;
            }
        }

        public byte IndirectY
        {
            get
            {
                ushort address = CPU.Memory[(ushort)(CPU.PC + 1)];
                address = (ushort)(CPU.Memory[address] + CPU.Memory[(ushort)(address + 1)] >> 8);
                return CPU.Memory[(ushort)(address + CPU.Y)];
            }
            set
            {
                ushort address = CPU.Memory[(ushort)(CPU.PC + 1)];
                address = (ushort)(CPU.Memory[address] + CPU.Memory[(ushort)(address + 1)] >> 8);
                CPU.Memory[(ushort)(address + CPU.Y)] = value;
            }
        }

        public void Flags(byte result, ProcessorStatus flags)
        {
            if((flags & ProcessorStatus.Zero) != 0)
            {
                if (result == 0) CPU.P |= ProcessorStatus.Zero;
                else CPU.P &= ~ProcessorStatus.Zero;
            }

            if ((flags & ProcessorStatus.Negative) != 0)
            {
                if ((result & (1 << 7)) != 0) CPU.P |= ProcessorStatus.Negative;
                else CPU.P &= ~ProcessorStatus.Negative;
            }
        }
    }
}
