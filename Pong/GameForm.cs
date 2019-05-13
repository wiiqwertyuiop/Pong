using System;
using System.Media;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    public partial class GameForm : Form
    {
        /* Defines */
        int WhichPlayer = 0; // Tells which player we are. 0 = P1 (green), 1 = P2 (red)
        // Note: P1 is the host, P2 is the client

        int[] playerPos = { 158, 158 }; // P1 pos, P2 pos
        int[] PlayerSpeed = { 0, 0 };

        int BTTN = 0b00000000; // Player BTTN - RDxx xxLU
        int recent_dir = 0; // Most recent dir pressed
        // 0 = no recent button pressed, -1 = down, 1 = up

        // Paddle size
        int PlayerWidth = 3;
        int[] PlayerHeight = { 0, 0 };

        // Ball's position on the screen
        double ballXPos = 0;
        double ballYPos = 0;

        // Ball's base/max movement speed
        double ballBaseSpeed;

        // Ball's adjusted speed when actually traveling
        double ballXSpeed;
        double ballYSpeed = 0;

        // Keep track of score
        int P1Points = 0;
        int P2Points = 0;

        private Connection _connection;
        private System.Media.SoundPlayer hitsfx = new System.Media.SoundPlayer("c:/Windows/media/Speech Misrecognition.wav");
        private System.Media.SoundPlayer scoresfx = new System.Media.SoundPlayer("c:/Windows/media/Speech Sleep.wav");
        
        /* Prepare new game */
        public GameForm(Connection _c)
        {

            // Get the connection
            _connection = _c;

            InitializeComponent();
            this.Size = new Size(BitConverter.ToInt16(_connection.DataBuffer, 5 * sizeof(short)), BitConverter.ToInt16(_connection.DataBuffer, 6 * sizeof(short)));

            // Start ball in middle of screen
            ballXPos = this.ClientSize.Width / 2;
            ballYPos = this.ClientSize.Height / 2;

            // Position score counters
            P1Score.Left = (int)(this.ClientSize.Width * 0.25);
            P2Score.Left = (int)(this.ClientSize.Width * 0.75);

            PlayerHeight[0] = BitConverter.ToInt16(_connection.DataBuffer, 0 * sizeof(short));
            PlayerHeight[1] = BitConverter.ToInt16(_connection.DataBuffer, 1 * sizeof(short));

            PlayerSpeed[0] = BitConverter.ToInt16(_connection.DataBuffer, 2 * sizeof(short));
            PlayerSpeed[1] = BitConverter.ToInt16(_connection.DataBuffer, 3 * sizeof(short));
            ballBaseSpeed = BitConverter.ToInt16(_connection.DataBuffer, 4 * sizeof(short));

            ballXSpeed = -ballBaseSpeed;

            // Determine player by whether or not we are the host
            if (!_connection.Host)
            {
                WhichPlayer = 1;
                ballXSpeed = 0; // Don't move P2's ball until P1 is ready
                ballYSpeed = 0;
            }
        }

        /** Draw screen **/
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Create pens
            Pen BallPen = new Pen(Color.White, 4.5f);
            Pen PlayerPen = new Pen(Color.FromArgb(22, 160, 133), PlayerWidth);

            // Draw P1
            Rectangle rect = new Rectangle(20, playerPos[0], PlayerWidth, PlayerHeight[0]);
            e.Graphics.DrawRectangle(PlayerPen, rect);

            // Draw P2
            PlayerPen.Color = Color.FromArgb(192, 57, 43);
            rect = new Rectangle(this.ClientSize.Width-20, playerPos[1], PlayerWidth, PlayerHeight[1]);
            e.Graphics.DrawRectangle(PlayerPen, rect);

            // Draw ball
            rect = new Rectangle((int)ballXPos, (int)ballYPos, 5, 4);
            e.Graphics.DrawEllipse(BallPen, rect);

            // Draw board
            BallPen.DashPattern = new float[] { 2.0F, 2.0F }; // reuse ball pen
            e.Graphics.DrawLine(BallPen, this.ClientSize.Width/2, 0, this.ClientSize.Width/2, this.ClientSize.Height);

            // Update score
            P1Score.Text = P1Points.ToString();
            P2Score.Text = P2Points.ToString();

            // Clean up
            PlayerPen.Dispose();
            BallPen.Dispose();
        }

        /** Clock tick
         *     aka 
         *  Game Update 
         **/
        private void Clock_Tick(object sender, EventArgs e)
        {
            // Handle paddle movement
            if ((BTTN & 0b00000011) != 0 && recent_dir != -1 && playerPos[WhichPlayer] > 10) playerPos[WhichPlayer] -= PlayerSpeed[WhichPlayer];
            else if ((BTTN & 0b11000000) != 0 && recent_dir != 1 && playerPos[WhichPlayer] + PlayerHeight[WhichPlayer] < this.ClientSize.Height - 20) playerPos[WhichPlayer] += PlayerSpeed[WhichPlayer];

            // Host (P1) takes care of ball/player interaction
            if (_connection.Host) HandleBall();

            // Move ball
            if (ballYPos+ballYSpeed <= 5 || ballYPos+ballYSpeed >= this.ClientSize.Height - 10)
            {
                ballYSpeed = -ballYSpeed;
                hitsfx.Play();
            }
            ballXPos += ballXSpeed;
            ballYPos += ballYSpeed;

            // Update everything
            HandleConnection();
            Invalidate();
        }

        private void HandleBall()
        {
            // Check for ball paddle collision for both players
            for (int p = 0; p != 2; p++)
            {
                double angle = (ballYPos - playerPos[p]) / PlayerHeight[p] * Math.PI;
                double ballAdjustedXpos = (p == 1) ? this.ClientSize.Width - ballXPos : ballXPos;

                // See if it is touching a paddle
                if ((ballAdjustedXpos > 8 && ballAdjustedXpos <= 27.5) && (angle > 0 && angle < 3.14))
                {
                    if (angle < 0.4) angle = 0.4;
                    else if (angle > 2.8) angle = 2.8;

                    ballXSpeed = Math.Round((Math.Sin(angle) * ballBaseSpeed), 3);
                    if (p == 1) ballXSpeed *= -1; // Flip X-speed if it was P2 that was hit

                    ballYSpeed = Math.Round(Math.Cos(angle) * ballBaseSpeed, 3);
                    hitsfx.Play();
                    break; // No need to continue any more since the ball can't be over by the other player if it is here
                } else if (ballAdjustedXpos < 8)
                {
                    // P1's score handler
                    if (p == 0) P2Points++;
                    else P1Points++;

                    // If the ball leaves the screen, start it in the middle of the screen
                    ballXPos = this.ClientSize.Width / 2;
                    ballYPos = this.ClientSize.Height / 2;
                    // Invert speed
                    ballXSpeed *= -1;
                    ballYSpeed *= -1;
                    scoresfx.Play();
                    break; // No need to continue
                }
            }
        }

        /** Handle input **/
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                recent_dir = 1;
                BTTN |= 0b00000001;
            } else if (e.KeyCode == Keys.Left)
            {
                recent_dir = 1;
                BTTN |= 0b00000010;
            }
            else if (e.KeyCode == Keys.Down)
            {
                recent_dir = -1;
                BTTN |= 0b01000000;
            } else if (e.KeyCode == Keys.Right)
            {
                recent_dir = -1;
                BTTN |= 0b10000000;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) BTTN &= 0b11111110;
            else if (e.KeyCode == Keys.Left) BTTN &= 0b11111101;
            else if (e.KeyCode == Keys.Down) BTTN &= 0b10111111;
            else if (e.KeyCode == Keys.Right) BTTN &= 0b01111111;
            recent_dir = 0; // Clear recently pressed
        }

        /** Handle connection **/

        private int TimeOut = 0;
        private byte pckNumb = 1;

        private void HandleConnection()
        {
            byte[] outgoing = new byte[39];

            // Create packet
            outgoing[0] = pckNumb;
            Buffer.BlockCopy(BitConverter.GetBytes((Int16)playerPos[WhichPlayer]), 0, outgoing, 1, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(ballXSpeed), 0, outgoing, 1 + 2, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(ballYSpeed), 0, outgoing, 1 +2 + 8, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(ballXPos), 0, outgoing, 1 +2 + (8*2), 8);
            Buffer.BlockCopy(BitConverter.GetBytes(ballYPos), 0, outgoing, 1+2+ (8 * 3), 8);
            Buffer.BlockCopy(BitConverter.GetBytes((Int16)P1Points), 0, outgoing, 1+2+ (8 * 4), 2);
            Buffer.BlockCopy(BitConverter.GetBytes((Int16)P2Points), 0, outgoing, 1+2+(8 * 4)+ 2, 2);

            if (_connection.Update(outgoing))
            {
                // If we are still connected don't time out 
                TimeOut = 0;

                // if client update ball pos and p1 pos
                // if host just update p2 pos
                if (_connection.Host) playerPos[1] = BitConverter.ToInt16(_connection.DataBuffer, 1);
                else
                {
                    playerPos[0] = BitConverter.ToInt16(_connection.DataBuffer, 1);
                    double newballXSpeed = BitConverter.ToDouble(_connection.DataBuffer, 1 + 2);
                    double newballYSpeed = BitConverter.ToDouble(_connection.DataBuffer, 1 + 2 + 8);

                    // If the ball changed direction update everything for the client
                    if (newballXSpeed != ballXSpeed || newballYSpeed != ballYSpeed)
                    {
                        int tempPoints = P1Points + P2Points;

                        P1Points = BitConverter.ToInt16(_connection.DataBuffer, 1 + 2 + (8 * 4));
                        P2Points = BitConverter.ToInt16(_connection.DataBuffer, 1 + 2 + (8 * 4) + 2);

                        // Check if the ball changed directions
                        bool changeDirection = ((ballXSpeed > 0 && newballXSpeed > 0) || (ballXSpeed < 0 && newballXSpeed < 0)) &&
                            ((ballYSpeed > 0 && newballYSpeed > 0) || (ballYSpeed < 0 && newballYSpeed < 0));

                        // Play SFX
                        if (P1Points + P2Points > tempPoints) scoresfx.Play();
                        else if (!changeDirection) hitsfx.Play();

                        ballXSpeed = newballXSpeed;
                        ballYSpeed = newballYSpeed;

                        ballXPos = BitConverter.ToDouble(_connection.DataBuffer, 1 + 2 + (8 * 2));
                        ballYPos = BitConverter.ToDouble(_connection.DataBuffer, 1 + 2 + (8 * 3));
                    }
                }
            } else
            {
                // Check if we timed out
                if (TimeOut == (1000 * 3) / 30)
                {
                    Clock.Enabled = false;
                    SystemSounds.Asterisk.Play();
                    if (_connection.Host) MessageBox.Show("Lost connection to player!");
                    else MessageBox.Show("Lost connection to the host!");
                    this.Close();
                }
                TimeOut++;

                // Slow ball down if we lost a packet
                if (!_connection.Host)
                {
                    ballXSpeed *= 0.5;
                    ballYSpeed *= 0.5;
                }
            }
            // Increase packet number
            pckNumb++;
        }

        /** Close out **/
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hitsfx.Dispose();
            scoresfx.Dispose();
            _connection.Close();
            Application.Exit();
        }
    }
}
