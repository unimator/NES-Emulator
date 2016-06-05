using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator
{
    public abstract class Instruction
    {
        public static NES nes = null;

        public abstract byte OPCode { get; }
        public abstract byte NoBytes { get; }
        public abstract byte NoCycles { get; }

        public abstract void Operation();

        public byte Immediate
        {
            get
            {
                return nes.RAM[nes.cpu.PC + 1];
            }
            set
            {
                nes.RAM[nes.cpu.PC + 1] = value;
            } 
        }

        public byte ZeroPage
        {
            get
            {
                return nes.RAM[nes.RAM[nes.cpu.PC + 1]];
            }
            set
            {
                nes.RAM[nes.RAM[nes.cpu.PC + 1]] = value;
            }
        }

        public byte ZeroPageX
        {
            get
            {
                return nes.RAM[(byte)(nes.RAM[nes.cpu.PC + 1] + nes.cpu.X)];
            }
            set
            {
                nes.RAM[(byte)(nes.RAM[nes.cpu.PC + 1] + nes.cpu.X)] = value;
            }
        }

        public byte ZeroPageY
        {
            get
            {
                return nes.RAM[(byte)(nes.RAM[nes.cpu.PC + 1] + nes.cpu.Y)];
            }
            set
            {
                nes.RAM[(byte)(nes.RAM[nes.cpu.PC + 1] + nes.cpu.Y)] = value;
            }
        }

        public byte Absolute
        {
            get
            {
                ushort Address = (ushort)(nes.RAM[nes.cpu.PC + 1] + nes.RAM[nes.cpu.PC + 2] * 0x100);
                return nes.RAM[Address];
            }
            set
            {
                ushort Address = (ushort)(nes.RAM[nes.cpu.PC + 1] + nes.RAM[nes.cpu.PC + 2] * 0x100);
                nes.RAM[Address] = value;
            }
        }

        public byte AbsoluteX
        {
            get
            {
                ushort Address = (ushort)(nes.RAM[nes.cpu.PC + 1] + nes.RAM[nes.cpu.PC + 2] * 0x100);
                return nes.RAM[Address + nes.cpu.X];
            }
            set
            {
                ushort Address = (ushort)(nes.RAM[nes.cpu.PC + 1] + nes.RAM[nes.cpu.PC + 2] * 0x100);
                nes.RAM[Address + nes.cpu.X] = value;
            }
        }

        public byte AbsoluteY
        {
            get
            {
                ushort Address = (ushort)(nes.RAM[nes.cpu.PC + 1] + nes.RAM[nes.cpu.PC + 2] * 0x100);
                return nes.RAM[Address + nes.cpu.Y];
            }
            set
            {
                ushort Address = (ushort)(nes.RAM[nes.cpu.PC + 1] + nes.RAM[nes.cpu.PC + 2] * 0x100);
                nes.RAM[Address + nes.cpu.Y] = value;
            }
        }

        public byte IndirectX
        {
            get
            {
                ushort Address = (byte)(nes.RAM[nes.cpu.PC + 1] + nes.cpu.X);
                Address = (ushort)(nes.RAM[Address] + nes.RAM[Address + 1] * 0x100);
                return nes.RAM[Address];
            }
            set
            {
                ushort Address = (byte)(nes.RAM[nes.cpu.PC + 1] + nes.cpu.X);
                Address = (ushort)(nes.RAM[Address] + nes.RAM[Address + 1] * 0x100);
                nes.RAM[Address] = value;
            }
        }

        public byte IndirectY
        {
            get
            {
                ushort Address = nes.RAM[nes.cpu.PC + 1];
                Address = (ushort)(nes.RAM[Address] + nes.RAM[Address + 1] * 0x100);
                return nes.RAM[Address + nes.cpu.Y];
            }
            set
            {
                ushort Address = nes.RAM[nes.cpu.PC + 1];
                Address = (ushort)(nes.RAM[Address] + nes.RAM[Address + 1] * 0x100);
                nes.RAM[Address + nes.cpu.Y] = value;
            }
        }

        public void Flags(byte Result, ProcessorStatus Flags)
        {
            if((Flags & ProcessorStatus.Zero) != 0)
            {
                if (Result == 0) nes.cpu.P |= ProcessorStatus.Zero;
                else nes.cpu.P &= ~ProcessorStatus.Zero;
            }

            if ((Flags & ProcessorStatus.Negative) != 0)
            {
                if ((Result & (1 << 7)) != 0) nes.cpu.P |= ProcessorStatus.Negative;
                else nes.cpu.P &= ~ProcessorStatus.Negative;
            }
        }
    }
}
