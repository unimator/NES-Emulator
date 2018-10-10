using System;

namespace NES_Emulator.Instructions
{
    public partial class InstructionSet
    {
        public InstructionSet()
        {
            for (int i = 0; i < 0xFF; ++i)
            {
                InstructionsArray[i] = null;
            }

            InstructionsArray[0x00] = new BRK();
            InstructionsArray[0x01] = new ORA_IndirectX();
            InstructionsArray[0x05] = new ORA_ZeroPage();
            InstructionsArray[0x06] = new ASL_ZeroPage();
            InstructionsArray[0x08] = new PHP();
            InstructionsArray[0x09] = new ORA_Immediate();
            InstructionsArray[0x0A] = new ASL_Accumulator();
            InstructionsArray[0x0D] = new ORA_Absolute();
            InstructionsArray[0x0E] = new ASL_Absolute();
            InstructionsArray[0x10] = new BPL();
            InstructionsArray[0x11] = new ORA_IndirectY();
            InstructionsArray[0x15] = new ORA_ZeroPageX();
            InstructionsArray[0x16] = new ASL_ZeroPageX();
            InstructionsArray[0x18] = new CLC();
            InstructionsArray[0x19] = new ORA_AbsoluteY();
            InstructionsArray[0x1D] = new ORA_AbsoluteX();
            InstructionsArray[0x1E] = new ASL_AbsoluteX();
            InstructionsArray[0x20] = new JSR();
            InstructionsArray[0x21] = new AND_IndirectX();
            InstructionsArray[0x24] = new BIT_ZeroPage();
            InstructionsArray[0x25] = new AND_ZeroPage();
            InstructionsArray[0x26] = new ROL_ZeroPage();
            InstructionsArray[0x28] = new PLP();
            InstructionsArray[0x29] = new AND_Immediate();
            InstructionsArray[0x2A] = new ROL_Accumulator();
            InstructionsArray[0x2C] = new BIT_Absolute();
            InstructionsArray[0x2D] = new AND_Absolute();
            InstructionsArray[0x2E] = new ROL_Absolute();
            InstructionsArray[0x30] = new BMI();
            InstructionsArray[0x31] = new AND_IndirectY();
            InstructionsArray[0x35] = new AND_ZeroPageX();
            InstructionsArray[0x36] = new ROL_ZeroPageX();
            InstructionsArray[0x38] = new SEC();
            InstructionsArray[0x39] = new AND_AbsoluteY();
            InstructionsArray[0x3D] = new AND_AbsoluteX();
            InstructionsArray[0x3E] = new ROL_AbsoluteX();
            InstructionsArray[0x40] = new RTI();
            InstructionsArray[0x41] = new EOR_IndirectX();
            InstructionsArray[0x45] = new EOR_ZeroPage();
            InstructionsArray[0x46] = new LSR_ZeroPage();
            InstructionsArray[0x48] = new PHA();
            InstructionsArray[0x49] = new EOR_Immediate();
            InstructionsArray[0x4A] = new LSR_Accumulator();
            InstructionsArray[0x4C] = new JMP_Absolute();
            InstructionsArray[0x4D] = new EOR_Absolute();
            InstructionsArray[0x4E] = new LSR_Absolute();
            InstructionsArray[0x50] = new BVC();
            InstructionsArray[0x51] = new EOR_IndirectY();
            InstructionsArray[0x55] = new EOR_ZeroPageX();
            InstructionsArray[0x56] = new LSR_ZeroPageX();
            InstructionsArray[0x58] = new CLI();
            InstructionsArray[0x59] = new EOR_AbsoluteY();
            InstructionsArray[0x5D] = new EOR_AbsoluteX();
            InstructionsArray[0x5E] = new LSR_AbsoluteX();
            InstructionsArray[0x60] = new RTS();
            InstructionsArray[0x61] = new ADC_IndirectX();
            InstructionsArray[0x65] = new ADC_ZeroPage();
            InstructionsArray[0x66] = new ROR_ZeroPage();
            InstructionsArray[0x68] = new PLA();
            InstructionsArray[0x69] = new ADC_Immediate();
            InstructionsArray[0x6A] = new ROR_Accumulator();
            InstructionsArray[0x6C] = new JMP_Indirect();
            InstructionsArray[0x6D] = new ADC_Absolute();
            InstructionsArray[0x6E] = new ROR_Absolute();
            InstructionsArray[0x70] = new BVS();
            InstructionsArray[0x71] = new ADC_IndirectY();
            InstructionsArray[0x75] = new ADC_ZeroPageX();
            InstructionsArray[0x76] = new ROR_ZeroPageX();
            InstructionsArray[0x78] = new SEI();
            InstructionsArray[0x79] = new ADC_AbsoluteY();
            InstructionsArray[0x7D] = new ADC_AbsoluteX();
            InstructionsArray[0x7E] = new ROR_AbsoluteX();
            InstructionsArray[0x81] = new STA_IndirectX();
            InstructionsArray[0x84] = new STY_ZeroPage();
            InstructionsArray[0x85] = new STA_ZeroPage();
            InstructionsArray[0x86] = new STX_ZeroPage();
            InstructionsArray[0x88] = new DEY();
            InstructionsArray[0x8A] = new TXA();
            InstructionsArray[0x8C] = new STY_Absolute();
            InstructionsArray[0x8D] = new STA_Absolute();
            InstructionsArray[0x8E] = new STX_Absolute();
            InstructionsArray[0x90] = new BCC();
            InstructionsArray[0x91] = new STA_IndirectY();
            InstructionsArray[0x94] = new STY_ZeroPageX();
            InstructionsArray[0x95] = new STA_ZeroPageX();
            InstructionsArray[0x96] = new STX_ZeroPageY();
            InstructionsArray[0x98] = new TYA();
            InstructionsArray[0x99] = new STA_AbsoluteY();
            InstructionsArray[0x9A] = new TXS();
            InstructionsArray[0x9D] = new STA_AbsoluteX();
            InstructionsArray[0xA0] = new LDY_Immediate();
            InstructionsArray[0xA1] = new LDA_IndirectX();
            InstructionsArray[0xA2] = new LDX_Immediate();
            InstructionsArray[0xA4] = new LDY_ZeroPage();
            InstructionsArray[0xA5] = new LDA_ZeroPage();
            InstructionsArray[0xA6] = new LDX_ZeroPage();
            InstructionsArray[0xA8] = new TAY();
            InstructionsArray[0xA9] = new LDA_Immediate();
            InstructionsArray[0xAA] = new TAX();
            InstructionsArray[0xAC] = new LDY_Absolute();
            InstructionsArray[0xAD] = new LDA_Absolute();
            InstructionsArray[0xAE] = new LDX_Absolute();
            InstructionsArray[0xB0] = new BCS();
            InstructionsArray[0xB1] = new LDA_IndirectY();
            InstructionsArray[0xB4] = new LDY_ZeroPageX();
            InstructionsArray[0xB5] = new LDA_ZeroPageX();
            InstructionsArray[0xB6] = new LDX_ZeroPageY();
            InstructionsArray[0xB8] = new CLV();
            InstructionsArray[0xB9] = new LDA_AbsoluteY();
            InstructionsArray[0xBA] = new TSX();
            InstructionsArray[0xBC] = new LDY_AbsoluteX();
            InstructionsArray[0xBD] = new LDA_AbsoluteX();
            InstructionsArray[0xBE] = new LDX_AbsoluteY();
            InstructionsArray[0xC0] = new CPY_Immediate();
            InstructionsArray[0xC1] = new CMP_IndirectX();
            InstructionsArray[0xC4] = new CPY_ZeroPage();
            InstructionsArray[0xC5] = new CMP_ZeroPage();
            InstructionsArray[0xC6] = new DEC_ZeroPage();
            InstructionsArray[0xC8] = new INY();
            InstructionsArray[0xC9] = new CMP_Immediate();
            InstructionsArray[0xCA] = new DEX();
            InstructionsArray[0xCC] = new CPY_Absolute();
            InstructionsArray[0xCD] = new CMP_Absolute();
            InstructionsArray[0xCE] = new DEC_Absolute();
            InstructionsArray[0xD0] = new BNE();
            InstructionsArray[0xD1] = new CMP_IndirectY();
            InstructionsArray[0xD5] = new CMP_ZeroPageX();
            InstructionsArray[0xD6] = new DEC_ZeroPageX();
            InstructionsArray[0xD8] = new CLD();
            InstructionsArray[0xD9] = new CMP_AbsoluteY();
            InstructionsArray[0xDD] = new CMP_AbsoluteX();
            InstructionsArray[0xDE] = new DEC_AbsoluteX();
            InstructionsArray[0xE0] = new CPX_Immediate();
            InstructionsArray[0xE1] = new SBC_IndirectX();
            InstructionsArray[0xE4] = new CPX_ZeroPage();
            InstructionsArray[0xE5] = new SBC_ZeroPage();
            InstructionsArray[0xE6] = new INC_ZeroPage();
            InstructionsArray[0xE8] = new INX();
            InstructionsArray[0xE9] = new SBC_Immediate();
            InstructionsArray[0xEA] = new NOP();
            InstructionsArray[0xEC] = new CPX_Absolute();
            InstructionsArray[0xED] = new SBC_Absolute();
            InstructionsArray[0xEE] = new INC_Absolute();
            InstructionsArray[0xF0] = new BEQ();
            InstructionsArray[0xF1] = new SBC_IndirectY();
            InstructionsArray[0xF5] = new SBC_ZeroPageX();
            InstructionsArray[0xF6] = new INC_ZeroPageX();
            InstructionsArray[0xF8] = new SED();
            InstructionsArray[0xF9] = new SBC_AbsoluteY();
            InstructionsArray[0xFD] = new SBC_AbsoluteX();
            InstructionsArray[0xFE] = new INC_AbsoluteX();

            for (int i = 0; i < 0xFF; ++i)
            {
                if(InstructionsArray[i] != null)
                {
                    if(InstructionsArray[i].OpCode != i)
                    {
                        Console.WriteLine("Error, i = 0x{0:x}, OpCode = 0x{1:x}", i, InstructionsArray[i].OpCode);
                    }
                }
            }
        }
    }
}
