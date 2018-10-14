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

        public virtual byte this[ushort address]
        {
            get => Memory[GetAbsoluteAddress(address)];
            set => Memory[GetAbsoluteAddress(address)] = value;
        }

        protected abstract ushort GetAbsoluteAddress(ushort address);

        public ushort GetWord(ushort address)
        {
            return (ushort)(this[address] << 8 + this[(ushort)(address + 1)]);
        }
    }
}
