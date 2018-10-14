namespace NES_Emulator
{
    public static class Utils
    {
        public static readonly ushort StackOffset = 0x100;

        public static readonly ushort ResetVector = 0xFFFC;
        public static readonly ushort IRQVector = 0xFFFE;
        public static readonly ushort NMIVector = 0xFFFA;
    }
}