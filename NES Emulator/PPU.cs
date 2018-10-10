using System;
using NES_Emulator.Memory;

namespace NES_Emulator
{
    public class PPU
    {
        public CPU CPU;

        //Registers
        public ControlRegister Control
        {
            get { return (ControlRegister)CPU.Memory[0x2000]; }
            set { CPU.Memory[0x2000] = (byte)value; }
        }

        public MaskRegister Mask
        {
            get { return (MaskRegister) (CPU.Memory[0x2001]); }
            set { CPU.Memory[0x2001] = (byte) value; }
        }

        public StatusRegister Status
        {
            get { return (StatusRegister) (CPU.Memory[0x2002]); }
            set { CPU.Memory[0x2002] = (byte) value; }
        }

        public byte SpriteMemoryAddress
        {
            get { return CPU.Memory[0x2003]; }
            set { CPU.Memory[0x2003] = value; }
        }

        public byte SpriteMemoryData
        {
            get
            {
                CPU.Memory[0x2004] = _memory[SpriteMemoryAddress];
                return _memory[SpriteMemoryAddress++]; // should increment ?
            }
            set
            {
                _memory[SpriteMemoryAddress] = value;
                CPU.Memory[0x2004] = value;
                ++SpriteMemoryAddress;
            }
        }

        private byte _scrollVertical;
        private byte _scrollHorizontal;
        private byte _scrollCycle;
        public byte Scroll
        {
            set
            {
                CPU.Memory[0x2005] = value;
                switch (_scrollCycle % 2)
                {
                    case 0:
                        _scrollVertical = value;
                        break;
                    case 1:
                        _scrollHorizontal = value;
                        break;
                }
                ++_scrollCycle;
            }
        }

        public byte Address
        {
            get { return CPU.Memory[0x2006]; }
            set { CPU.Memory[0x2006] = value; }
        }

        public byte Data
        {
            get { return CPU.Memory[0x2007]; }
            set { CPU.Memory[0x2007] = value; }
        }

        //Memory
        private PPUMemory _memory;
        
        public PPU(CPU cpu)
        {
            CPU = cpu;
            _memory = new PPUMemory(0x4000);
        }
    }

    [Flags]
    public enum ControlRegister
    {
        BaseNameTableAddressLower = 0x0,
        BaseNameTableAddressUpper = 0x1,
        IncrementMode = 0x2,
        SpriteTileSelect = 0x4,
        BackgroundTileSelect = 0x8,
        SpriteHeight = 0x10,
        MasterSlave = 0x20,
        NMIEnable = 0x40
    }

    [Flags]
    public enum MaskRegister
    {
        GreyScale = 0x0,
        BackgroundLeftColumnEnable = 0x1,
        SpriteLeftColumnEnabled = 0x2,
        BackgroundEnable = 0x4,
        SpriteEnable = 0x8,
        EmphasizeRed = 0x10,
        EmphasizeGreen = 0x20,
        EmphasizeBlue = 0x40
    }

    [Flags]
    public enum StatusRegister
    {
        VRAMWrite = 0x8,
        SpriteOverflow = 0x10,
        SpriteZeroHit = 0x20,
        VerticalBlank = 0x40
    }
}
