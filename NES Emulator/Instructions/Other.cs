using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public class BRK : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 7; } }
        public override byte OPCode { get { return 0x00; } }

        public override void Operation()
        {
            nes.Push(NES.Higher((ushort)(nes.cpu.PC + 2)));
            nes.Push(NES.Lower((ushort)(nes.cpu.PC + 2)));

            nes.Push((byte)(nes.cpu.P | ProcessorStatus.Break_Command));

            nes.cpu.PC = (ushort)(nes.RAM[0xFFFE] + (nes.RAM[0xFFFF] << 8));
        }
    }

    public class RTI : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x40; } }

        public override void Operation()
        {
            nes.cpu.P = (ProcessorStatus)nes.Pop();

            nes.cpu.PC = nes.Pop();
            nes.cpu.PC += (ushort)(nes.Pop() << 8); 
        }
    }

    public class RTS : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x60; } }

        public override void Operation()
        {
            nes.cpu.PC = nes.Pop();
            nes.cpu.PC += (ushort)(nes.Pop() << 8);

            nes.cpu.PC += 1;
        }
    }

    public class NOP : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xEA; } }

        public override void Operation()
        {
            return;
        }
    }
}
