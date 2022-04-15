using System;
using System.Collections.Generic;
using System.Text;

namespace vch_innovatec
{
    public class Reprezentacija
    {
        public string ime_reprezentacije;
        public string kvalifikaciona_zona;
        public int IHF_rang;
        public int poeni;
        public int koefGolova;
        public bool prosao;

        public Reprezentacija(string ime_reprezentacije, string kvalifikaciona_zona, int iHF_rang)
        {
            this.ime_reprezentacije = ime_reprezentacije;
            this.kvalifikaciona_zona = kvalifikaciona_zona;
            IHF_rang = iHF_rang;
            poeni = 0;
            koefGolova = 0;
            prosao = false;
        }

        public override string ToString()
        {
            return ime_reprezentacije + " " + kvalifikaciona_zona + " " + IHF_rang ;
        }
    }
}
