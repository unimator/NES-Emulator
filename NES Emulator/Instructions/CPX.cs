using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class CPX : Instruction
    {
        public void Operation_CPX(byte M)
        {
            byte RES = (byte)(nes.cpu.X - M);

            Flags(RES, ProcessorStatus.Zero | ProcessorStatus.Negative);

            if (nes.cpu.X < M) nes.cpu.P &= ~ProcessorStatus.Carry;
            else nes.cpu.P |= ProcessorStatus.Carry;
        }
    }

    public class CPX_Immediate : CPX
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 2; } }
        public override byte OPCode { get { return 0xE0; } }

        public override void Operation()
        {
            Operation_CPX(Immediate);
        }
    }

    public class CPX_ZeroPage : CPX
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0xE4; } }

        public override void Operation()
        {
            Operation_CPX(ZeroPage);
        }
    }

    public class CPX_Absolute : CPX
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0xEC; } }

        public override void Operation()
        {
            Operation_CPX(Absolute);
        }
    }
}
