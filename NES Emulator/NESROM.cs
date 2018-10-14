using System;
using System.IO;
using System.Linq;
using System.Text;
using NESEmulator.NES;

namespace NESEmulator
{
    public class NesROM
    {
        private static readonly byte [] NesHeader = Encoding.ASCII.GetBytes("\x4E\x45\x53\x1A");

        public int PRGROMSize { private set; get; }
        public int CHRROMSize { private set; get; }
        public int PRGRAMSize { private set; get; }

        public byte Flags6 { private set; get; }
        public bool BatteryBackedPRGRAM => (Flags6 & 1 << 1) != 0;
        public bool TrainerPresent => (Flags6 & 1 << 2) != 0;
        public bool IgnoreMirroringControl => (Flags6 & 1 << 3) != 0;
        public byte MapperNumberLower => (byte)(Flags6 >> 4);

        public byte Flags7 { private set; get; }
        public bool VSUnisystem => (Flags7 & 1 << 0) != 0;
        public bool PlayChoice10 => (Flags7 & 1 << 1) != 0;
        public bool NES20Format => (Flags7 & (1 << 2 | 1 << 3)) != 0;
        public byte MapperNumberUpper => (byte) (Flags7 >> 4);

        public byte MapperNumber => (byte) (MapperNumberLower + MapperNumberUpper << sizeof(byte)); 

        public byte Flags9 { private set; get; }

        public TvSystem TvSystem => (Flags9 & 1 << 0) == 0 ? TvSystem.NTSC : TvSystem.PAL;

        public TvSystem TvSystemExtended
        {
            get
            {
                byte tvSystemByte = (byte)((Flags10 & 1 << 0) | (Flags10 & 1 << 1));
                switch (tvSystemByte)
                {
                    case 0:
                        return TvSystem.NTSC;
                    case 1:
                    case 3:
                        return TvSystem.DualCompatible;
                    case 2:
                        return TvSystem.PAL;
                    default:
                        throw new ArgumentException("TVSystem out of range");
                }
            }
        }

        public byte Flags10 { private set; get; }
        public bool PRGRAMNotPresent => (Flags10 & 1 << 4) == 0;
        public bool NoBusConflitcts => (Flags10 & 1 << 5) == 0;

        public byte [] Trainer { private set; get; }

        public byte [] PRGROM { private set; get; }

        public byte [] CHRROM { private set; get; }

        public NesROM(string fileName)
        {
            byte[] romData = null;

            if (File.Exists(fileName))
            {
                romData = File.ReadAllBytes(fileName);
            }

            if (romData == null)
            {
                return;
            }

            LoadRomData(romData);
        }

        private void LoadRomData(byte[] romData)
        {
            if (!NesHeader.SequenceEqual(romData.Take(4)) && romData.Skip(11).Take(5).Any(n => n != 0))
            {
                throw new Exception("Not a iNES file");
            }

            const int headerSize = 0x10;
            var offset = 0;

            PRGROMSize = romData[4] * 0x4000;
            CHRROMSize = romData[5] * 0x2000;
            Flags6 = romData[6];
            Flags7 = romData[7];
            PRGRAMSize = romData[8] == 0 ? 0x2000 : romData[8] * 0x2000;
            Flags9 = romData[9];
            Flags10 = romData[10];

            offset += headerSize;

            const int trainerSize = 0x200;

            if (TrainerPresent)
            {
                Trainer = new byte[trainerSize];
                Array.Copy(romData, headerSize, Trainer, 0, trainerSize);
                offset += trainerSize;
            }
            
            PRGROM = new byte[PRGROMSize];
            Array.Copy(romData, offset, PRGROM, 0, PRGROMSize);
            offset += PRGROMSize;

            CHRROM = new byte[CHRROMSize];
            Array.Copy(romData, offset, CHRROM, 0, CHRROMSize);
        }
    }
}
