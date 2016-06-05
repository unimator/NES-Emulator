using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class CPY : Instruction
    {
        public void Operation_CPY(byte M)
        {
            byte RES = (byte)(nes.cpu.Y - M);

            Flags(RES, ProcessorStatus.Zero | ProcessorStatus.Negative);

            if (nes.cpu.Y < M) nes.cpu.P &= ~ProcessorStatus.Carry;
            else nes.cpu.P |= ProcessorStatus.Carry;
        }
    }

    public class CPY_Immediate : CPY
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xC0; } }

        public override void Operation()
        {
            Operation_CPY(Immediate);
        }
    }

    public class CPY_ZeroPage : CPY
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0xC4; } }

        public override void Operation()
        {
            Operation_CPY(ZeroPage);
        }
    }

    public class CPY_Absolute : CPY
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xCC; } }

        public override void Operation()
        {
            Operation_CPY(Absolute);
        }
    }
}
