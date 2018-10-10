namespace NES_Emulator.Memory
{
    public class CPUMemory : MemoryBase
    {
        public CPUMemory(uint size)
            : base(size)
        {
        }

        public override byte this[int address]
        {
            get
            {
                return Memory[MirrorAddress(address)];
            }
            set
            {
                Memory[MirrorAddress(address)] = value;
            }
        }

        private static int MirrorAddress(int address)
        {
            if (address >= 0x2000 && address < 0x4000)
                return address % 8 + 0x2000;

            return address;
        }
    }
}
