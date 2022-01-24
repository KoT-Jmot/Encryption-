using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string word;
        char[,] a = new char[10, 9];
        char[,] b = new char[10, 9];
        int lenght;
        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text!="")
            {
                word = richTextBox1.Text;
                lenght = 0;
                for(int i=0;i<10;i++)
                {
                    for(int j=0;j<9;j++)
                    {
                        if (word.Length > lenght)
                        {
                            a[i, j] = word[lenght];
                            lenght++;
                        }
                        else
                            a[i, j] = ' ';
                    }

                }
                for(int i=0;i<10;i++)  //713254986
                {
                    b[i, 0] = a[i, 6];
                    b[i, 1] = a[i, 0];
                    b[i, 2] = a[i, 2];
                    b[i, 3] = a[i, 1];
                    b[i, 4] = a[i, 4];
                    b[i, 5] = a[i, 3];
                    b[i, 6] = a[i, 8];
                    b[i, 7] = a[i, 7];
                    b[i, 8] = a[i, 5];

                }
                richTextBox2.Text = "";
                for (int i=0;i<10;i++)
                {
                    for(int j=0;j<9;j++)
                    {
                        richTextBox2.Text += b[i,j];
                    }
                }
                using (StreamWriter sw = File.CreateText("1.txt"))
                {
                    sw.WriteLine(richTextBox2.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("1.txt"))
            {
                word = sr.ReadLine();
                lenght = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (word.Length > lenght)
                        {
                            a[i, j] = word[lenght];
                            lenght++;
                        }
                        else
                            a[i, j] = ' ';
                    }
                }
                for (int i = 0; i < 10; i++)  //602143875
                {
                    b[i, 0] = a[i, 1];
                    b[i, 1] = a[i, 3];
                    b[i, 2] = a[i, 2];
                    b[i, 3] = a[i, 5];
                    b[i, 4] = a[i, 4];
                    b[i, 5] = a[i, 8];
                    b[i, 6] = a[i, 0];
                    b[i, 7] = a[i, 7];
                    b[i, 8] = a[i, 6];
                    /*
                    b[i, 0] = a[i, 6];
                    b[i, 1] = a[i, 0];
                    b[i, 2] = a[i, 2];
                    b[i, 3] = a[i, 1];
                    b[i, 4] = a[i, 4];
                    b[i, 5] = a[i, 3];
                    b[i, 6] = a[i, 8];
                    b[i, 7] = a[i, 7];
                    b[i, 8] = a[i, 5];
                    */
                }
                richTextBox2.Text = "";
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        richTextBox2.Text += b[i, j];
                    }
                }
            }
        }
    }
}
