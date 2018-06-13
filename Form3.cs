using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    [Serializable]
    public partial class Form3 : Form
    {
        public int suma;
        public Form3(int s)
        {
            suma = s;
            InitializeComponent();
            label5.Text = String.Format("Вашата сметка изнесува {0} денари",suma);
        }
        

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                return;
            }
            int cena = int.Parse(textBox1.Text);
            if(cena-suma<0)
            {
                label1.Visible = true;
                return;
            }
            else
            {
                label1.Visible = false;
                textBox2.Text=String.Format("{0}", cena - suma);
                button5.Visible = true;
                button3.Enabled = false;
       
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox4.Text.Count()==16 && textBox3.Text.Count() == 3)
            {
                foreach(Char c in textBox3.Text)
                {
                    if(!Char.IsDigit(c))
                    {
                        label4.Visible = true;
                        return;
                    }
                }
                foreach (Char c in textBox4.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        label4.Visible = true;
                        return;
                    }
                }
                label4.Visible = false;
                button4.Enabled = false;
                button6.Visible = true;
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
