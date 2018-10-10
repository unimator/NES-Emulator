using System;
using System.Globalization;

namespace NES_Emulator.Memory
{
    public static class MemoryHelper
    {
        public static ushort StringToAddressResolve(CPU cpu, string arg)
        {
            switch (arg.ToUpper())
            {
                case "PC":
                    return cpu.PC;
                case "A":
                    return cpu.A;
                case "X":
                    return cpu.X;
                case "Y":
                    return cpu.Y;
                case "SP":
                    return cpu.SP;
                default:
                    return AddressResolver(arg);
            }
        }

        public static ushort AddressResolver(string arg)
        {
            ushort address;
            if (arg.StartsWith("0x"))
            {
                if (ushort.TryParse(arg.Substring(2), NumberStyles.AllowHexSpecifier, new NumberFormatInfo(), out address))
                    return address;
            }
            else
            {
                if (ushort.TryParse(arg, out address))
                    return address;
            }

            throw new ArgumentException($"{arg} is not a valid address");
        }
    }
}

