using NES_Emulator.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES_Emulator
{
    public partial class InstructionSet
    {
        public Instruction[] Instructions = new Instruction[0xFF];

        public Instruction this [int index]
        {
            get
            {
                if(index < 0xFF)
                {
                    return Instructions[index];
                }
                else
                {
                    throw new Exception("Instruction out of set");
                }
            }
        }
    }
}
