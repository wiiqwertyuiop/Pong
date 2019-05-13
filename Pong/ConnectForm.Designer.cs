namespace Pong
{
    partial class ConnectForm
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
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.HostBttn = new System.Windows.Forms.Button();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.ConnectBttn = new System.Windows.Forms.Button();
            this.PortText = new System.Windows.Forms.Label();
            this.IPText = new System.Windows.Forms.Label();
            this.msgBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.BoardWidthBox = new System.Windows.Forms.TextBox();
            this.BoaradHeightBox = new System.Windows.Forms.TextBox();
            this.P1SizeBox = new System.Windows.Forms.TextBox();
            this.P2SizeBox = new System.Windows.Forms.TextBox();
            this.P1SpeedBox = new System.Windows.Forms.TextBox();
            this.P2SpeedBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BallSpeedBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(136, 23);
            this.PortTextBox.MaxLength = 5;
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(118, 22);
            this.PortTextBox.TabIndex = 0;
            // 
            // HostBttn
            // 
            this.HostBttn.Location = new System.Drawing.Point(302, 19);
            this.HostBttn.Name = "HostBttn";
            this.HostBttn.Size = new System.Drawing.Size(141, 30);
            this.HostBttn.TabIndex = 1;
            this.HostBttn.Text = "Host";
            this.HostBttn.UseVisualStyleBackColor = true;
            this.HostBttn.Click += new System.EventHandler(this.HostBttn_Click);
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(136, 67);
            this.IPTextBox.MaxLength = 15;
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(118, 22);
            this.IPTextBox.TabIndex = 2;
            // 
            // ConnectBttn
            // 
            this.ConnectBttn.Location = new System.Drawing.Point(302, 63);
            this.ConnectBttn.Name = "ConnectBttn";
            this.ConnectBttn.Size = new System.Drawing.Size(141, 30);
            this.ConnectBttn.TabIndex = 3;
            this.ConnectBttn.Text = "Connect";
            this.ConnectBttn.UseVisualStyleBackColor = true;
            this.ConnectBttn.Click += new System.EventHandler(this.ConnectBttn_Click);
            // 
            // PortText
            // 
            this.PortText.AutoSize = true;
            this.PortText.Location = new System.Drawing.Point(92, 23);
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(38, 17);
            this.PortText.TabIndex = 4;
            this.PortText.Text = "Port:";
            // 
            // IPText
            // 
            this.IPText.AutoSize = true;
            this.IPText.Location = new System.Drawing.Point(50, 67);
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(80, 17);
            this.IPText.TabIndex = 5;
            this.IPText.Text = "IP Address:";
            // 
            // msgBox
            // 
            this.msgBox.DetectUrls = false;
            this.msgBox.Location = new System.Drawing.Point(12, 126);
            this.msgBox.Name = "msgBox";
            this.msgBox.ReadOnly = true;
            this.msgBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.msgBox.Size = new System.Drawing.Size(479, 39);
            this.msgBox.TabIndex = 6;
            this.msgBox.TabStop = false;
            this.msgBox.Text = "Pong v2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Info:";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Host options:";
            // 
            // BoardWidthBox
            // 
            this.BoardWidthBox.Location = new System.Drawing.Point(356, 249);
            this.BoardWidthBox.MaxLength = 3;
            this.BoardWidthBox.Name = "BoardWidthBox";
            this.BoardWidthBox.Size = new System.Drawing.Size(66, 22);
            this.BoardWidthBox.TabIndex = 9;
            this.BoardWidthBox.TabStop = false;
            this.BoardWidthBox.Text = "453";
            // 
            // BoaradHeightBox
            // 
            this.BoaradHeightBox.Location = new System.Drawing.Point(356, 277);
            this.BoaradHeightBox.MaxLength = 3;
            this.BoaradHeightBox.Name = "BoaradHeightBox";
            this.BoaradHeightBox.Size = new System.Drawing.Size(66, 22);
            this.BoaradHeightBox.TabIndex = 10;
            this.BoaradHeightBox.TabStop = false;
            this.BoaradHeightBox.Text = "497";
            // 
            // P1SizeBox
            // 
            this.P1SizeBox.Location = new System.Drawing.Point(136, 221);
            this.P1SizeBox.MaxLength = 3;
            this.P1SizeBox.Name = "P1SizeBox";
            this.P1SizeBox.Size = new System.Drawing.Size(66, 22);
            this.P1SizeBox.TabIndex = 11;
            this.P1SizeBox.TabStop = false;
            this.P1SizeBox.Text = "50";
            // 
            // P2SizeBox
            // 
            this.P2SizeBox.Location = new System.Drawing.Point(136, 249);
            this.P2SizeBox.MaxLength = 3;
            this.P2SizeBox.Name = "P2SizeBox";
            this.P2SizeBox.Size = new System.Drawing.Size(66, 22);
            this.P2SizeBox.TabIndex = 12;
            this.P2SizeBox.TabStop = false;
            this.P2SizeBox.Text = "50";
            // 
            // P1SpeedBox
            // 
            this.P1SpeedBox.Location = new System.Drawing.Point(136, 277);
            this.P1SpeedBox.MaxLength = 3;
            this.P1SpeedBox.Name = "P1SpeedBox";
            this.P1SpeedBox.Size = new System.Drawing.Size(66, 22);
            this.P1SpeedBox.TabIndex = 13;
            this.P1SpeedBox.TabStop = false;
            this.P1SpeedBox.Text = "10";
            // 
            // P2SpeedBox
            // 
            this.P2SpeedBox.Location = new System.Drawing.Point(136, 305);
            this.P2SpeedBox.MaxLength = 3;
            this.P2SpeedBox.Name = "P2SpeedBox";
            this.P2SpeedBox.Size = new System.Drawing.Size(66, 22);
            this.P2SpeedBox.TabIndex = 14;
            this.P2SpeedBox.TabStop = false;
            this.P2SpeedBox.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "P1 Speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "P2 Speed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "P1 Size:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "P2 Size:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ball Speed:";
            // 
            // BallSpeedBox
            // 
            this.BallSpeedBox.Location = new System.Drawing.Point(356, 221);
            this.BallSpeedBox.MaxLength = 3;
            this.BallSpeedBox.Name = "BallSpeedBox";
            this.BallSpeedBox.Size = new System.Drawing.Size(66, 22);
            this.BallSpeedBox.TabIndex = 19;
            this.BallSpeedBox.TabStop = false;
            this.BallSpeedBox.Text = "17";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Board Width:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(255, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Board Height:";
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 187);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BallSpeedBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.P2SpeedBox);
            this.Controls.Add(this.P1SpeedBox);
            this.Controls.Add(this.P2SizeBox);
            this.Controls.Add(this.P1SizeBox);
            this.Controls.Add(this.BoaradHeightBox);
            this.Controls.Add(this.BoardWidthBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.IPText);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.ConnectBttn);
            this.Controls.Add(this.IPTextBox);
            this.Controls.Add(this.HostBttn);
            this.Controls.Add(this.PortTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(521, 411);
            this.MinimumSize = new System.Drawing.Size(521, 200);
            this.Name = "ConnectForm";
            this.Text = "Pong";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Button HostBttn;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Button ConnectBttn;
        private System.Windows.Forms.Label PortText;
        private System.Windows.Forms.Label IPText;
        private System.Windows.Forms.RichTextBox msgBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoardWidthBox;
        private System.Windows.Forms.TextBox BoaradHeightBox;
        private System.Windows.Forms.TextBox P1SizeBox;
        private System.Windows.Forms.TextBox P2SizeBox;
        private System.Windows.Forms.TextBox P1SpeedBox;
        private System.Windows.Forms.TextBox P2SpeedBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BallSpeedBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}