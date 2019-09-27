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
    public partial class leaderboard : Form
    {
        public leaderboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SnakeAndLadder home = new SnakeAndLadder();
            home.Show();
            this.Close();
        }
    }
}
