using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication5.Properties;
using WMPLib;

namespace WindowsFormsApplication5
{
    public partial class AnotherGame : Form
    {
        WindowsMediaPlayer playerHome = new WindowsMediaPlayer();
        public AnotherGame()
        {
            InitializeComponent();
            if (SnakeAndLadder.VsComputer == true)
            {
                this.Text = "SNAKES & LADDERS | VS COMPUTER";
            }
            
        }

        //StreamWriter highscore = new StreamWriter(@"highscore.txt");
        private SoundPlayer Player = new SoundPlayer();
        private SoundPlayer snake = new SoundPlayer();
        private SoundPlayer ladder = new SoundPlayer();
        string nameP1 = playerNames.p1, nameP2 = playerNames.p2;

        private void AnotherGame_Load(object sender, EventArgs e)
        {

            diceP2.Enabled = false;
            
            label3.Text = nameP1;
            label1.Text = nameP2;
        }
        
        int randomNumberP1;
        int randomNumberP2;
        int counterP1 = 1, counterP2 = 1, X_val = 69, Y_val = 67;
        //int randomNumberP12 = 0;
        bool forwardP2 = false, backwardP2 = false, Y_minusP2 = true, test = true;
        bool forwardP1 = false, backwardP1 = false, Y_minusP1 = true;
        int testCount = 0;


        private void diceP1_Click(object sender, EventArgs e)
        {
            //Player.Play();//button click sound
            
            dicerollP1(ref randomNumberP1, ref label6);
            TokenMoveP1(ref label6, pictureBox8, ref Y_minusP1, randomNumberP1, ref backwardP1,
                        ref forwardP1, ref test, ref counterP1, ref X_val, ref Y_val, snake, ladder);

            
            

            //..........TO CHANGE DICE ACC TO THE RANDOM NUMBER.....................//
            if (randomNumberP1 == 1)
            diceP1.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._1;
            else if (randomNumberP1 == 2)
            diceP1.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._2;
            else if (randomNumberP1 == 3)
            diceP1.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._3;
            else if (randomNumberP1 == 4)
            diceP1.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._4;
            else if (randomNumberP1 == 5)
            diceP1.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._5;
            else if (randomNumberP1 == 6)
            diceP1.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._6;
            //..........TO CHANGE DICE ACC TO THE RANDOM NUMBER.....................//

            if (SnakeAndLadder.VsComputer == true)
            {
                //System.Threading.Thread.Sleep(1000);
            }
            if (randomNumberP1 == 6)
            {
                diceP2.Enabled = false;
                diceP1.Enabled = true;
                MoveCursor();
            }
            else
            {
                diceP2.Enabled = true;
                diceP1.Enabled = false;
                MoveCursor();
            }
            
            if (SnakeAndLadder.VsComputer == true && diceP2.Enabled == true && counterP1 != 100)
            {
                //Player.Play();//button click sound
                diceP2_Click(sender, e);
                diceP1.Enabled = true;
                diceP2.Enabled = false;
            }
            if (counterP1 == 100)
            {
                playerHome.URL = "title_bgm.mp3";
                //MessageBox.Show(nameP1+" WINS !!!");
                panel5.Location = new Point(211, 240);
                panel5.Visible = true;
                label13.Text = nameP1+" WINS";
                diceP1.Enabled = false;
                diceP2.Enabled = false;
                //using (highscore)
                //{
                //     highscore.WriteLine(nameP1);
                //}

                using (StreamWriter writer = File.AppendText(@"highscore.txt"))
                {
                    writer.WriteLine(nameP1);
                }
            }

            diceP2.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources.dice1;
        }


        private void diceP2_Click(object sender, EventArgs e)
        {

           // Player.Play();//button click sound

            

            dicerollP2(ref randomNumberP2, ref label2);
            TokenMoveP2(ref label2, pictureBox9, ref Y_minusP2, randomNumberP2, ref backwardP2,
                        ref forwardP2, ref test, ref counterP2, ref X_val, ref Y_val, ref testCount, snake, ladder);

            

            if (randomNumberP2 == 1)
                diceP2.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._1;
            else if (randomNumberP2 == 2)
                diceP2.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._2;
            else if (randomNumberP2 == 3)
                diceP2.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._3;
            else if (randomNumberP2 == 4)
                diceP2.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._4;
            else if (randomNumberP2 == 5)
                diceP2.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._5;
            else if (randomNumberP2 == 6)
                diceP2.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._6;

            if (randomNumberP2 == 6)
            {
                diceP1.Enabled = false;
                diceP2.Enabled = true;
                MoveCursor();
            }
            else
            {
                diceP1.Enabled = true;
                diceP2.Enabled = false;
                MoveCursor();
            }
            

            if (counterP2 == 100)
            {
                playerHome.URL = "title_bgm.mp3";
                panel5.Location = new Point(211, 240);
                panel5.Visible = true;
                label13.Text = nameP2 + " WINS";
                diceP2.Enabled = false;
                diceP1.Enabled = false;
                //using (highscore)
                //{
                //    highscore.WriteLine(nameP2);
                //}
                using (StreamWriter writer = File.AppendText(@"highscore.txt"))
                {
                    writer.WriteLine(nameP2);
                }
            }
            //label7.Text = counterP2.ToString();
            //label8.Text = testCount.ToString();
            diceP1.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources.dice1;
            if (SnakeAndLadder.VsComputer == true)
            {
                //System.Threading.Thread.Sleep(2000);
            }

            label10.Text = pictureBox9.Location.X.ToString();//ONLY FOR TESTING x-axis
            label9.Text = pictureBox9.Location.Y.ToString();//ONLY FOR TESTING y-axis
           
        }


        //...........METHOD FOR DICE ROLL PLAYER 1..............................//
        public static void dicerollP1(ref int randomNumberP1, ref Label label6)
        {
            Random random1 = new Random();
            randomNumberP1 = random1.Next(1, 7);
            label6.Text = randomNumberP1.ToString();
        }//...........METHOD FOR DICE ROLL PLAYER 1..............................//


        //...........METHOD FOR DICE ROLL PLAYER 2..............................//
        public static void dicerollP2(ref int randomNumberP2, ref Label label2)
        {
            Random random2 = new Random();
            randomNumberP2 = random2.Next(1, 7);
            label2.Text = randomNumberP2.ToString();
        }//...........METHOD FOR DICE ROLL PLAYER 2..............................//


        public static void TokenMoveP1(ref Label label6, PictureBox pictureBox8, ref bool Y_minusP1,
                                       int randomNumberP1, ref bool backwardP1, ref bool forwardP1,
                                       ref bool test, ref int counterP1, ref int X_val, ref int Y_val,SoundPlayer snake, SoundPlayer ladder)
        {
            int a = Convert.ToInt32(label6.Text);
            
            if (pictureBox8.Visible == true)
            {

                //.......Used To not exceed from 100.....//
                if (counterP1 + randomNumberP1 > 100)
                {
                    return;
                }
                counterP1 += randomNumberP1;
                //........................................//

                for (int i = 1; i <= randomNumberP1; i++)
                {
                   // System.Threading.Thread.Sleep(200); // 5,000 ms
                    

                    if (pictureBox8.Location.X == 635 && Y_minusP1 == true)
                    {
                        pictureBox8.Location = new Point(pictureBox8.Location.X, pictureBox8.Location.Y - Y_val);
                        backwardP1 = true;
                        Y_minusP1 = false;
                    }

                    else if (pictureBox8.Location.X > 14 && backwardP1 == true)
                    {
                        pictureBox8.Location = new Point(pictureBox8.Location.X - X_val, pictureBox8.Location.Y);
                    }

                    else if (pictureBox8.Location.X == 14 && backwardP1 == true)
                    {
                        backwardP1 = false;
                        pictureBox8.Location = new Point(pictureBox8.Location.X, pictureBox8.Location.Y - Y_val);
                        test = false;
                    }

                    else if (pictureBox8.Location.X >= 14)
                    {
                        pictureBox8.Location = new Point(pictureBox8.Location.X + X_val, pictureBox8.Location.Y);
                        Y_minusP1 = true;
                    }

                    

                }
                //...........................SNAKES................................
                if (counterP1 == 50)
                {
                    snake.Play();
                    pictureBox8.Location = new Point(566, 557);
                    counterP1 = 12;
                    backwardP1 = true;
                }                                                       //  T
                else if (counterP1 == 59)                               //  O
                {                                                       //  K
                    snake.Play();
                    pictureBox8.Location = new Point(83, 557);          //  E
                    counterP1 = 19;                                     //  N
                }
                else if (counterP1 == 62)                               //  M
                {                                                       //  O
                    snake.Play();
                    pictureBox8.Location = new Point(152, 423);         //  V
                    counterP1 = 38;                                     //  E
                    backwardP1 = true;
                }                                                       //  P
                else if (counterP1 == 70)                               //  1
                {
                    snake.Play();
                    pictureBox8.Location = new Point(428, 356);
                    counterP1 = 47;
                }
                else if (counterP1 == 91)
                {
                    snake.Play();
                    pictureBox8.Location = new Point(221,222);
                    counterP1 = 64;
                    backwardP1 = false;
                }
                else if (counterP1 == 99)
                {
                    snake.Play();
                    pictureBox8.Location = new Point(290, 624);
                    counterP1 = 5;
                    backwardP1 = false;
                }//.......................................SNAKES.....................................

                //....................................LADDERS...............//
                else if (counterP1 == 9)
                {
                    ladder.Play();
                    pictureBox8.Location = new Point(428, 423);
                    counterP1 = 34;
                    backwardP1 = true;

                }
                else if (counterP1 == 3)
                {
                    ladder.Play();
                    pictureBox8.Location = new Point(83, 490);                  //  T
                    counterP1 = 22;                                             //  O
                                                                                //  K
                }                                                               //  E
                else if (counterP1 == 11)                                       //  N
                {
                    ladder.Play();
                    pictureBox8.Location = new Point(566, 356);                 //  M
                    counterP1 = 49;                                             //  O
                    backwardP1 = false;                                         //  V
                                                                                //  E
                }
                else if (counterP1 == 17)                                       //  P
                {
                    ladder.Play();//  1
                    pictureBox8.Location = new Point(635, 88);
                    counterP1 = 90;
                    Y_minusP1 = true;
                    backwardP1 = false;

                }
                else if (counterP1 == 24)
                {
                    ladder.Play();
                    pictureBox8.Location = new Point(428, 21);
                    counterP1 = 94;
                    backwardP1 = true;

                }
                else if (counterP1 == 39)
                {
                    ladder.Play();
                    pictureBox8.Location = new Point(290, 21);
                    counterP1 = 96;

                }
                else if (counterP1 == 63)
                {
                    ladder.Play();
                    pictureBox8.Location = new Point(14, 155);
                    counterP1 = 80;
                    backwardP1 = true;

                }//.................LADDERS.......................//
               
            }


            if (a == 6 && pictureBox8.Visible == false)
            {
                pictureBox8.Visible = true;
            }
        }


        public static void TokenMoveP2(ref Label label2, PictureBox pictureBox9, ref bool Y_minusP2,
                                       int randomNumberP2, ref bool backwardP2, ref bool forwardP2,
                                       ref bool test, ref int counterP2, ref int X_val, ref int Y_val, ref int testCount, SoundPlayer snake, SoundPlayer ladder)
        {
            int a = Convert.ToInt32(label2.Text);
            
            if (pictureBox9.Visible == true)
            {

                //.......Used To not exceed from 100.....//
                if (counterP2+randomNumberP2 > 100)
                {
                    return;
                }//........................................//

                counterP2 += randomNumberP2;


                    for (int i = 1; i <= randomNumberP2; i++)
                    {
                        
                        
                        if (pictureBox9.Location.X >= 664 && Y_minusP2 == true)
                        {
                            pictureBox9.Location = new Point(pictureBox9.Location.X, pictureBox9.Location.Y - Y_val);
                            backwardP2 = true;
                            Y_minusP2 = false;
                           
                        }

                        else if (pictureBox9.Location.X > 43 && backwardP2 == true)
                        {
                            pictureBox9.Location = new Point(pictureBox9.Location.X - X_val, pictureBox9.Location.Y);
                           
                        }

                        else if (pictureBox9.Location.X == 43 && backwardP2 == true)
                        {
                            backwardP2 = false;
                            pictureBox9.Location = new Point(pictureBox9.Location.X, pictureBox9.Location.Y - Y_val);
                            test = false;
                           
                        }

                        else if (pictureBox9.Location.X >= 43)
                        {
                            pictureBox9.Location = new Point(pictureBox9.Location.X + X_val, pictureBox9.Location.Y);
                            Y_minusP2 = true;
                           
                        }

                        //System.Threading.Thread.Sleep(200); // 5,000 ms
                        
                    }
                

                    //.............................SNAKES.........................//
                    if (counterP2 == 50)
                    {
                        snake.Play();
                        pictureBox9.Location = new Point(595, 557);                  //  T
                        counterP2 = 12;                                              //  O
                        backwardP2 = true;                                           //  K
                    }                                                                //  E
                    else if (counterP2 == 59)                                        //  N
                    {
                        snake.Play();
                        pictureBox9.Location = new Point(112, 557);                  //  M
                        counterP2 = 19;                                              //  O
                    }                                                                //  V
                    else if (counterP2 == 62)                                        //  E
                    {
                        snake.Play();
                        pictureBox9.Location = new Point(181, 423);                  //  P
                        counterP2 = 38;                                              //  2
                        backwardP2 = true;
                    }
                    else if (counterP2 == 70)
                    {
                        snake.Play();
                        pictureBox9.Location = new Point(457, 356);
                        counterP2 = 47;
                    }
                    else if (counterP2 == 91)
                    {
                        snake.Play();
                        pictureBox9.Location = new Point(251, 222);
                        counterP2 = 64;
                        backwardP2 = false;
                    }
                    else if (counterP2 == 99)
                    {
                        snake.Play();
                        pictureBox9.Location = new Point(319, 624);
                        counterP2 = 5;
                        backwardP2 = false;
                    }//......................................SNAKES..........................//

                    //............................LADDERS.........................//
                    else if (counterP2 == 9)
                    {
                        ladder.Play();
                        pictureBox9.Location = new Point(457, 423);
                        counterP2 = 34;
                        backwardP2 = true;
                        
                    }
                    else if (counterP2 == 3)
                    {
                        ladder.Play();//  T
                        pictureBox9.Location = new Point(112, 490);             //  O
                        counterP2 = 22;                                         //  K
                                                                                //  E
                    }                                                           //  N
                    else if (counterP2 == 11)
                    {
                        ladder.Play();//  M
                        pictureBox9.Location = new Point(595, 356);             //  O
                        counterP2 = 49;                                         //  V
                        backwardP2 = false;                                     //  E
                        
                    }                                                           //  P
                    else if (counterP2 == 17)                                   //  2
                    {
                        ladder.Play();
                        pictureBox9.Location = new Point(664, 88);
                        counterP2 = 90;
                        Y_minusP2 = true;
                        backwardP2 = false;
                        
                    }
                    else if (counterP2 == 24)
                    {
                        ladder.Play();
                        pictureBox9.Location = new Point(457, 21);
                        counterP2 = 94;
                        backwardP2 = true;
                        
                    }
                    else if (counterP2 == 39)
                    {
                        ladder.Play();
                        pictureBox9.Location = new Point(319, 21);
                        counterP2 = 96;
                        
                    }
                    else if (counterP2 == 63)
                    {
                        ladder.Play();
                        pictureBox9.Location = new Point(43, 155);
                        counterP2 = 80;
                        backwardP2 = true;
                        
                    }//............................LADDERS.......................................//

            }
            
            if (a == 6 && pictureBox9.Visible == false)
            {
                pictureBox9.Visible = true;
            }
            
        }

        //................OPTIONS PANEL.......................................//
        private void button1_Click(object sender, EventArgs e)
        {
            //Player.Play();
            if (home.Visible == false)
            {
                home.Visible = true;               //....OPTIONS......//
                panel1.Enabled = false;              //...PANEL.......//
                restart.Visible = true;
                sound.Visible = true;
            }
            else
            {
                home.Visible = false;
                restart.Visible = false;
                sound.Visible = false;
                panel1.Enabled = true;
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            //Player.Play();
            SnakeAndLadder.VsComputer = false;
            this.Close();
            SnakeAndLadder snl = new SnakeAndLadder();
            snl.Show();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            //Player.Play();
            string message = "Do you want to Abort ?";
            string title = "RESTART";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                AnotherGame gam = new AnotherGame();
                gam.Show();
            }
            else
            {
                home.Visible = false;
                restart.Visible = false;
                sound.Visible = false;
                panel1.Enabled = true;
                //this.Close();
            }

            //panel3.Enabled = false;
            //panel5.Location = new Point(211,240);
            //panel5.BringToFront();
            //panel5.Visible = true;
            ////panel5.Enabled = true;
            ////panel5.Show();
            //label13.Text = "RESTART GAME";
            //button2.Visible = true;
            //button3.Visible = true;
            
        }

        private void sound_Click(object sender, EventArgs e)
        {
           // Player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AnotherGame gam = new AnotherGame();
            gam.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SnakeAndLadder.VsComputer = false;
            this.Hide();
            SnakeAndLadder snl = new SnakeAndLadder();
            snl.Show();
        }//................OPTIONS PANEL.......................................//

        private void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            //this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(43,600);
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

    }
}
