using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    public partial class ConnectForm : Form
    {

        private Connection _c = null;
        bool StartGame = false;
        byte[] outgoing;

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void HostBttn_Click(object sender, EventArgs e)
        {
            int port;

            if (timer1.Enabled)
            {
                ClearConnection();
                timer1.Enabled = false;
            }

            if (this.Size.Height < 300)
            {
                this.Size = new Size(521, 380);
                msgBox.Text = "Set game options then click \"Host\" again to host game.";
            }
            else if (int.TryParse(PortTextBox.Text, out port) && port > 0 && port <= 65535)
            {
                short[] Options = new short[7];
                if (short.TryParse(P1SizeBox.Text, out Options[0]) &&
                    short.TryParse(P2SizeBox.Text, out Options[1]) &&
                    short.TryParse(P1SpeedBox.Text, out Options[2]) &&
                    short.TryParse(P2SpeedBox.Text, out Options[3]) &&
                    short.TryParse(BallSpeedBox.Text, out Options[4]) &&
                    short.TryParse(BoardWidthBox.Text, out Options[5]) &&
                    short.TryParse(BoaradHeightBox.Text, out Options[6]))
                {
                    if (Options[0] < 0 || Options[1] < 0) msgBox.Text = "Player height can't be less than zero";
                    else
                    {
                        outgoing = new byte[sizeof(short) * 7];
                        Buffer.BlockCopy(Options, 0, outgoing, 0, outgoing.Length);

                        // Start connection as the host
                        _c = new Connection(port);
                        timer1.Enabled = true;
                        msgBox.Text = "Waiting for other player...";
                    }
                }
                else msgBox.Text = "One of your game options is wrong. Please only enter numbers into the boxes.";
            } else msgBox.Text = "Invalid port.";
        }

        private void ConnectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!StartGame) Application.Exit();
        }

        private void ConnectBttn_Click(object sender, EventArgs e)
        {
            string ip = IPTextBox.Text;
            int port;

            if (timer1.Enabled)
            {
                ClearConnection();
                timer1.Enabled = false;
            }
               
            if (ValidateIPv4(ip) && int.TryParse(PortTextBox.Text, out port) && port > 0 && port <= 65535)
            {

                outgoing = new byte[sizeof(short) * 7];
                Buffer.BlockCopy(new short[7], 0, outgoing, 0, outgoing.Length);

                // Start connection as the client, connect to the host
                _c = new Connection(ip, port);
                timer1.Enabled = true;
                msgBox.Text = "Trying to connect...";
            } else msgBox.Text = "Invalid host!";     
        }

        public bool ValidateIPv4(string input)
        {
            if (input == "127.0.0.1") return true; // DEBUG CODE

            string[] split_array = input.Split('.');
            if (split_array.Length != 4) return false;

            foreach (string ip_part in split_array)
            {
                uint temp = uint.Parse(ip_part);
                if ((temp > 255 || temp < 1) || ip_part.Length > 3) return false;
            }
            return true;
        }


        private int ConnectionAttempts = 4;

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (_c.Initalize(outgoing))
            {
                StartGame = true;
                new GameForm(_c).Show();
                this.Close();
            } else
            {
                // If we haven't recieved ANY data yet (ie we are the Host), keep the gate open and wait for a connection
                if(_c.DataBuffer != null) ConnectionAttempts--;
                if (ConnectionAttempts == 0)
                {
                    timer1.Enabled = false;
                    ClearConnection();
                    msgBox.Text = "Couldn't establish a connection!";
                }
            }
        }

        private void ClearConnection()
        {
            _c.Close();
            ConnectionAttempts = 4;
        }
    }
}
