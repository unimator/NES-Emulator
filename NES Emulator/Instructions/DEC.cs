using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class DEC : Instruction
    {
    }

    public class DEC_ZeroPage : DEC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OpCode { get { return 0xC6; } }

        public override void Operation()
        {
            ZeroPage = (byte)(ZeroPage - 1);
            Flags(ZeroPage, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class DEC_ZeroPageX : DEC
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0xD6; } }

        public override void Operation()
        {
            ZeroPageX = (byte)(ZeroPageX - 1);
            Flags(ZeroPageX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class DEC_Absolute : DEC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0xCE; } }

        public override void Operation()
        {
            Absolute = (byte)(Absolute - 1);
            Flags(Absolute, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class DEC_AbsoluteX : DEC
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 7; } }
        public override byte OpCode { get { return 0xDE; } }

        public override void Operation()
        {
            AbsoluteX = (byte)(AbsoluteX - 1);
            Flags(AbsoluteX, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class DEX : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2  ; } }
        public override byte OpCode { get { return 0xCA; } }

        public override void Operation()
        {
            Nes.CPU.X = (byte)(Nes.CPU.X - 1);
            Flags(Nes.CPU.X, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }

    public class DEY : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x88; } }

        public override void Operation()
        {
            Nes.CPU.Y = (byte)(Nes.CPU.Y - 1);
            Flags(Nes.CPU.Y, ProcessorStatus.Zero | ProcessorStatus.Negative);
        }
    }
}
