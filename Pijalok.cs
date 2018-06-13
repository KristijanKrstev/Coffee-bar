using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    [Serializable]
    public class Pijalok
    {
        public String ime { get; set; }
        public int kolicina { get; set; }
        public int cena { get; set; }
        public Pijalok(String s,int k,int c)
        {
            cena = c;
            ime = s;
            kolicina = k;
        }
        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}", ime, kolicina,cena);
        }
    }
}

