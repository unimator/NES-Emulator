using System;

namespace NES_Emulator.NES
{
    public class NESEventArgs : EventArgs
    {
        public string Message { get; set; }
        public byte OpCode { get; set; }
    }
}
