using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    [Serializable]
    public partial class Form2 : Form
    {
        public List<Pijalok> pijaloci=new List<Pijalok>();
        public List<Pijalok> pijalociL1 = new List<Pijalok>();
        public Form3 forma3;
        public int kv { get; set; } // 1-korisnik 0-vraboten
        public String FileName { get; set; }

        public Form2(int k)
        {
            kv = k;
            
            InitializeComponent();
            if(kv==1)
            {
                button1.Visible = false;
                button2.Visible = false;
                label4.Visible = true;
                checkedListBox1.Visible = true;
                textBox3.Visible = true;
                button5.Visible = true;
                button3.Visible = true;
                listBox1.Visible = true;

            }
        }

       


        private void Form2_Load(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\baza.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            
             FileName =path;


            string[] lines = File.ReadAllLines(FileName);
            foreach(String l in lines)
            {
                string[] red = l.Split('-');
                Pijalok p = new Pijalok(red[0],int.Parse(red[1]),int.Parse(red[2]));
                pijaloci.Add(p);

            }
            updateCH1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            checkedListBox1.Items.Clear();
            groupBox1.Visible = false;
            label4.Visible = true;
            textBox5.Visible = true;
            label5.Visible = true;
           // listBox1.Visible = true;
           // button5.Visible = true;
            checkedListBox1.Visible = true;
            foreach(Pijalok p in pijaloci)
            {
                checkedListBox1.Items.Add(p.ToString());

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 1)
            {

                int br = 0;
                if (textBox3.Text=="")
                {
                    textBox3.Text = "1";
                    br = 1;
                }
                else
                {
                    br =int.Parse( textBox3.Text);
                }

                Pijalok cekiran = (Pijalok)checkedListBox1.SelectedItem;

                for (int i = 0; i < pijaloci.Count; i++)
                {
                    if (cekiran != null)
                    {
                        if (pijaloci[i].ime == cekiran.ime)
                        {
                           
                            if (pijaloci[i].kolicina < br)
                            {
                                MessageBox.Show(String.Format("Од тој производ има преостанато уште {0}", pijaloci[i].kolicina));
                            }
                            else
                            {
                                pijaloci[i].kolicina -=br;
                                pijalociL1.Add(new Pijalok(pijaloci[i].ime, br, pijaloci[i].cena));
                                if (pijaloci[i].kolicina == 0)
                                {
                                    pijaloci.RemoveAt(i);
                                    
                                }
                                updateCH1();
                                updateL1();
                            }
                        }
                        textBox3.Text = "";
                        
                    }

                    using (System.IO.StreamWriter file =
          new System.IO.StreamWriter(FileName))
                    {
                        foreach (Pijalok a in pijaloci)
                        {
                            

                            file.WriteLine(a.ToString());

                        }
                    }


                    textBox3.Text = "";

                }
            


                
            }
        }

     

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                button5.Enabled = true;
                textBox3.Enabled = true;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            label4.Visible = true;
            textBox5.Visible = false;
            label5.Visible = false;
            //listBox1.Visible = true;
           // button5.Visible = true;
            groupBox1.Visible = true;
            checkedListBox1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="" || textBox4.Text=="")
            {
               
                return;


            }
            foreach (Char cc in textBox2.Text)
            {
                if (!Char.IsDigit(cc))
                {
                    label4.Visible = true;
                    return;
                }
            }
            foreach (Char cc in textBox4.Text)
            {
                if (!Char.IsDigit(cc))
                {
                    label4.Visible = true;
                    return;
                }
            }


            String i = textBox1.Text;
            int k = int.Parse(textBox2.Text);
            int c = int.Parse(textBox4.Text);
            if(proveridalipostoi(i))
            {
                MessageBox.Show("Овој пијалок веќе постои");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                return;
            }
            pijaloci.Add(new Pijalok(i, k,c));
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            updateCH1();


            using (System.IO.StreamWriter file =
          new System.IO.StreamWriter(FileName))
            {
                foreach (Pijalok p in pijaloci)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.

                    file.WriteLine(p.ToString());

                }
            }


        }
        private void updateCH1()
        {
            checkedListBox1.Items.Clear();
            foreach(Pijalok p in pijaloci)
            {
                checkedListBox1.Items.Add(p);
            }
        }
        private void updateL1()
        {
            listBox1.Items.Clear();
            foreach (Pijalok p in pijalociL1)
            {
                listBox1.Items.Add(p);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count==0)
            {
                return;
            }
       
       
            int suma = 0;
            foreach(Pijalok p in listBox1.Items)
            {
                suma += p.kolicina * p.cena;
            }
            forma3 = new Form3(suma);
            forma3.Show();
            this.Close();
       
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 1 && textBox5.Text!="")
            {
                int k = int.Parse(textBox5.Text);
                if (checkedListBox1.SelectedItems.Count == 0) return;
                String p1 = checkedListBox1.SelectedItem.ToString();
                Pijalok nov = null;
                int index = 0;
                foreach (Pijalok pi in pijaloci)
               

                {
                    if (pi.ToString() == p1)
                    {
                       
                        pi.kolicina += k;
                        nov = new Pijalok(pi.ime, pi.kolicina, pi.cena);
                        index++;
                        break;
                    }
                    index++;
                }
                pijaloci.RemoveAt(index-1);
                pijaloci.Add(nov);
               

                updateCH1();
                textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Изберете само 1 пијалок");
            }
            using (System.IO.StreamWriter file =
          new System.IO.StreamWriter(FileName))
            {
                foreach (Pijalok p in pijaloci)
                {
                    

                    file.WriteLine(p.ToString());

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count!=0)
            {
                MessageBox.Show("Имате изберено пијалоци, Ве молиме платете ја сметката! Благодариме на разбирањето");
                return;
            }
            this.Close();
        }

        private bool proveridalipostoi(String g)
        {
            foreach(Pijalok p in checkedListBox1.Items)
            {
                if(p.ime==g)
                {
                    return true;
                }
            }
            return false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void button8_Click(object sender, EventArgs e)
        {
             
       
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
