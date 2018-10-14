using System;
using System.Drawing;
using System.Windows.Forms;
using NES_Emulator.Memory;

namespace NES_Emulator
{
    public partial class Display : Form
    {
        byte[] RAM;

        public Display(PPUMemory memory)
        {
            InitializeComponent();
            this.RAM = memory.Memory;
        }

        public void Draw()
        {
            Graphics g = panelPPU.CreateGraphics();
            Pen p = new Pen(Color.Azure);
            byte color;

            
        }

        private void panelPPU_Paint(object sender, EventArgs e)
        {
            Draw();
        }

        private void Display_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (5); // 10 secs
            timer.Tick += new EventHandler(panelPPU_Paint);
            timer.Start();
        }
    }
}
