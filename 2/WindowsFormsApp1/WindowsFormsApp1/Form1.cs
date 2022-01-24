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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        string alf = "abcdefghijklmnopqrstuvwxyz._,-";
        char[,] firstalf= new char[6,6];
        int col = 0, row = 0;
        char[,] secondalf= new char[6,6];
        string word = "";
        bool found1 = false;
        bool found2 = false;
        string newword = "";
        bool added = true;

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.Text!="" && textBox2.Text != "" && textBox3.Text != "")
            {
                using (StreamReader sr = new StreamReader(textBox5.Text + ".txt"))
                {
                    word = sr.ReadLine();
                }




                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 6; j++)
                        firstalf[i, j] = ' ';
                col = 0;
                row = 0;
                for (int i = 0; i < textBox3.TextLength; i++)
                {
                    added = true;
                    foreach (char j in firstalf)
                        if (j == textBox3.Text[i])
                        {
                            added = false;
                            break;
                        }
                    if (added)
                    {
                        firstalf[row, col] = textBox3.Text[i];
                        col++;
                    }

                    if (col == 6)
                    {
                        col = 0;
                        row++;
                    }
                }

                for (int i = 0; i < alf.Length; i++)
                {
                    added = true;
                    foreach (char j in firstalf)
                        if (j == alf[i])
                        {
                            added = false;
                            break;
                        }
                    if (added)
                        if (added)
                        {
                            firstalf[row, col] = alf[i];
                            col++;
                        }

                    if (col == 6)
                    {
                        col = 0;
                        row++;
                    }
                }
                /////////////////////////////////////////////
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 6; j++)
                        secondalf[i, j] = ' ';
                col = 0;
                row = 0;
                for (int i = 0; i < textBox2.TextLength; i++)
                {
                    added = true;
                    foreach (char j in secondalf)
                        if (j == textBox2.Text[i])
                        {
                            added = false;
                            break;
                        }
                    if (added)
                    {
                        secondalf[row, col] = textBox2.Text[i];
                        col++;
                    }

                    if (col == 6)
                    {
                        col = 0;
                        row++;
                    }
                }

                for (int i = 0; i < alf.Length; i++)
                {
                    added = true;
                    foreach (char j in secondalf)
                        if (j == alf[i])
                        {
                            added = false;
                            break;
                        }
                    if (added)
                        if (added)
                        {
                            secondalf[row, col] = alf[i];
                            col++;
                        }

                    if (col == 6)
                    {
                        col = 0;
                        row++;
                    }
                }

                newword = "";
                for (int i = 0; i < word.Length - 1; i += 2)
                {
                    found1 = false;
                    found2 = false;
                    for (int i1 = 0; i1 < 6; i1++)
                    {
                        for (int j1 = 0; j1 < 6; j1++)
                        {
                            if (firstalf[i1, j1] == word[i])
                            {
                                found1 = true;
                                for (int i2 = 0; i2 < 6; i2++)
                                {
                                    for (int j2 = 0; j2 < 6; j2++)
                                    {
                                        if (secondalf[i2, j2] == word[i + 1])
                                        {
                                            found2 = true;
                                            newword += firstalf[i2, j1];
                                            newword += secondalf[i1, j2];
                                        }
                                        if (found2)
                                            break;
                                    }
                                    if (found2)
                                        break;
                                }
                            }
                            if (found1)
                                break;
                        }
                        if (found1)
                            break;
                    }
                }
                textBox4.Text = newword;











            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox5.Text!="" && textBox4.Text!="")
                using (StreamWriter sw = File.CreateText(textBox5.Text + ".txt"))
                {
                    sw.WriteLine(textBox4.Text);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                word = "";
                for (int i = 0; i < textBox1.TextLength; i++)
                    if (textBox1.Text[i] == ' ')
                        word += '_';
                    else
                        word += textBox1.Text[i];
                if (word.Length % 2 != 0)
                {
                    word += '.';
                    textBox1.Text += '.';
                }
                col = 0;
                row = 0;
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 6; j++)
                        firstalf[i, j] = ' ';
                for (int i=0;i<textBox2.TextLength;i++)
                {
                    added = true;
                    foreach(char j in firstalf)
                        if (j==textBox2.Text[i])
                        {
                            added = false;
                            break;
                        }
                    if (added)
                    {
                        firstalf[row, col] = textBox2.Text[i];
                        col++;
                    }

                    if(col==6)
                    {
                        col = 0;
                        row++;
                    }
                }

                for(int i=0;i<alf.Length;i++)
                {
                    added = true;
                    foreach (char j in firstalf)
                        if (j == alf[i])
                        {
                            added = false;
                            break;
                        }
                    if (added)
                        if (added)
                        {
                            firstalf[row, col] = alf[i];
                            col++;
                        }

                    if (col == 6)
                    {
                        col = 0;
                        row++;
                    }
                }
                /////////////////////////////////////////////
                col = 0;
                row = 0;
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 6; j++)
                        secondalf[i, j] = ' ';
                for (int i = 0; i < textBox3.TextLength; i++)
                {
                    added = true;
                    foreach (char j in secondalf)
                        if (j == textBox3.Text[i])
                        {
                            added = false;
                            break;
                        }
                    if (added)
                    {
                        secondalf[row, col] = textBox3.Text[i];
                        col++;
                    }

                    if (col == 6)
                    {
                        col = 0;
                        row++;
                    }
                }

                for (int i = 0; i < alf.Length; i++)
                {
                    added = true;
                    foreach (char j in secondalf)
                        if (j == alf[i])
                        {
                            added = false;
                            break;
                        }
                    if (added)
                        if (added)
                        {
                            secondalf[row, col] = alf[i];
                            col++;
                        }

                    if (col == 6)
                    {
                        col = 0;
                        row++;
                    }
                }
                newword = "";
                for (int i=0;i<word.Length-1;i+=2)
                {
                    found1 = false;
                    found2 = false;
                    for (int i1 = 0; i1 < 6; i1++)
                    {
                        for (int j1 = 0; j1 < 6; j1++)
                        {
                            if (firstalf[i1, j1] == word[i])
                            {
                                found1 = true;
                                for (int i2 = 0; i2 < 6; i2++)
                                {
                                    for (int j2 = 0; j2 < 6; j2++)
                                    {
                                        if (secondalf[i2, j2] == word[i + 1])
                                        {
                                            found2 = true;
                                            newword += firstalf[i2, j1];
                                            newword += secondalf[i1, j2];
                                        }
                                        if (found2)
                                            break;
                                    }
                                    if (found2)
                                        break;
                                }
                            }
                            if (found1)
                                break;
                        }
                        if (found1)
                            break;
                    }
                }
                textBox4.Text = newword;

            }
        }
    }
}
