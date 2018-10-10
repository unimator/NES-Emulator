namespace NES_Emulator
{
    partial class Display
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPPU = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelPPU
            // 
            this.panelPPU.Location = new System.Drawing.Point(13, 13);
            this.panelPPU.Name = "panelPPU";
            this.panelPPU.Size = new System.Drawing.Size(512, 480);
            this.panelPPU.TabIndex = 0;
            this.panelPPU.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPPU_Paint);
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 504);
            this.Controls.Add(this.panelPPU);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Display";
            this.Text = "Display";
            this.Load += new System.EventHandler(this.Display_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPPU;
    }
}