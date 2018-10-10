using System;
using System.Drawing;
using System.Windows.Forms;
using NES_Emulator.Memory;

namespace NES_Emulator
{
    public partial class MainWindow : Form
    {
        Brush[] palette;
        byte[] RAM;

        public MainWindow(CPUMemory memory)
        {
            InitializeComponent();
            this.RAM = memory.Memory;
            palette = new Brush[0x10];
            palette[0x0] = new SolidBrush(Color.Black);
            palette[0x1] = new SolidBrush(Color.White);
            palette[0x2] = new SolidBrush(Color.Red);
            palette[0x3] = new SolidBrush(Color.Cyan);
            palette[0x4] = new SolidBrush(Color.Purple);
            palette[0x5] = new SolidBrush(Color.Green);
            palette[0x6] = new SolidBrush(Color.Blue);
            palette[0x7] = new SolidBrush(Color.Yellow);
            palette[0x8] = new SolidBrush(Color.Orange);
            palette[0x9] = new SolidBrush(Color.Brown);
            palette[0xA] = new SolidBrush(Color.OrangeRed);
            palette[0xB] = new SolidBrush(Color.DarkGray);
            palette[0xC] = new SolidBrush(Color.Gray);
            palette[0xD] = new SolidBrush(Color.LightGreen);
            palette[0xE] = new SolidBrush(Color.LightBlue);
            palette[0xF] = new SolidBrush(Color.LightGray);
        }

        public void Draw()
        {
            Graphics g = panel.CreateGraphics();
            Pen p = new Pen(Color.Azure);
            byte color;

            for(int i = 0; i < 32; ++i)
            {
                for(int j = 0; j < 32; ++j)
                {
                    color = RAM[0x200 + i * 32 + j];
                    if (color > 0xF)
                    {
                        color = 0x0;
                    }
                    g.FillRectangle(palette[color], j*8, i*8, 8, 8);
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (5); // 10 secs
            timer.Tick += new EventHandler(panel_Paint);
            timer.Start();
        }

        private void panel_Paint(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
