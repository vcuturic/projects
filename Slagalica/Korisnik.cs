using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slagalica_118_2018
{
    public class Korisnik
    {
        public int id;
        public string ime;
        public string lozinka;

        public Korisnik(int id, string ime, string lozinka)
        {
            this.id = id;
            this.ime = ime;
            this.lozinka = lozinka;
        }

        public override string ToString()
        {
            return ime;
        }
    }
}
