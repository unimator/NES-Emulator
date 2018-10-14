using System;
using System.Windows.Forms;
using NESEmulator;

namespace NES_Emulator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            NesROM nesRom = null;
            using (var openFileDialog = new OpenFileDialog())
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    nesRom = new NesROM(openFileDialog.FileName);
                }
            }

            if (nesRom != null)
            {
                var nes = new NES.NES(nesRom);
                MainLoop();
            }
            
            Console.ReadKey();
        }
    }
}
