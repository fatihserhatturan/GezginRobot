using Prolab4._3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Diagnostics.Contracts;

namespace prolab4
{
    public partial class Problem1 : Form
    {
        public Problem1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Singleton singleton = Singleton.GetInstance();

            //List<TextBox> textboxs = new List<TextBox>();
            
            string[] fileInc = new string[100000];
            singleton.counterEn=0;
            singleton.counterBoy = 0;
            int c = 0;
            int b = 0;
            int a = 0;
            int[,] konum = new int[100,100];

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string line = sr.ReadLine();
                while (line != null)
                {
                    fileInc[singleton.counterEn++] = line;
                    singleton.counterBoy=line.Length;
                    //listBox1.Items.Add(line);
                    line = sr.ReadLine();
                }
            }

            char[][] inc = new char[singleton.counterEn][];

            for (int x=0; x<singleton.counterEn; x++)
            {
                    char[] s = fileInc[x].ToCharArray();
                    inc[x] = s;
            }

            int[,] incxy = new int[singleton.counterEn,singleton.counterBoy];

            for (int x = 0; x < singleton.counterEn; x++)
            {
                for (int y = 0; y < singleton.counterBoy; y++)
                {
                    incxy[x, y] = (int)Char.GetNumericValue(inc[x][y]);
                }
            }

            int[,] incx = new int[singleton.counterEn + 2,singleton.counterBoy +2];


            for (int i = 0; i < singleton.counterEn + 2; i++)
            {
                for (int j = 0; j < singleton.counterBoy + 2; j++)
                {
                    if (i == 0 || i == singleton.counterEn + 1 || j == 0 || j == singleton.counterBoy + 1)
                    {
                        incx[i, j] = 1;
                    }
                    else
                    {
                        incx[i, j] = incxy[i - 1, j - 1];
                    }
                }
            }

           izgara izgara = new izgara(incx, singleton.counterEn, singleton.counterBoy);

           
            for (int i = 0; i < izgara.enBoyut +2 ; i++)
            {
                for (int j = 0; j < izgara.boyBoyut+2 ; j++)
                {

                    TextBox newtext = new TextBox();
                    newtext.Location = new System.Drawing.Point(22 + (25 * c), 22 + (20 * b));
                    newtext.Size = new System.Drawing.Size(25, 25);
                    this.Controls.Add(newtext);
                    singleton.textboxs.Add(newtext);
                    if (izgara.dizi[i, j] != 0)
                    {
                        newtext.BackColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        newtext.BackColor= System.Drawing.Color.White;
                    }
                    c++;
                }
                c = 0;
                b++;
            }

            robot robot=new robot(izgara.dizi,singleton.counterEn, singleton.counterBoy);

            singleton.textboxs[robot.BaslangıcKonum()].Text = "be";
            singleton.textboxs[robot.BaslangıcKonum()].BackColor = System.Drawing.Color.Bisque;
            singleton.textboxs[izgara.ErisimNoktası()].BackColor = System.Drawing.Color.Cyan;

            robot.konum[singleton.counterEn - 1, singleton.counterBoy - 1] = 8;

            int[] konumRobot=new int[2];
            
            Random rnd = new Random();

            singleton.counterEn = singleton.counterEn+2;
            singleton.counterBoy = singleton.counterBoy+2;
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int counter = 0;
            Singleton singleton = Singleton.GetInstance();

            for (int i = 0; i < (singleton.counterEn) * (singleton.counterBoy); i++)
            {
                if (singleton.textboxs[i].BackColor == Color.Bisque && singleton.textboxs[i].Text == "be")
                {
                Applier:


                    if (singleton.textboxs[i - 1].BackColor !=Color.Black)
                    {
                        //sola hareket
                        if (singleton.textboxs[i - 1].BackColor == Color.Cyan)
                        {
                            singleton.textboxs[i - 1].Text = "be";
                            singleton.textboxs[singleton.textboxes[counter]].Text = " ";
                            break;
                        }
                        singleton.textboxs[i].Text = " ";
                        singleton.textboxs[i - 1].Text = "be";
                        singleton.textboxs[i - 1].BackColor = System.Drawing.Color.Bisque;
                        i = i - 1;
                        counter++;
                        singleton.textboxes[counter] = i;
                        goto Applier;
                    }
                    if (singleton.textboxs[i + 1].BackColor == Color.White || singleton.textboxs[i + 1].BackColor == Color.Cyan)
                    {

                        //sağa hareket
                        if (singleton.textboxs[i + 1].BackColor == Color.Cyan)
                        {
                            singleton.textboxs[i + 1].Text = "be";
                            singleton.textboxs[singleton.textboxes[counter]].Text = " ";
                            break;
                        }
                        singleton.textboxs[i].Text = " ";
                        singleton.textboxs[i + 1].Text = "be";
                        singleton.textboxs[i + 1].BackColor = System.Drawing.Color.Bisque;
                        i = i + 1;
                        counter++;
                        singleton.textboxes[counter] = i;
                       
                        goto Applier;
                    }
                    if (singleton.textboxs[i - (singleton.counterBoy)].BackColor == Color.White || singleton.textboxs[i - (singleton.counterBoy)].BackColor == Color.Cyan)
                    {
                        //yukarı hareket
                        if (singleton.textboxs[i - (singleton.counterBoy)].BackColor == Color.Cyan)
                        {
                            singleton.textboxs[i - (singleton.counterBoy)].Text = "be";
                            singleton.textboxs[singleton.textboxes[counter]].Text = " ";
                            break;
                        }
                        singleton.textboxs[i].Text = " ";
                        singleton.textboxs[i - (singleton.counterBoy)].Text = "be";
                        singleton.textboxs[i - (singleton.counterBoy)].BackColor = System.Drawing.Color.Bisque;
                        i = i - (singleton.counterBoy);
                        counter++;
                        singleton.textboxes[counter] = i;
                        goto Applier;
                    }
                    if (singleton.textboxs[i + (singleton.counterBoy)].BackColor == Color.White || singleton.textboxs[i + (singleton.counterBoy)].BackColor == Color.Cyan)
                    {
                        //aşağı hareket
                        if (singleton.textboxs[i + (singleton.counterBoy)].BackColor == Color.Cyan)
                        {
                            singleton.textboxs[i + (singleton.counterBoy)].Text = "be";
                            singleton.textboxs[singleton.textboxes[counter]].Text = " ";
                            break;
                        }
                        singleton.textboxs[i].Text = " ";
                        singleton.textboxs[i + (singleton.counterBoy)].Text = "be";
                        singleton.textboxs[i + (singleton.counterBoy)].BackColor = System.Drawing.Color.Bisque;
                        i = i + (singleton.counterBoy);
                        counter++;
                        singleton.textboxes[counter] = i;
                        goto Applier;
                    }
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Singleton singleton = Singleton.GetInstance();
            for(int i=0; i < (singleton.counterEn)*(singleton.counterBoy); i++)
            {
                if (singleton.textboxs[i].BackColor !=Color.Bisque)
                {
                    singleton.textboxs[i].Visible = false;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Singleton singleton = Singleton.GetInstance();

            for (int i = 0; i < (singleton.counterEn) * (singleton.counterBoy); i++)
            {
                if (singleton.textboxs[i].BackColor == Color.Bisque && singleton.textboxs[i].Text == "be")
                {
                Applier:
                    

                    if (singleton.textboxs[i - 1].BackColor == Color.White || singleton.textboxs[i - 1].BackColor == Color.Cyan)
                    {
                        //sola hareket
                        if (singleton.textboxs[i - 1].BackColor == Color.Cyan)
                        {
                            singleton.textboxs[i - 1].Text = "be";
                            break;
                        }
                        singleton.textboxs[i].Text = " ";
                        singleton.textboxs[i - 1].Text = "be";
                        singleton.textboxs[i - 1].BackColor = System.Drawing.Color.Bisque;
                        i = i - 1;
                        singleton.textboxs[i].Visible = true;
                        singleton.textboxs[i+1].Visible = true;
                        singleton.textboxs[i+singleton.counterBoy].Visible = true;
                        singleton.textboxs[i - singleton.counterBoy].Visible = true;
                        goto Applier;
                    }
                    if (singleton.textboxs[i + 1].BackColor == Color.White || singleton.textboxs[i + 1].BackColor == Color.Cyan)
                    {

                        //sağa hareket
                        if (singleton.textboxs[i + 1].BackColor == Color.Cyan)
                        {
                            singleton.textboxs[i + 1].Text = "be";
                            break;
                        }
                        singleton.textboxs[i].Text = " ";
                        singleton.textboxs[i + 1].Text = "be";
                        singleton.textboxs[i + 1].BackColor = System.Drawing.Color.Bisque;
                        i = i + 1;
                        singleton.textboxs[i].Visible = true;
                        singleton.textboxs[i + 1].Visible = true;
                        singleton.textboxs[i + singleton.counterBoy].Visible = true;
                        singleton.textboxs[i - singleton.counterBoy].Visible = true;
                        goto Applier;
                    }
                    if (singleton.textboxs[i - (singleton.counterBoy)].BackColor == Color.White || singleton.textboxs[i - (singleton.counterBoy)].BackColor == Color.Cyan)
                    {
                        //yukarı hareket
                        if (singleton.textboxs[i - (singleton.counterBoy)].BackColor == Color.Cyan)
                        {
                            singleton.textboxs[i - (singleton.counterBoy)].Text = "be";
                            break;
                        }
                        singleton.textboxs[i].Text = " ";
                        singleton.textboxs[i - (singleton.counterBoy)].Text = "be";
                        singleton.textboxs[i - (singleton.counterBoy)].BackColor = System.Drawing.Color.Bisque;
                        i = i - (singleton.counterBoy);
                        singleton.textboxs[i].Visible = true;
                        singleton.textboxs[i + 1].Visible = true;
                        singleton.textboxs[i + singleton.counterBoy].Visible = true;
                        singleton.textboxs[i - singleton.counterBoy].Visible = true;
                        goto Applier;
                    }
                    if (singleton.textboxs[i + (singleton.counterBoy)].BackColor == Color.White || singleton.textboxs[i + (singleton.counterBoy)].BackColor == Color.Cyan)
                    {
                        //aşağı hareket
                        if (singleton.textboxs[i + (singleton.counterBoy)].BackColor == Color.Cyan)
                        {
                            singleton.textboxs[i + (singleton.counterBoy)].Text = "be";
                            break;
                        }
                        singleton.textboxs[i].Text = " ";
                        singleton.textboxs[i + (singleton.counterBoy)].Text = "be";
                        singleton.textboxs[i + (singleton.counterBoy)].BackColor = System.Drawing.Color.Bisque;
                        i = i + (singleton.counterBoy);
                        singleton.textboxs[i].Visible = true;
                        singleton.textboxs[i + 1].Visible = true;
                        singleton.textboxs[i + singleton.counterBoy].Visible = true;
                        singleton.textboxs[i - singleton.counterBoy].Visible = true;
                        goto Applier;
                    }
                }
            }
        }
    }
}
