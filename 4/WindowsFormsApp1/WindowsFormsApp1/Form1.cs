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

        string word;
        char[] a = new char[9];
        int a1;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            if (textBox1.Text != "")
            {
                word = textBox1.Text;
                while (word.Length < 9)
                    word += " ";
                a[0] = word[1];
                a[1] = word[6];
                a[2] = word[5];
                a[3] = word[8];
                a[4] = word[4];
                a[5] = word[0];
                a[6] = word[3];
                a[7] = word[2];
                a[8] = word[7];
                for (int i = 0; i < 9; i++)
                {
                        textBox2.Text += a[i];
                }
                using (StreamWriter sw = File.CreateText("1.txt"))
                {
                    sw.WriteLine(textBox2.Text);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("1.txt"))
            {
                word = sr.ReadLine();
            }
            textBox2.Text = "";
            a[0] = word[5];
            a[1] = word[0];
            a[2] = word[7];
            a[3] = word[6];
            a[4] = word[4];
            a[5] = word[2];
            a[6] = word[1];
            a[7] = word[8];
            a[8] = word[3];
            for (int i = 0; i < 9; i++)
            {
                textBox2.Text += a[i];
            }
        }
    }
}
