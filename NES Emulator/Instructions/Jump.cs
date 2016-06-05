using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public class JMP_Absolute : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0x4C; } }

        public override void Operation()
        {
            nes.cpu.PC = (ushort)(nes.RAM[nes.cpu.PC + 1] + (nes.RAM[nes.cpu.PC + 2] << 8));
        }
    }

    public class JMP_Indirect : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OPCode { get { return 0x6C; } }

        public override void Operation()
        {
            ushort Address = (byte)(nes.RAM[nes.cpu.PC + 1] + (nes.RAM[nes.cpu.PC + 2] << 8));
            nes.cpu.PC = (ushort)(nes.RAM[Address] + (nes.RAM[Address] << 8));
        }
    }

    public class JSR : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x20; } }

        public override void Operation()
        {
            nes.Push(NES.Higher((ushort)(nes.cpu.PC + 2)));
            nes.Push(NES.Lower((ushort)(nes.cpu.PC + 2)));

            nes.cpu.PC = (ushort)(nes.RAM[nes.cpu.PC + 1] + (nes.RAM[nes.cpu.PC + 2] << 8));
        }
    }


}
