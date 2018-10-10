namespace NES_Emulator.Instructions
{
    public abstract class Instruction
    {
        public static NES.NES Nes = null;

        public abstract byte OpCode { get; }
        public abstract byte NoBytes { get; }
        public abstract byte NoCycles { get; }

        public abstract void Operation();

        public byte Immediate
        {
            get
            {
                return Nes.CPU.Memory[Nes.CPU.PC + 1];
            }
            set
            {
                Nes.CPU.Memory[Nes.CPU.PC + 1] = value;
            } 
        }

        public byte ZeroPage
        {
            get
            {
                return Nes.CPU.Memory[Nes.CPU.Memory[Nes.CPU.PC + 1]];
            }
            set
            {
                Nes.CPU.Memory[Nes.CPU.Memory[Nes.CPU.PC + 1]] = value;
            }
        }

        public byte ZeroPageX
        {
            get
            {
                return Nes.CPU.Memory[(byte)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.X)];
            }
            set
            {
                Nes.CPU.Memory[(byte)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.X)] = value;
            }
        }

        public byte ZeroPageY
        {
            get
            {
                return Nes.CPU.Memory[(byte)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.Y)];
            }
            set
            {
                Nes.CPU.Memory[(byte)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.Y)] = value;
            }
        }

        public byte Absolute
        {
            get
            {
                ushort address = (ushort)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.Memory[Nes.CPU.PC + 2] * 0x100);
                return Nes.CPU.Memory[address];
            }
            set
            {
                ushort address = (ushort)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.Memory[Nes.CPU.PC + 2] * 0x100);
                Nes.CPU.Memory[address] = value;
            }
        }

        public byte AbsoluteX
        {
            get
            {
                ushort address = (ushort)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.Memory[Nes.CPU.PC + 2] * 0x100);
                return Nes.CPU.Memory[address + Nes.CPU.X];
            }
            set
            {
                ushort address = (ushort)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.Memory[Nes.CPU.PC + 2] * 0x100);
                Nes.CPU.Memory[address + Nes.CPU.X] = value;
            }
        }

        public byte AbsoluteY
        {
            get
            {
                ushort address = (ushort)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.Memory[Nes.CPU.PC + 2] * 0x100);
                return Nes.CPU.Memory[address + Nes.CPU.Y];
            }
            set
            {
                ushort address = (ushort)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.Memory[Nes.CPU.PC + 2] * 0x100);
                Nes.CPU.Memory[address + Nes.CPU.Y] = value;
            }
        }

        public byte IndirectX
        {
            get
            {
                ushort address = (byte)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.X);
                address = (ushort)(Nes.CPU.Memory[address] + Nes.CPU.Memory[address + 1] * 0x100);
                return Nes.CPU.Memory[address];
            }
            set
            {
                ushort address = (byte)(Nes.CPU.Memory[Nes.CPU.PC + 1] + Nes.CPU.X);
                address = (ushort)(Nes.CPU.Memory[address] + Nes.CPU.Memory[address + 1] * 0x100);
                Nes.CPU.Memory[address] = value;
            }
        }

        public byte IndirectY
        {
            get
            {
                ushort address = Nes.CPU.Memory[Nes.CPU.PC + 1];
                address = (ushort)(Nes.CPU.Memory[address] + Nes.CPU.Memory[address + 1] * 0x100);
                return Nes.CPU.Memory[address + Nes.CPU.Y];
            }
            set
            {
                ushort address = Nes.CPU.Memory[Nes.CPU.PC + 1];
                address = (ushort)(Nes.CPU.Memory[address] + Nes.CPU.Memory[address + 1] * 0x100);
                Nes.CPU.Memory[address + Nes.CPU.Y] = value;
            }
        }

        public void Flags(byte result, ProcessorStatus flags)
        {
            if((flags & ProcessorStatus.Zero) != 0)
            {
                if (result == 0) Nes.CPU.P |= ProcessorStatus.Zero;
                else Nes.CPU.P &= ~ProcessorStatus.Zero;
            }

            if ((flags & ProcessorStatus.Negative) != 0)
            {
                if ((result & (1 << 7)) != 0) Nes.CPU.P |= ProcessorStatus.Negative;
                else Nes.CPU.P &= ~ProcessorStatus.Negative;
            }
        }
    }
}
