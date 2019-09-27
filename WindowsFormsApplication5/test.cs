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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            this.draw();


        }

        private void test_Load(object sender, EventArgs e)
        {

        }


        private void draw() {
            int boxSize = 50;
            int x = 0;
            int y = 500;
            int maxX = 0;
           bool repeat = true;
            int add = 0;
            int yAdd = 50;

            for (int i = 1; i <= 100; i++)
            {
                Label box = new Label();
                
                box.Size = new System.Drawing.Size(boxSize, boxSize);
                box.TextAlign = ContentAlignment.BottomRight;
                box.Text = i.ToString() ;
                box.BackColor = System.Drawing.ColorTranslator.FromHtml(getChoice(i));
                box.ForeColor = Color.White;
                box.Location = new System.Drawing.Point(x, y);
                
                x += 50;
                //if (x==450)
                //{
                    
                //}
                if (i % 10 == 0)
                {
                    //MessageBox.Show(x.ToString());
                    //y = y - boxSize;
                    //x = 450;
                    for (int j = 1; j <= i; j++)
                    {
                        x = 450 - add;
                        y = 500 - yAdd;
                      //  MessageBox.Show(x.ToString());
                        Label boxA = new Label();
                        boxA.Size = new System.Drawing.Size(boxSize, boxSize);
                        boxA.TextAlign = ContentAlignment.BottomRight;
                        boxA.Text = i.ToString();
                        boxA.BackColor = System.Drawing.ColorTranslator.FromHtml(getChoice(i));
                        boxA.ForeColor = Color.White;
                        boxA.Location = new System.Drawing.Point(x, y);
                       // MessageBox.Show(y.ToString());
                        add += 50;
                    }
                    yAdd += 50;
                    x = 0;
                    y -= 50;
                    i += 9;
                    repeat = true;
                    maxX = x;
                }
                
                //else
                //{
                //    if (repeat && x == 0) {
                //        repeat = false;
                //    }
                //    else if (repeat)
                //    {
                //        x = x - 50;
                //    }
                //    else if (!repeat)
                //    {
                //        x += 50;
                         
                //    }
                    
                //}



                //if (repeat)
                //{
                //    if (x == 0)
                //    {
                //        MessageBox.Show(x.ToString());
                //        repeat = false;
                //    }

                //    MessageBox.Show(x +"=="+ maxX);

                //    if (x == maxX)
                //    {
                //        x = x - 50;
                //        MessageBox.Show(x.ToString());

                //    }
                   

                //}
                //else {
                //    x += 50;
                //}



                
                this.Controls.Add(box);
                int whati = i;
                int whatx = box.Location.X;
                int whaty = box.Location.Y;
                System.Diagnostics.Debug.WriteLine("Method1"); 

                //MessageBox.Show(box.Location.X.ToString() + "," + box.Location.Y.ToString());

            }
            
        }

        string getChoice(int a)
        {
            string myChoice;
            return myChoice = a % 2 == 0 ? "#DC143C" : "	#2F4F4F";
        }
    }
}
