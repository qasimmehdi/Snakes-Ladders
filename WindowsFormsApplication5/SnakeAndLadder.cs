using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using System.IO;

namespace WindowsFormsApplication5
{
    public partial class SnakeAndLadder : Form
    {
        
       // private SoundPlayer Player = new SoundPlayer();
        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        WindowsMediaPlayer playerHome = new WindowsMediaPlayer();
        WindowsMediaPlayer btn = new WindowsMediaPlayer();
        public SnakeAndLadder()
        {
            InitializeComponent();
            //for (int i = 1; i < 100; i++)
            
                playerHome.URL = "title_bgm.mp3";
            
            

            btn.URL = "button.mp3";

           // Player.SoundLocation = (@"C:\Users\Qasim\Documents\Visual Studio 2012\Projects\S&L 12-05-17\WindowsFormsApplication5\bin\Debug\button.wav");
        }
        public static bool VsComputer = false;

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //how guide = new how();
            //guide.Show();
            btn.URL = "button.mp3";
            button7.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            pictureBox4.Visible = false;
            leaderboard.Visible = false;
            how.Location = new Point(75, 86);
            how.Visible = true;
            home.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btn.URL = "button.mp3";
            
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btn.URL = "button.mp3";
            
            this.Hide();
            about about = new about();
            about.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            btn.URL = "button.mp3";
            //this.Hide();
            //leaderboard leader = new leaderboard();
            //leader.Show();
            leaderboard.Location = new Point(351, 70);
            leaderboard.Visible = true;
            home.Visible = true;
            button7.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            pictureBox4.Visible = false;
            //if (leaderboard.Visible == true)
            //{
            //    panelButtons.Visible = false;
            //}
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn.URL = "button.mp3";
            VsComputer = true;
            this.Hide();
            playerNames name = new playerNames();
            name.Show();
            //AnotherGame game = new AnotherGame();
            //game.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btn.URL = "button.mp3";
            this.Hide();
            test test = new test();
            test.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btn.URL = "button.mp3";
            this.Hide();
            playerNames name = new playerNames();
            name.Show();
            //this.Hide();
            //AnotherGame game = new AnotherGame();
            //game.Show();
            
        }

        private void home_Click(object sender, EventArgs e)
        {
            btn.URL = "button.mp3";
            how.Visible = false;
            leaderboard.Visible = false;
            home.Visible = false;
           // panelButtons.Visible = true;
            button7.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            pictureBox4.Visible = true;
        }

        private void SnakeAndLadder_Load(object sender, EventArgs e)
        {
           // button3.Visible = false;
            
            
            
        }

        public void high()
        {
            //string[] ab = File.ReadAllLines(@"highscore.txt");
            //for (int i = 0; i < ab.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < ab.Length; j++)
            //    {
            //        if (i == j)
            //        {
                        
            //        }
            //    }
            //}
        }
        //public void PlayMusicRepeat(Song song)
        //{
        //    MediaPlayer.Play(song);
        //    MediaPlayer.IsRepeating = true;
        //}

    }
}
