using System;

namespace NES_Emulator.Memory
{
    public abstract class MemoryBase
    {
        public byte[] Memory { get; set; }

        protected MemoryBase(uint size)
        {
            Memory = new byte[size];
            Array.Clear(Memory, 0, Memory.Length);
        }

        public virtual byte this[int address]
        {
            get
            {
                return Memory[address];
            }
            set
            {
                Memory[address] = value;
            }
        }
    }
}
