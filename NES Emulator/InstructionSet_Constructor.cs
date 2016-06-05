using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NES_Emulator.Instructions;

namespace NES_Emulator
{
    public partial class InstructionSet
    {
        public InstructionSet()
        {
            for (int i = 0; i < 0xFF; ++i)
            {
                Instructions[i] = null;
            }

            Instructions[0x00] = new BRK();
            Instructions[0x01] = new ORA_IndirectX();
            Instructions[0x05] = new ORA_ZeroPage();
            Instructions[0x06] = new ASL_ZeroPage();
            Instructions[0x08] = new PHP();
            Instructions[0x09] = new ORA_Immediate();
            Instructions[0x0A] = new ASL_Accumulator();
            Instructions[0x0D] = new ORA_Absolute();
            Instructions[0x0E] = new ASL_Absolute();
            Instructions[0x10] = new BPL();
            Instructions[0x11] = new ORA_IndirectY();
            Instructions[0x15] = new ORA_ZeroPageX();
            Instructions[0x16] = new ASL_ZeroPageX();
            Instructions[0x18] = new CLC();
            Instructions[0x19] = new ORA_AbsoluteY();
            Instructions[0x1D] = new ORA_AbsoluteX();
            Instructions[0x1E] = new ASL_AbsoluteX();
            Instructions[0x20] = new JSR();
            Instructions[0x21] = new AND_IndirectX();
            Instructions[0x24] = new BIT_ZeroPage();
            Instructions[0x25] = new AND_ZeroPage();
            Instructions[0x26] = new ROL_ZeroPage();
            Instructions[0x28] = new PLP();
            Instructions[0x29] = new AND_Immediate();
            Instructions[0x2A] = new ROL_Accumulator();
            Instructions[0x2C] = new BIT_Absolute();
            Instructions[0x2D] = new AND_Absolute();
            Instructions[0x2E] = new ROL_Absolute();
            Instructions[0x30] = new BMI();
            Instructions[0x31] = new AND_IndirectY();
            Instructions[0x35] = new AND_ZeroPageX();
            Instructions[0x36] = new ROL_ZeroPageX();
            Instructions[0x38] = new SEC();
            Instructions[0x39] = new AND_AbsoluteY();
            Instructions[0x3D] = new AND_AbsoluteX();
            Instructions[0x3E] = new ROL_AbsoluteX();
            Instructions[0x40] = new RTI();
            Instructions[0x41] = new EOR_IndirectX();
            Instructions[0x45] = new EOR_ZeroPage();
            Instructions[0x46] = new LSR_ZeroPage();
            Instructions[0x48] = new PHA();
            Instructions[0x49] = new EOR_Immediate();
            Instructions[0x4A] = new LSR_Accumulator();
            Instructions[0x4C] = new JMP_Absolute();
            Instructions[0x4D] = new EOR_Absolute();
            Instructions[0x4E] = new LSR_Absolute();
            Instructions[0x50] = new BVC();
            Instructions[0x51] = new EOR_IndirectY();
            Instructions[0x55] = new EOR_ZeroPageX();
            Instructions[0x56] = new LSR_ZeroPageX();
            Instructions[0x58] = new CLI();
            Instructions[0x59] = new EOR_AbsoluteY();
            Instructions[0x5D] = new EOR_AbsoluteX();
            Instructions[0x5E] = new LSR_AbsoluteX();
            Instructions[0x60] = new RTS();
            Instructions[0x61] = new ADC_IndirectX();
            Instructions[0x65] = new ADC_ZeroPage();
            Instructions[0x66] = new ROR_ZeroPage();
            Instructions[0x68] = new PLA();
            Instructions[0x69] = new ADC_Immediate();
            Instructions[0x6A] = new ROR_Accumulator();
            Instructions[0x6C] = new JMP_Indirect();
            Instructions[0x6D] = new ADC_Absolute();
            Instructions[0x6E] = new ROR_Absolute();
            Instructions[0x70] = new BVS();
            Instructions[0x71] = new ADC_IndirectY();
            Instructions[0x75] = new ADC_ZeroPageX();
            Instructions[0x76] = new ROR_ZeroPageX();
            Instructions[0x78] = new SEI();
            Instructions[0x79] = new ADC_AbsoluteY();
            Instructions[0x7D] = new ADC_AbsoluteX();
            Instructions[0x7E] = new ROR_AbsoluteX();
            Instructions[0x81] = new STA_IndirectX();
            Instructions[0x84] = new STY_ZeroPage();
            Instructions[0x85] = new STA_ZeroPage();
            Instructions[0x86] = new STX_ZeroPage();
            Instructions[0x88] = new DEY();
            Instructions[0x8A] = new TXA();
            Instructions[0x8C] = new STY_Absolute();
            Instructions[0x8D] = new STA_Absolute();
            Instructions[0x8E] = new STX_Absolute();
            Instructions[0x90] = new BCC();
            Instructions[0x91] = new STA_IndirectY();
            Instructions[0x94] = new STY_ZeroPageX();
            Instructions[0x95] = new STA_ZeroPageX();
            Instructions[0x96] = new STX_ZeroPageY();
            Instructions[0x98] = new TYA();
            Instructions[0x99] = new STA_AbsoluteY();
            Instructions[0x9A] = new TXS();
            Instructions[0x9D] = new STA_AbsoluteX();
            Instructions[0xA0] = new LDY_Immediate();
            Instructions[0xA1] = new LDA_IndirectX();
            Instructions[0xA2] = new LDX_Immediate();
            Instructions[0xA4] = new LDY_ZeroPage();
            Instructions[0xA5] = new LDA_ZeroPage();
            Instructions[0xA6] = new LDX_ZeroPage();
            Instructions[0xA8] = new TAY();
            Instructions[0xA9] = new LDA_Immediate();
            Instructions[0xAA] = new TAX();
            Instructions[0xAC] = new LDY_Absolute();
            Instructions[0xAD] = new LDA_Absolute();
            Instructions[0xAE] = new LDX_Absolute();
            Instructions[0xB0] = new BCS();
            Instructions[0xB1] = new LDA_IndirectY();
            Instructions[0xB4] = new LDY_ZeroPageX();
            Instructions[0xB5] = new LDA_ZeroPageX();
            Instructions[0xB6] = new LDX_ZeroPageY();
            Instructions[0xB8] = new CLV();
            Instructions[0xB9] = new LDA_AbsoluteY();
            Instructions[0xBA] = new TSX();
            Instructions[0xBC] = new LDY_AbsoluteX();
            Instructions[0xBD] = new LDA_AbsoluteX();
            Instructions[0xBE] = new LDX_AbsoluteY();
            Instructions[0xC0] = new CPY_Immediate();
            Instructions[0xC1] = new CMP_IndirectX();
            Instructions[0xC4] = new CPY_ZeroPage();
            Instructions[0xC5] = new CMP_ZeroPage();
            Instructions[0xC6] = new DEC_ZeroPage();
            Instructions[0xC8] = new INY();
            Instructions[0xC9] = new CMP_Immediate();
            Instructions[0xCA] = new DEX();
            Instructions[0xCC] = new CPY_Absolute();
            Instructions[0xCD] = new CMP_Absolute();
            Instructions[0xCE] = new DEC_Absolute();
            Instructions[0xD0] = new BNE();
            Instructions[0xD1] = new CMP_IndirectY();
            Instructions[0xD5] = new CMP_ZeroPageX();
            Instructions[0xD6] = new DEC_ZeroPageX();
            Instructions[0xD8] = new CLD();
            Instructions[0xD9] = new CMP_AbsoluteY();
            Instructions[0xDD] = new CMP_AbsoluteX();
            Instructions[0xDE] = new DEC_AbsoluteX();
            Instructions[0xE0] = new CPX_Immediate();
            Instructions[0xE1] = new SBC_IndirectX();
            Instructions[0xE4] = new CPX_ZeroPage();
            Instructions[0xE5] = new SBC_ZeroPage();
            Instructions[0xE6] = new INC_ZeroPage();
            Instructions[0xE8] = new INX();
            Instructions[0xE9] = new SBC_Immediate();
            Instructions[0xEA] = new NOP();
            Instructions[0xEC] = new CPX_Absolute();
            Instructions[0xED] = new SBC_Absolute();
            Instructions[0xEE] = new INC_Absolute();
            Instructions[0xF0] = new BEQ();
            Instructions[0xF1] = new SBC_IndirectY();
            Instructions[0xF5] = new SBC_ZeroPageX();
            Instructions[0xF6] = new INC_ZeroPageX();
            Instructions[0xF8] = new SED();
            Instructions[0xF9] = new SBC_AbsoluteY();
            Instructions[0xFD] = new SBC_AbsoluteX();
            Instructions[0xFE] = new INC_AbsoluteX();

            for (int i = 0; i < 0xFF; ++i)
            {
                if(Instructions[i] != null)
                {
                    if(Instructions[i].OPCode != i)
                    {
                        Console.WriteLine("Error, i = 0x{0:x}, OPCode = 0x{1:x}", i, Instructions[i].OPCode);
                    }
                }
            }
        }
    }
}
