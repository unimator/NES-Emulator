using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public class ROL_Accumulator : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OpCode { get { return 0x2A; } }

        public override void Operation()
        {
            bool b7 = (Nes.CPU.A & (1 << 7)) == 0 ? false : true;

            Nes.CPU.A <<= 1;
            if ((Nes.CPU.P & ProcessorStatus.Carry) != 0) Nes.CPU.A += 1;

            if (b7) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;
            Flags(Nes.CPU.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class ROL_ZeroPage : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OpCode { get { return 0x26; } }

        public override void Operation()
        {
            bool b7 = (ZeroPage & (1 << 7)) == 0 ? false : true;

            ZeroPage <<= 1;
            if ((Nes.CPU.P & ProcessorStatus.Carry) != 0) ZeroPage += 1;

            if (b7) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;
            Flags(ZeroPage, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class ROL_ZeroPageX : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x36; } }

        public override void Operation()
        {
            bool b7 = (ZeroPageX & (1 << 7)) == 0 ? false : true;

            ZeroPageX <<= 1;
            if ((Nes.CPU.P & ProcessorStatus.Carry) != 0) ZeroPageX += 1;

            if (b7) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;
            Flags(ZeroPageX, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class ROL_Absolute : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OpCode { get { return 0x2E; } }

        public override void Operation()
        {
            bool b7 = (Absolute & (1 << 7)) == 0 ? false : true;

            Absolute <<= 1;
            if ((Nes.CPU.P & ProcessorStatus.Carry) != 0) Absolute += 1;

            if (b7) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;
            Flags(Absolute, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class ROL_AbsoluteX : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 7; } }
        public override byte OpCode { get { return 0x3E; } }

        public override void Operation()
        {
            bool b7 = (AbsoluteX & (1 << 7)) == 0 ? false : true;

            AbsoluteX <<= 1;
            if ((Nes.CPU.P & ProcessorStatus.Carry) != 0) AbsoluteX += 1;

            if (b7) Nes.CPU.P |= ProcessorStatus.Carry;
            else Nes.CPU.P &= ~ProcessorStatus.Carry;
            Flags(AbsoluteX, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }
}
