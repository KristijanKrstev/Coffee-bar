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
    public partial class Form1 : Form
    {
        public Form2 forma;
        public Form1()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "korisnik" && textBox2.Text == "pas")
            {
                forma = new Form2(1);
                forma.Show();
                textBox1.Text = "";
                textBox2.Text = "";
                return;

            }
            if (textBox1.Text == "vraboten" && textBox2.Text == "pas")
            {
                forma = new Form2(0);
                forma.Show();
                textBox1.Text = "";
                textBox2.Text = "";

                return;
            }
            if ((textBox1.Text == "" || textBox1.Text!="korisnik" || textBox1.Text != "vraboten")  || (textBox2.Text == "" || textBox1.Text != "pas"))
            {
                MessageBox.Show("Внесете точни корисничко име и лозинка");
            }
         
          
            
        }

        private void button1_Validating(object sender, CancelEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
