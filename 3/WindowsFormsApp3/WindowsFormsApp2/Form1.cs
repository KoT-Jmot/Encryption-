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
        string alf = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_-,.";
        string myalf="";
        string code = "";
        string newcode = "";
        bool add = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox5.Text != "")
            {
                myalf = "";
                for(int i=0;i<textBox2.TextLength;i++)
                {
                    add = true;
                    for (int j = 0; j < myalf.Length; j++)
                        if (textBox2.Text[i] == myalf[j])
                            add = false;
                    if (add)
                        myalf += textBox2.Text[i];
                }
                for (int i = 0; i < alf.Length; i++)
                {
                    add = true;
                    for (int j = 0; j < myalf.Length; j++)
                        if (alf[i] == myalf[j])
                            add = false;
                    if (add)
                        myalf += alf[i];
                }
                code = "";
                for (int i = 0; i < textBox1.TextLength; i++)
                    if (textBox1.Text[i] == ' ')
                        code += '_';
                    else
                        code += textBox1.Text[i];


                newcode = "";
                for(int i=0;i<code.Length;i++)
                {
                    for(int j=0;j<myalf.Length;j++)
                        if(code[i]==myalf[j])
                        {
                            if( j + int.Parse(textBox3.Text) <0)
                            {
                                newcode += myalf[j + (myalf.Length - 1) + int.Parse(textBox3.Text)];
                            }
                            else if(j + int.Parse(textBox3.Text) >= myalf.Length)
                            {
                                newcode += myalf[j - (myalf.Length - 1) + int.Parse(textBox3.Text)];
                            }
                            else
                            {
                                newcode += myalf[j + int.Parse(textBox3.Text)];
                            }
                            break;
                        }
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
            if (textBox5.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                myalf = "";
                using (StreamReader sr = new StreamReader(textBox5.Text + ".txt"))
                {
                    word = sr.ReadLine();
                }
                    for (int i = 0; i < textBox2.TextLength; i++)
                {
                    add = true;
                    for (int j = 0; j < myalf.Length; j++)
                        if (textBox2.Text[i] == myalf[j])
                            add = false;
                    if (add)
                        myalf += textBox2.Text[i];
                }
                for (int i = 0; i < alf.Length; i++)
                {
                    add = true;
                    for (int j = 0; j < myalf.Length; j++)
                        if (alf[i] == myalf[j])
                            add = false;
                    if (add)
                        myalf += alf[i];
                }
                code = "";
                for (int i = 0; i < word.Length; i++)
                    if (word[i] == ' ')
                        code += '_';
                    else
                        code += word[i];


                newcode = "";
                for (int i = 0; i < code.Length; i++)
                {
                    for (int j = 0; j < myalf.Length; j++)
                        if (code[i] == myalf[j])
                        {
                            if (j - int.Parse(textBox3.Text) < 0)
                            {
                                newcode += myalf[j + (myalf.Length - 1) - int.Parse(textBox3.Text)];
                            }
                            else if (j - int.Parse(textBox3.Text) >= myalf.Length)
                            {
                                newcode += myalf[j - (myalf.Length - 1) - int.Parse(textBox3.Text)];
                            }
                            else
                            {
                                newcode += myalf[j - int.Parse(textBox3.Text)];
                            }
                            break;
                        }
                }
                textBox4.Text = newcode;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char povt;
            int kol;
            int maxkol=0;
            char maxpovt=' ';
            for (int i=0; i<textBox4.TextLength;i++)
            {
                povt = textBox4.Text[i];
                kol = 0;
                for (int j = 0; j < textBox4.TextLength; j++)
                    if (textBox4.Text[i] == textBox4.Text[j])
                        kol++;
                if(kol>maxkol)
                {
                    maxkol = kol;
                    maxpovt = povt;
                }
            }
            textBox6.Text = Convert.ToString(maxpovt);
        }
    }
}
