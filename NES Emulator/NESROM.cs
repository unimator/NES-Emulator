using System;
using System.IO;
using System.Linq;
using System.Text;
using NES_Emulator.NES;

namespace NES_Emulator
{
    public class NESROM
    {
        private static readonly byte [] NesHeader = Encoding.ASCII.GetBytes("\x4E\x45\x53\x1A");

        public int PRGROMSize { get; }
        public int CHRROMSize { get; }
        public int PRGRAMSize { get; }

        public byte Flags6 { get; }
        public bool BatteryBackedPRGRAM => (Flags6 & 1 << 1) != 0;
        public bool TrainerPresent => (Flags6 & 1 << 2) != 0;
        public bool IgnoreMirroringControl => (Flags6 & 1 << 3) != 0;
        public byte MapperNumberLower => (byte)(Flags6 >> 4);

        public byte Flags7 { get; }
        public bool VSUnisystem => (Flags7 & 1 << 0) != 0;
        public bool PlayChoice10 => (Flags7 & 1 << 1) != 0;
        public bool NES20Format => (Flags7 & (1 << 2 | 1 << 3)) != 0;
        public byte MapperNumberUpper => (byte) (Flags6 >> 4);

        public byte MapperNumber => (byte) (MapperNumberLower + MapperNumberUpper << 4); 

        public byte Flags9 { get; }

        public TVSystem TvSystem => (Flags9 & 1 << 0) == 0 ? TVSystem.NTSC : TVSystem.PAL;

        public TVSystem TvSystemExtended
        {
            get
            {
                byte tvSystemByte = (byte)((Flags10 & 1 << 0) | (Flags10 & 1 << 1));
                switch (tvSystemByte)
                {
                    case 0:
                        return TVSystem.NTSC;
                    case 1:
                    case 3:
                        return TVSystem.DualCompatible;
                    case 2:
                        return TVSystem.PAL;
                    default:
                        throw new ArgumentException("TVSystem out of range");
                }
            }
        }

        public byte Flags10 { get; }

        public NESROM(string fileName)
        {
            byte[] romData = null;

            if (File.Exists(fileName))
            {
                romData = File.ReadAllBytes(fileName);
            }

            if (romData != null)
            {
                if (!NesHeader.SequenceEqual(romData.Take(4)) && romData.Skip(11).Take(5).Any(n => n != 0))
                {
                    throw new Exception("Not a iNES file");
                }

                PRGROMSize = romData[4] * 0x4000;
                CHRROMSize = romData[5] * 0x2000;
                Flags6 = romData[6];
                Flags7 = romData[7];
                PRGRAMSize = romData[8] == 0 ? 0x2000 : romData [8] * 0x2000;
                Flags9 = romData[9];
                Flags10 = romData[10];
            }
        }


    }
}
