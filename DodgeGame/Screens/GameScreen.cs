using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystemServices;
using System.Threading;
using System.Media; 

namespace DodgeGame
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        //TODO create your global game variables here
        int heroX, heroY, heroSize, heroSpeed;
        SolidBrush heroBrush = new SolidBrush(Color.Blue);
        SolidBrush npcBrush = new SolidBrush(Color.White);
        SoundPlayer player = new SoundPlayer(Properties.Resources.Game_wav);
        List<Point> npc = new List<Point>();
        Random randGen = new Random();
        int conterscore = 0; 
        int counter = 0;

        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method0
            // each time you restart your game to reset all values.
            heroX = 100;
            heroY = 100;
            heroSize = 20;
            heroSpeed = 5;
            npc.Add(new Point(100, 5));
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }

            //TODO - basic player 1 key down bools set below. Add remainging key down
            // required for player 1 or player 2 here.

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO - basic player 1 key up bools set below. Add remainging key up
            // required for player 1 or player 2 here.

            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //TODO move main character 
            if (leftArrowDown == true && heroX > 0)
            {
                heroX = heroX - heroSpeed;
            }
            if (downArrowDown == true && heroY < this.Height - heroSize)
            {
                heroY = heroY + heroSpeed;
            }
            if (rightArrowDown == true && heroX < this.Width - heroSize)
            {
                heroX = heroX + heroSpeed;
            }
            if (upArrowDown == true && heroY > 0)
            {
                heroY = heroY - heroSpeed;
            }
            //TODO move npc characters
            player.Play();         
            counter++;
            conterscore++;
            for (int i = 0; i < npc.Count(); i++)
            {
                int x = npc[i].X;
                int y = npc[i].Y;
                y++;

                npc[i] = new Point(x, y);
            }

            if (counter == 50)
            {
               
                npc.Add(new Point(randGen.Next(0, 290), 5));
                counter = 0;
            }

            if (npc[0].Y == this.Height)
            {
                npc.RemoveAt(0);
            }
            //TODO collisions checks 

            Rectangle heroRec = new Rectangle(heroX, heroY, heroSize, heroSize);

            for (int i = 0; i < npc.Count(); i++)
            {
                Rectangle npcRec = new Rectangle(npc[i].X, npc[i].Y, 20, 20);

                if (heroRec.IntersectsWith(npcRec))
                {
                    gameTimer.Stop();
                    Thread.Sleep(1000); 
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }


            //calls the GameScreen_Paint method to draw the screen.
            Refresh();
        }


        //Everything that is to be drawn on the screen should be done here
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen 
            e.Graphics.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
            
            for(int i = 0; i <npc.Count(); i++)
            {
                e.Graphics.FillRectangle(npcBrush, npc[i].X, npc[i].Y , 20, 20);
                
            }
            scorVarible.Text = conterscore + ""; 
        }
    }
}
