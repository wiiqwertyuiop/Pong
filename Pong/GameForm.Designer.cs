namespace Pong
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.Clock = new System.Windows.Forms.Timer(this.components);
            this.P1Score = new System.Windows.Forms.Label();
            this.P2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Clock
            // 
            this.Clock.Enabled = true;
            this.Clock.Interval = 33;
            this.Clock.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // P1Score
            // 
            this.P1Score.AutoSize = true;
            this.P1Score.BackColor = System.Drawing.Color.Transparent;
            this.P1Score.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1Score.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.P1Score.Location = new System.Drawing.Point(155, 32);
            this.P1Score.Name = "P1Score";
            this.P1Score.Size = new System.Drawing.Size(36, 45);
            this.P1Score.TabIndex = 0;
            this.P1Score.Text = "0";
            // 
            // P2Score
            // 
            this.P2Score.AutoSize = true;
            this.P2Score.BackColor = System.Drawing.Color.Transparent;
            this.P2Score.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2Score.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.P2Score.Location = new System.Drawing.Point(429, 32);
            this.P2Score.Name = "P2Score";
            this.P2Score.Size = new System.Drawing.Size(36, 45);
            this.P2Score.TabIndex = 1;
            this.P2Score.Text = "0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.P2Score);
            this.Controls.Add(this.P1Score);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Clock;
        private System.Windows.Forms.Label P1Score;
        private System.Windows.Forms.Label P2Score;
    }
}

