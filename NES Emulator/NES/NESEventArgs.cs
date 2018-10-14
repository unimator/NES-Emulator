using System;

namespace NESEmulator.NES
{
    public class NESEventArgs : EventArgs
    {
        public string Message { get; set; }
        public byte OpCode { get; set; }
    }
}
