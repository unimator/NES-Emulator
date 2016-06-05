using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public class ROR_Accumulator : Instruction
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0x6A; } }

        public override void Operation()
        {
            bool b0 = (nes.cpu.A & 1) == 0 ? false : true;

            nes.cpu.A >>= 1;
            if ((nes.cpu.P & ProcessorStatus.Carry) != 0) nes.cpu.A += (1 << 7);

            if (b0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;
            Flags(nes.cpu.A, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class ROR_ZeroPage : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OPCode { get { return 0x66; } }

        public override void Operation()
        {
            bool b0 = (ZeroPage & 1) == 0 ? false : true;

            ZeroPage >>= 1;
            if ((nes.cpu.P & ProcessorStatus.Carry) != 0) ZeroPage += (1 << 7);

            if (b0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;
            Flags(ZeroPage, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class ROR_ZeroPageX : Instruction
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x76; } }

        public override void Operation()
        {
            bool b0 = (ZeroPageX & 1) == 0 ? false : true;

            ZeroPageX >>= 1;
            if ((nes.cpu.P & ProcessorStatus.Carry) != 0) ZeroPageX += (1 << 7);

            if (b0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;
            Flags(ZeroPageX, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class ROR_Absolute : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x6E; } }

        public override void Operation()
        {
            bool b0 = (Absolute & 1) == 0 ? false : true;

            Absolute >>= 1;
            if ((nes.cpu.P & ProcessorStatus.Carry) != 0) Absolute += (1 << 7);

            if (b0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;
            Flags(Absolute, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }

    public class ROR_AbsoluteX : Instruction
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 7; } }
        public override byte OPCode { get { return 0x7E; } }

        public override void Operation()
        {
            bool b0 = (AbsoluteX & 1) == 0 ? false : true;

            AbsoluteX >>= 1;
            if ((nes.cpu.P & ProcessorStatus.Carry) != 0) AbsoluteX += (1 << 7);

            if (b0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;
            Flags(AbsoluteX, ProcessorStatus.Negative | ProcessorStatus.Zero);
        }
    }
}
