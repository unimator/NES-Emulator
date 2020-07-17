namespace NES_Emulator.Memory
{
    public class PPUMemory : MemoryBase
    {
        public PPUMemory(uint size)
            : base(size)
        {
        }

        protected override ushort GetAbsoluteAddress(ushort address)
        {
            throw new System.NotImplementedException();
        }
    }
}
