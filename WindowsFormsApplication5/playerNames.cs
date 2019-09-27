using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class playerNames : Form
    {
        public playerNames()
        {
            InitializeComponent();
           /// Player.SoundLocation = (@"C:\Users\Qasim\Documents\Visual Studio 2012\Projects\S&L 12-05-17\WindowsFormsApplication5\bin\Debug\button.wav");
        }

       // private SoundPlayer Player = new SoundPlayer();
        public static string p1, p2;
        int a = 1;
        int b = 1;
        public static bool close = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Player.Play();
            p1 = textBox1.Text;
            p2 = textBox2.Text;
            this.Hide();
            close = true;
            AnotherGame game = new AnotherGame();
            game.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
            if (a == 1)
            {
                textBox1.Clear();
            }
            a++;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (b == 1)
            {
                textBox2.Clear();
            }
            b++;
        }

        private void playerNames_Load(object sender, EventArgs e)
        {
            if (SnakeAndLadder.VsComputer == true)
            {
                textBox2.Enabled = false;
                textBox2.Text = "MR.ROBOT";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SnakeAndLadder.VsComputer = false;
            this.Close();
            SnakeAndLadder snl = new SnakeAndLadder();
            snl.Show();
        }
    }
}
