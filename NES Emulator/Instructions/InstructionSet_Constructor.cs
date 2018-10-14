using System;

namespace NES_Emulator.Instructions
{
    public partial class InstructionSet
    {
        public InstructionSet(CPU cpu)
        {
            for (var i = 0; i < 0xFF; ++i)
            {
                InstructionsArray[i] = null;
            }

            InstructionsArray[0x00] = new BRK(cpu);
            InstructionsArray[0x01] = new ORA_IndirectX(cpu);
            InstructionsArray[0x05] = new ORA_ZeroPage(cpu);
            InstructionsArray[0x06] = new ASL_ZeroPage(cpu);
            InstructionsArray[0x08] = new PHP(cpu);
            InstructionsArray[0x09] = new ORA_Immediate(cpu);
            InstructionsArray[0x0A] = new ASL_Accumulator(cpu);
            InstructionsArray[0x0D] = new ORA_Absolute(cpu);
            InstructionsArray[0x0E] = new ASL_Absolute(cpu);
            InstructionsArray[0x10] = new BPL(cpu);
            InstructionsArray[0x11] = new ORA_IndirectY(cpu);
            InstructionsArray[0x15] = new ORA_ZeroPageX(cpu);
            InstructionsArray[0x16] = new ASL_ZeroPageX(cpu);
            InstructionsArray[0x18] = new CLC(cpu);
            InstructionsArray[0x19] = new ORA_AbsoluteY(cpu);
            InstructionsArray[0x1D] = new ORA_AbsoluteX(cpu);
            InstructionsArray[0x1E] = new ASL_AbsoluteX(cpu);
            InstructionsArray[0x20] = new JSR(cpu);
            InstructionsArray[0x21] = new AND_IndirectX(cpu);
            InstructionsArray[0x24] = new BIT_ZeroPage(cpu);
            InstructionsArray[0x25] = new AND_ZeroPage(cpu);
            InstructionsArray[0x26] = new ROL_ZeroPage(cpu);
            InstructionsArray[0x28] = new PLP(cpu);
            InstructionsArray[0x29] = new AND_Immediate(cpu);
            InstructionsArray[0x2A] = new ROL_Accumulator(cpu);
            InstructionsArray[0x2C] = new BIT_Absolute(cpu);
            InstructionsArray[0x2D] = new AND_Absolute(cpu);
            InstructionsArray[0x2E] = new ROL_Absolute(cpu);
            InstructionsArray[0x30] = new BMI(cpu);
            InstructionsArray[0x31] = new AND_IndirectY(cpu);
            InstructionsArray[0x35] = new AND_ZeroPageX(cpu);
            InstructionsArray[0x36] = new ROL_ZeroPageX(cpu);
            InstructionsArray[0x38] = new SEC(cpu);
            InstructionsArray[0x39] = new AND_AbsoluteY(cpu);
            InstructionsArray[0x3D] = new AND_AbsoluteX(cpu);
            InstructionsArray[0x3E] = new ROL_AbsoluteX(cpu);
            InstructionsArray[0x40] = new RTI(cpu);
            InstructionsArray[0x41] = new EOR_IndirectX(cpu);
            InstructionsArray[0x45] = new EOR_ZeroPage(cpu);
            InstructionsArray[0x46] = new LSR_ZeroPage(cpu);
            InstructionsArray[0x48] = new PHA(cpu);
            InstructionsArray[0x49] = new EOR_Immediate(cpu);
            InstructionsArray[0x4A] = new LSR_Accumulator(cpu);
            InstructionsArray[0x4C] = new JMP_Absolute(cpu);
            InstructionsArray[0x4D] = new EOR_Absolute(cpu);
            InstructionsArray[0x4E] = new LSR_Absolute(cpu);
            InstructionsArray[0x50] = new BVC(cpu);
            InstructionsArray[0x51] = new EOR_IndirectY(cpu);
            InstructionsArray[0x55] = new EOR_ZeroPageX(cpu);
            InstructionsArray[0x56] = new LSR_ZeroPageX(cpu);
            InstructionsArray[0x58] = new CLI(cpu);
            InstructionsArray[0x59] = new EOR_AbsoluteY(cpu);
            InstructionsArray[0x5D] = new EOR_AbsoluteX(cpu);
            InstructionsArray[0x5E] = new LSR_AbsoluteX(cpu);
            InstructionsArray[0x60] = new RTS(cpu);
            InstructionsArray[0x61] = new ADC_IndirectX(cpu);
            InstructionsArray[0x65] = new ADC_ZeroPage(cpu);
            InstructionsArray[0x66] = new ROR_ZeroPage(cpu);
            InstructionsArray[0x68] = new PLA(cpu);
            InstructionsArray[0x69] = new ADC_Immediate(cpu);
            InstructionsArray[0x6A] = new ROR_Accumulator(cpu);
            InstructionsArray[0x6C] = new JMP_Indirect(cpu);
            InstructionsArray[0x6D] = new ADC_Absolute(cpu);
            InstructionsArray[0x6E] = new ROR_Absolute(cpu);
            InstructionsArray[0x70] = new BVS(cpu);
            InstructionsArray[0x71] = new ADC_IndirectY(cpu);
            InstructionsArray[0x75] = new ADC_ZeroPageX(cpu);
            InstructionsArray[0x76] = new ROR_ZeroPageX(cpu);
            InstructionsArray[0x78] = new SEI(cpu);
            InstructionsArray[0x79] = new ADC_AbsoluteY(cpu);
            InstructionsArray[0x7D] = new ADC_AbsoluteX(cpu);
            InstructionsArray[0x7E] = new ROR_AbsoluteX(cpu);
            InstructionsArray[0x81] = new STA_IndirectX(cpu);
            InstructionsArray[0x84] = new STY_ZeroPage(cpu);
            InstructionsArray[0x85] = new STA_ZeroPage(cpu);
            InstructionsArray[0x86] = new STX_ZeroPage(cpu);
            InstructionsArray[0x88] = new DEY(cpu);
            InstructionsArray[0x8A] = new TXA(cpu);
            InstructionsArray[0x8C] = new STY_Absolute(cpu);
            InstructionsArray[0x8D] = new STA_Absolute(cpu);
            InstructionsArray[0x8E] = new STX_Absolute(cpu);
            InstructionsArray[0x90] = new BCC(cpu);
            InstructionsArray[0x91] = new STA_IndirectY(cpu);
            InstructionsArray[0x94] = new STY_ZeroPageX(cpu);
            InstructionsArray[0x95] = new STA_ZeroPageX(cpu);
            InstructionsArray[0x96] = new STX_ZeroPageY(cpu);
            InstructionsArray[0x98] = new TYA(cpu);
            InstructionsArray[0x99] = new STA_AbsoluteY(cpu);
            InstructionsArray[0x9A] = new TXS(cpu);
            InstructionsArray[0x9D] = new STA_AbsoluteX(cpu);
            InstructionsArray[0xA0] = new LDY_Immediate(cpu);
            InstructionsArray[0xA1] = new LDA_IndirectX(cpu);
            InstructionsArray[0xA2] = new LDX_Immediate(cpu);
            InstructionsArray[0xA4] = new LDY_ZeroPage(cpu);
            InstructionsArray[0xA5] = new LDA_ZeroPage(cpu);
            InstructionsArray[0xA6] = new LDX_ZeroPage(cpu);
            InstructionsArray[0xA8] = new TAY(cpu);
            InstructionsArray[0xA9] = new LDA_Immediate(cpu);
            InstructionsArray[0xAA] = new TAX(cpu);
            InstructionsArray[0xAC] = new LDY_Absolute(cpu);
            InstructionsArray[0xAD] = new LDA_Absolute(cpu);
            InstructionsArray[0xAE] = new LDX_Absolute(cpu);
            InstructionsArray[0xB0] = new BCS(cpu);
            InstructionsArray[0xB1] = new LDA_IndirectY(cpu);
            InstructionsArray[0xB4] = new LDY_ZeroPageX(cpu);
            InstructionsArray[0xB5] = new LDA_ZeroPageX(cpu);
            InstructionsArray[0xB6] = new LDX_ZeroPageY(cpu);
            InstructionsArray[0xB8] = new CLV(cpu);
            InstructionsArray[0xB9] = new LDA_AbsoluteY(cpu);
            InstructionsArray[0xBA] = new TSX(cpu);
            InstructionsArray[0xBC] = new LDY_AbsoluteX(cpu);
            InstructionsArray[0xBD] = new LDA_AbsoluteX(cpu);
            InstructionsArray[0xBE] = new LDX_AbsoluteY(cpu);
            InstructionsArray[0xC0] = new CPY_Immediate(cpu);
            InstructionsArray[0xC1] = new CMP_IndirectX(cpu);
            InstructionsArray[0xC4] = new CPY_ZeroPage(cpu);
            InstructionsArray[0xC5] = new CMP_ZeroPage(cpu);
            InstructionsArray[0xC6] = new DEC_ZeroPage(cpu);
            InstructionsArray[0xC8] = new INY(cpu);
            InstructionsArray[0xC9] = new CMP_Immediate(cpu);
            InstructionsArray[0xCA] = new DEX(cpu);
            InstructionsArray[0xCC] = new CPY_Absolute(cpu);
            InstructionsArray[0xCD] = new CMP_Absolute(cpu);
            InstructionsArray[0xCE] = new DEC_Absolute(cpu);
            InstructionsArray[0xD0] = new BNE(cpu);
            InstructionsArray[0xD1] = new CMP_IndirectY(cpu);
            InstructionsArray[0xD5] = new CMP_ZeroPageX(cpu);
            InstructionsArray[0xD6] = new DEC_ZeroPageX(cpu);
            InstructionsArray[0xD8] = new CLD(cpu);
            InstructionsArray[0xD9] = new CMP_AbsoluteY(cpu);
            InstructionsArray[0xDD] = new CMP_AbsoluteX(cpu);
            InstructionsArray[0xDE] = new DEC_AbsoluteX(cpu);
            InstructionsArray[0xE0] = new CPX_Immediate(cpu);
            InstructionsArray[0xE1] = new SBC_IndirectX(cpu);
            InstructionsArray[0xE4] = new CPX_ZeroPage(cpu);
            InstructionsArray[0xE5] = new SBC_ZeroPage(cpu);
            InstructionsArray[0xE6] = new INC_ZeroPage(cpu);
            InstructionsArray[0xE8] = new INX(cpu);
            InstructionsArray[0xE9] = new SBC_Immediate(cpu);
            InstructionsArray[0xEA] = new NOP(cpu);
            InstructionsArray[0xEC] = new CPX_Absolute(cpu);
            InstructionsArray[0xED] = new SBC_Absolute(cpu);
            InstructionsArray[0xEE] = new INC_Absolute(cpu);
            InstructionsArray[0xF0] = new BEQ(cpu);
            InstructionsArray[0xF1] = new SBC_IndirectY(cpu);
            InstructionsArray[0xF5] = new SBC_ZeroPageX(cpu);
            InstructionsArray[0xF6] = new INC_ZeroPageX(cpu);
            InstructionsArray[0xF8] = new SED(cpu);
            InstructionsArray[0xF9] = new SBC_AbsoluteY(cpu);
            InstructionsArray[0xFD] = new SBC_AbsoluteX(cpu);
            InstructionsArray[0xFE] = new INC_AbsoluteX(cpu);

            for (var i = 0; i < 0xFF; ++i)
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
