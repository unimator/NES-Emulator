namespace NESEmulator.NES
{
    public enum Mirroring
    {
        Horizontal = 0x0,
        Vertival = 0x1
    }

    public enum TvSystem
    {
        NTSC = 0x0,
        PAL = 0x1,
        DualCompatible = 0x2
    }

    public enum BoardsBUSConflicts
    {
        NoConflicts = 0x0,
        Conflicts = 0x1
    }
}
