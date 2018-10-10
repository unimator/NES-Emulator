using System;
using NES_Emulator.Memory;

namespace NES_Emulator
{

    public class CPU
    {
        //Registers
        public ushort PC { get; set; }
        public byte SP { get; set; }
        public byte A { get; set; }
        public byte X { get; set; }
        public byte Y { get; set; }
        public ProcessorStatus P { get; set; }

        //Memory
        public CPUMemory Memory;

        public CPU()
        {
            Memory = new CPUMemory(0x10000);
            PC = 0x600;
            SP = 0xFF;
            A = 0;
            X = 0;
            Y = 0;
            P = ProcessorStatus.None;
        }
    }

    [Flags]
    public enum ProcessorStatus
    {
        None = 0x0,
        Carry = 0x1,
        Zero = 0x2,
        InterruptDisable = 0x4,
        DecimalMode = 0x8,
        BreakCommand = 0x10,
        Reserved = 0x20,
        Overflow = 0x40,
        Negative = 0x80
    }
}
