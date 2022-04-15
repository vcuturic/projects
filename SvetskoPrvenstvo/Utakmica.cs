using System;
using System.Collections.Generic;
using System.Text;

namespace vch_innovatec
{
    public class Utakmica
    {
        public Grupa grupa;
        public Reprezentacija r1;
        public Reprezentacija r2;
        public int brojGolovaRep1;
        public int brojGolovaRep2;

        public Utakmica() { }
        public Utakmica(Grupa grupa, Reprezentacija r1, Reprezentacija r2, int brojGolovaRep1, int brojGolovaRep2)
        {
            this.grupa = grupa;
            this.r1 = r1;
            this.r2 = r2;
            this.brojGolovaRep1 = brojGolovaRep1;
            this.brojGolovaRep2 = brojGolovaRep2;
        }
    }
}
