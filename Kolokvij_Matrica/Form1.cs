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

namespace Kolokvij_Matrica
{
    public partial class Form1 : Form
    {
        public string path = @"C:\Users\Antun\Desktop\text.txt";

        public Form1()
        {
            
            InitializeComponent();
            Matrica();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Matrica();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpisiPodatke();
        }

        public void UpisiPodatke()
        {
            try
            {
                if (File.Exists(path))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text + ";");
                        sw.WriteLine(textBox4.Text + ";" + textBox5.Text + ";" + textBox6.Text + ";");
                        sw.WriteLine(textBox7.Text + ";" + textBox8.Text + ";" + textBox9.Text + ";");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Matrica()
        {
            string line = "";
            string[] spremnik = new string[9];
            string spremiste = "";
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            spremiste += line;                           
                        }
                    }                   
                    spremnik = spremiste.Split(';');
                    textBox1.Text = spremnik[0];
                    textBox2.Text = spremnik[1];
                    textBox3.Text = spremnik[2];
                    textBox4.Text = spremnik[3];
                    textBox5.Text = spremnik[4];
                    textBox6.Text = spremnik[5];
                    textBox7.Text = spremnik[6];
                    textBox8.Text = spremnik[7];
                    textBox9.Text = spremnik[8];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SumaMatrice()
        {
            int zbrojPrviStupac = Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox4.Text) + Convert.ToInt32(textBox7.Text);
            int zbrojDrugiStupac = Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox8.Text);
            int zbrojTreciSupac = Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox6.Text) + Convert.ToInt32(textBox9.Text);
            
                textBox10.Text = "Suma: \n\r";
            textBox10.Text += zbrojPrviStupac.ToString() + ";" + zbrojDrugiStupac.ToString() + ";" + zbrojTreciSupac.ToString()+";";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
               textBox10.Text+= "Najmanji broj matrice: "+ MinimumMatrice();
            }else if (radioButton2.Checked)
            {
                textBox10.Text += "Najveci broj matrice: "+MaximumMatrice();
            }
        }

        private string MaximumMatrice()
        {
            return getAllNumbersSorted()[getAllNumbersSorted().Count()-1 ].ToString();

        }

        private string MinimumMatrice()
        {
            return getAllNumbersSorted()[0].ToString();
        }
        private int[] getAllNumbersSorted()
        {
            int[] mem = new int[9];
            mem[0] = Convert.ToInt32(textBox1.Text);
            mem[1] = Convert.ToInt32(textBox2.Text);
            mem[2] = Convert.ToInt32(textBox3.Text);
            mem[3] = Convert.ToInt32(textBox4.Text);
            mem[4] = Convert.ToInt32(textBox5.Text);
            mem[5] = Convert.ToInt32(textBox6.Text);
            mem[6] = Convert.ToInt32(textBox7.Text);
            mem[7] = Convert.ToInt32(textBox8.Text);
            mem[8] = Convert.ToInt32(textBox9.Text);

            Array.Sort(mem);

            return mem;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            SumaMatrice();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            SumaMatrice();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            SumaMatrice();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            SumaMatrice();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            SumaMatrice();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            SumaMatrice();
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            SumaMatrice();
        }
    }
}
