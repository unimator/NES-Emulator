using System;
using NES_Emulator.Memory;

namespace NES_Emulator
{

    public class CPU
    {
        public ushort PC { get; set; }
        public byte SP { get; set; }
        public byte A { get; set; }
        public byte X { get; set; }
        public byte Y { get; set; }
        public ProcessorStatus P { get; set; }
        
        public CPUMemory Memory;

        public CPU()
        {
            Memory = new CPUMemory(0x10000);
            Reset();
        }

        public void Reset(ushort addr)
        {
            PC = Memory.GetWord(addr);
            A = X = Y = 0;
            SP = 0xFD;
            P = ProcessorStatus.InterruptDisabled;
        }

        public void Reset()
        {
            Reset(Utils.ResetVector);
        }

        public void Interrupt(InterruptType interruptType)
        {
            if ((P & ProcessorStatus.InterruptDisabled) != 0
                && interruptType != InterruptType.NMI 
                && interruptType != InterruptType.BRK)
            {
                return;
            }

            if (interruptType == InterruptType.BRK)
            {
                P &= ProcessorStatus.BreakCommand;
                ++PC;
            }

            Push((byte)(PC >> 8));
            Push((byte)(PC & 0xFF));
            Push((byte)P);

            P &= ProcessorStatus.InterruptDisabled;

            switch (interruptType)
            {
                case InterruptType.IRQ:
                case InterruptType.BRK:
                    PC = Memory.GetWord(Utils.IRQVector);
                    break;

                case InterruptType.NMI:
                    PC = Memory.GetWord(Utils.NMIVector);
                    break;
            }
        }

        public byte Pop()
        {
            return Memory[(ushort)(++SP + Utils.StackOffset)];
        }

        public void Push(byte data)
        {
            Memory[(ushort)(SP-- + Utils.StackOffset)] = data;
        }
    }

    public enum InterruptType
    {
        IRQ, NMI, BRK
    }

    [Flags]
    public enum ProcessorStatus
    {
        None = 0x0,
        Carry = 0x1,
        Zero = 0x2,
        InterruptDisabled = 0x4,
        DecimalMode = 0x8,
        BreakCommand = 0x10,
        Reserved = 0x20,
        Overflow = 0x40,
        Negative = 0x80
    }
}
