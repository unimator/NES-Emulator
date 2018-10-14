using NESEmulator.Memory;

namespace NES_Emulator.Memory
{
    public class CPUMemory : MemoryBase
    {
        public CPUMemory(uint size)
            : base(size)
        {
        }

        public override byte this[ushort address]
        {
            get => Memory[GetAbsoluteAddress(address)];
            set => Memory[GetAbsoluteAddress(address)] = value;
        }

        protected override ushort GetAbsoluteAddress(ushort address)
        {
            // RAM
            if (address < 0x2000)
            {
                return (ushort)(address & 0x7FFF);
            }

            // PPU Registers
            if (address < 0x4000)
            {

            }


            if (address >= 0x2000 && address < 0x4000)
                return (ushort)(address % 8 + 0x2000);

            return address;
        }
    }
}
