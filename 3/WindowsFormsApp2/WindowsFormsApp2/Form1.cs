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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string alf = "abcdefghijklmnopqrstuvwxyz*-,.";
        char[,] myalf = new char[6, 6];
        string code = "";
        string newcode = "";
        bool add = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="" && textBox5.Text != "")
            {
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 6; j++)
                        myalf[i, j] = ' ';
                int i1=0;
                int j1=0;
                for(int i=0;i<textBox2.TextLength;i++)
                {
                    add = true;
                    for (int ii = 0; ii < 6; ii++)
                        for (int jj=0;jj<6;jj++)
                            if (textBox2.Text[i] == myalf[ii,jj])
                                add = false;
                    if (add)
                    {
                        myalf[i1,j1] = textBox2.Text[i];
                        j1++;
                        if(j1==6)
                        {
                            j1 = 0;
                            i1++;
                        }
                    }
                }
                for (int i = 0; i < alf.Length; i++)
                {
                    add = true;
                    for (int ii = 0; ii < 6; ii++)
                        for (int jj = 0; jj < 6; jj++)
                            if (alf[i] == myalf[ii, jj])
                                add = false;
                    if (add)
                    {
                        myalf[i1, j1] = alf[i];
                        j1++;
                        if (j1 == 6)
                        {
                            j1 = 0;
                            i1++;
                        }
                    }
                }
                code = "";
                for (int i = 0; i < textBox1.TextLength; i++)
                    if (textBox1.Text[i] == ' ')
                        code += '*';
                    else
                        code += textBox1.Text[i];


                newcode = "";
                for(int i=0;i<code.Length;i++)
                    for (int ii = 0; ii < 6; ii++)
                        for (int jj = 0; jj < 6; jj++)
                            if(code[i]==myalf[ii,jj])
                            {
                                if (ii == 5)
                                    newcode += myalf[0, jj];
                                else
                                    newcode += myalf[ii + 1, jj];
                            }
                textBox4.Text = newcode;
                using (StreamWriter sw = File.CreateText(textBox5.Text + ".txt")) 
                {
                    sw.WriteLine(newcode);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string word="";
            if (textBox5.Text != "" && textBox2.Text != "")
            {
                for(int i=0;i<6;i++)
                    for(int j=0;j<6;j++)
                        myalf[i,j]=' ';
                using (StreamReader sr = new StreamReader(textBox5.Text + ".txt"))
                {
                    word = sr.ReadLine();
                }
                int i1 = 0;
                int j1 = 0;
                for (int i = 0; i < textBox2.TextLength; i++)
                {
                    add = true;
                    for (int ii = 0; ii < 6; ii++)
                        for (int jj = 0; jj < 6; jj++)
                            if (textBox2.Text[i] == myalf[ii, jj])
                                add = false;
                    if (add)
                    {
                        myalf[i1, j1] = textBox2.Text[i];
                        j1++;
                        if (j1 == 6)
                        {
                            j1 = 0;
                            i1++;
                        }
                    }
                }
                for (int i = 0; i < alf.Length; i++)
                {
                    add = true;
                    for (int ii = 0; ii < 6; ii++)
                        for (int jj = 0; jj < 6; jj++)
                            if (alf[i] == myalf[ii, jj])
                                add = false;
                    if (add)
                    {
                        myalf[i1, j1] = alf[i];
                        j1++;
                        if (j1 == 6)
                        {
                            j1 = 0;
                            i1++;
                        }
                    }
                }
                code = "";
                for (int i = 0; i < word.Length; i++)
                    if (word[i] == ' ')
                        code += '*';
                    else
                        code += word[i];


                newcode = "";
                for (int i = 0; i < code.Length; i++)
                    for (int ii = 0; ii < 6; ii++)
                        for (int jj = 0; jj < 6; jj++)
                            if (code[i] == myalf[ii, jj])
                            {
                                if (ii == 0)
                                    newcode += myalf[5, jj];
                                else
                                    newcode += myalf[ii - 1, jj];
                            }
                textBox4.Text = newcode;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kol=0;
            for (int i = 0; i < textBox1.TextLength; i++)
                if (textBox1.Text[i] == ' ')
                    kol++;
            textBox6.Text = Convert.ToString(kol);

        }
    }
}
