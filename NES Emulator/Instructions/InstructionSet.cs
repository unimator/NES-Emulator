using System;

namespace NES_Emulator.Instructions
{
    public partial class InstructionSet
    {
        public Instruction[] InstructionsArray = new Instruction[0xFF];

        public Instruction this [int index]
        {
            get
            {
                if(index < 0xFF)
                {
                    return InstructionsArray[index];
                }
                else
                {
                    throw new Exception("Instruction out of set");
                }
            }
        }
    }
}
