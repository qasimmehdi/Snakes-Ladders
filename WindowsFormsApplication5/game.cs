using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
        }


        private void game_Load(object sender, EventArgs e)
        {                                     //red pictureBoxes.........................//
            PictureBox[] picBoxes = { pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, 
                                     pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21,
                                     pictureBox22, pictureBox23, pictureBox24, pictureBox25, pictureBox26, pictureBox27,
                                     pictureBox28, pictureBox29, pictureBox30, pictureBox31, pictureBox32, pictureBox33,
                                     pictureBox34, pictureBox35, pictureBox36, pictureBox37, pictureBox38, pictureBox39,
                                             //red pictureBoxes...END..here...............//

                                             //blue pictureBoxes.........................//
                                     pictureBox1, pictureBox2, pictureBox5, pictureBox6, pictureBox7, pictureBox8, 
                                     pictureBox9, pictureBox40, pictureBox41, pictureBox42, pictureBox43, pictureBox44,
                                     pictureBox45, pictureBox46, pictureBox47, pictureBox48, pictureBox49, pictureBox50,
                                     pictureBox51, pictureBox52, pictureBox53, pictureBox54, pictureBox55, pictureBox56,
                                     pictureBox57, pictureBox58, pictureBox59, pictureBox60, pictureBox61, pictureBox62};
                                            //blue pictureBoxes.END..here................//
            for (int i = 0; i < picBoxes.Length; i++)
            {
                picBoxes[i].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SnakeAndLadder home = new SnakeAndLadder();
            home.Show();
        }

        bool firstR = false;
        bool firstB = false;
        int preRollR,preRollB;
        int count = 0;

        private void diceDisplay_Click(object sender, EventArgs e)
        {                                    //red pictureBoxes.........................//
            PictureBox[] picBoxes = { pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, 
                                     pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21,
                                     pictureBox22, pictureBox23, pictureBox24, pictureBox25, pictureBox26, pictureBox27,
                                     pictureBox28, pictureBox29, pictureBox30, pictureBox31, pictureBox32, pictureBox33,
                                     pictureBox34, pictureBox35, pictureBox36, pictureBox37, pictureBox38, pictureBox39};
                                             //red pictureBoxes...END..here...............//
                                                        //---------------------//
                                             //blue pictureBoxes.........................//
           PictureBox[] blueTokens = { pictureBox62, pictureBox61, pictureBox60, pictureBox59, pictureBox58, pictureBox57, 
                                     pictureBox51, pictureBox52, pictureBox53, pictureBox54, pictureBox55, pictureBox56,
                                     pictureBox50, pictureBox49, pictureBox48, pictureBox47, pictureBox46, pictureBox45,
                                     pictureBox9, pictureBox40, pictureBox41, pictureBox42, pictureBox43, pictureBox44,
                                     pictureBox8, pictureBox7, pictureBox6, pictureBox5, pictureBox2, pictureBox1};
                                            //blue pictureBoxes.END..here................//
            count++;
            Random random1 = new Random();
            int randomNumber1 = random1.Next(1, 7);
            label2.Text = randomNumber1.ToString();


            if (count % 2 == 0)  //Code fo---BLUE---Tokens.................//
            {
                //Code for Rolls after first time...............................//
                if (firstB == true && pictureBox62.Visible == false)
                {
                    int increased = Int32.Parse(label5.Text);
                    increased += randomNumber1;
                    if (increased <= 30)
                    {
                        blueTokens[increased - 1].Visible = true;
                        label5.Text = increased.ToString();
                    }


                    //to hide previous pictureBoxes.......Ghayab karne wala code....................//
                        for (int i = 0; i < blueTokens.Length; i++)
                        {
                            if (i < (increased - 1) && blueTokens[i] != null)
                            {
                                blueTokens[i].Visible = false;
                            }
                        }//Ghayab karne wala code....END here......................................//

                }//Code for Rolls after first time..END here.............................//


                //first time roll....................................//
                if (firstB == false)
                {
                    blueTokens[randomNumber1 - 1].Visible = true;
                    firstB = true;
                    preRollB = randomNumber1;
                    label5.Text = preRollB.ToString();
                }//END here................................................//

            } //.................Code for---BLUE---Tokens..END..here.............//

                      //******************************************//
            //------------------SEPERATION----------------------------------//
                      //******************************************//

            if (count % 2 != 0)  //Code for RED Tokens....................//
            {
                //Code for Rolls after first time...............................//
                if (firstR == true && pictureBox39.Visible == false)
                {
                    int increased = Int32.Parse(label4.Text);
                    increased += randomNumber1;
                    if (increased <= 30)
                    {
                        picBoxes[increased - 1].Visible = true;
                        label4.Text = increased.ToString();
                    }

                    //to hide previous pictureBoxes.......Ghayab karne wala code....................//
                        for (int i = 0; i < picBoxes.Length; i++)
                        {
                            if (i < (increased - 1) && picBoxes[i] != null)
                            {
                                picBoxes[i].Visible = false;
                            }
                        }//Ghayab karne wala code....END here......................................//
                     

                }//Code for Rolls after first time..END here.............................//


                //first time roll....................................//
                if (firstR == false)
                {
                    picBoxes[randomNumber1 - 1].Visible = true;
                    firstR = true;
                    preRollR = randomNumber1;
                    label4.Text = preRollR.ToString();
                }//END here................................................//

            } //.................Code for RED Tokens..END..here.............//

            if (pictureBox1.Visible == true)
            {
                string winner = "Player 1 Wins!!!";
                MessageBox.Show(winner);
            }
            else if (pictureBox39.Visible == true)
            {
                string winner = "Player 2 Wins!!!";
                MessageBox.Show(winner);
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            SnakeAndLadder snl = new SnakeAndLadder();
            snl.Show();
        }

    }
}
