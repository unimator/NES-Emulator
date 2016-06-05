using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator.Instructions
{
    public abstract class BIT : Instruction
    {
        public void Operation_BIT(byte M)
        {
            byte RES = (byte)(nes.cpu.A & M);

            if ((M & (1 << 7)) != 0) nes.cpu.P |= ProcessorStatus.Negative;
            else nes.cpu.P &= ~ProcessorStatus.Negative;

            if ((M & (1 << 6)) != 0) nes.cpu.P |= ProcessorStatus.Overflow;
            else nes.cpu.P &= ~ProcessorStatus.Overflow;

            if (RES == 0) nes.cpu.P |= ProcessorStatus.Zero;
            else nes.cpu.P &= ~ProcessorStatus.Zero;
            
        }
    }

    public class BIT_ZeroPage : BIT
    {
        public override byte NoBytes { get { return 2; } }
        public override byte NoCycles { get { return 3; } }
        public override byte OPCode { get { return 0x24; } }

        public override void Operation()
        {
            Operation_BIT(ZeroPage);
        }
    }

    public class BIT_Absolute : BIT
    {
        public override byte NoBytes { get { return 3; } }
        public override byte NoCycles { get { return 4; } }
        public override byte OPCode { get { return 0x2C; } }

        public override void Operation()
        {
            Operation_BIT(Absolute);
        }
    }
}
