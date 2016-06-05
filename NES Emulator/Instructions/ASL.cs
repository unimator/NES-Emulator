using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class ASL : Instruction
    {
        protected void Operation_ASL(byte M)
        {

        }
    }

    public class ASL_Accumulator : ASL
    {
        public override byte NoBytes { get { return 1; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0x0A; } }

        public override void Operation()
        {
            byte RES = (byte)(nes.cpu.A << 1);

            if ((nes.cpu.A & (1 << 7)) != 0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;

            Flags(RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            nes.cpu.A = RES;
        }
    }

    public class ASL_ZeroPage : ASL
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 5; } }
        public override byte OPCode { get { return 0x06; } }

        public override void Operation()
        {
            byte RES = (byte)(ZeroPage << 1);

            if ((ZeroPage & (1 << 7)) != 0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;

            Flags(RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            ZeroPage = RES;
        }
    }

    public class ASL_ZeroPageX : ASL
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x16; } }

        public override void Operation()
        {
            byte RES = (byte)(ZeroPageX << 1);

            if ((ZeroPageX & (1 << 7)) != 0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;

            Flags(RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            ZeroPageX = RES;
        }
    }

    public class ASL_Absolute : ASL
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 6; } }
        public override byte OPCode { get { return 0x0E; } }

        public override void Operation()
        {
            byte RES = (byte)(Absolute << 1);

            if ((Absolute & (1 << 7)) != 0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;

            Flags(RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            Absolute = RES;
        }
    }

    public class ASL_AbsoluteX : ASL
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 7; } }
        public override byte OPCode { get { return 0x1E; } }

        public override void Operation()
        {
            byte RES = (byte)(AbsoluteX << 1);

            if ((AbsoluteX & (1 << 7)) != 0) nes.cpu.P |= ProcessorStatus.Carry;
            else nes.cpu.P &= ~ProcessorStatus.Carry;

            Flags(RES, ProcessorStatus.Negative | ProcessorStatus.Zero);

            AbsoluteX = RES;
        }
    }
}
