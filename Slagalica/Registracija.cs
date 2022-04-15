using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slagalica_118_2018
{
    public partial class Registracija : Form
    {
        SlagalicaDB slagalicaDB;
        Korisnik korisnik=null;
        public Registracija()
        {
            InitializeComponent();
            slagalicaDB = new SlagalicaDB();
        }

        public Korisnik Korisnik { get => korisnik; set => korisnik = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            //registracija
            int idIgraca = -1;
            bool skip = false;
            //Console.WriteLine("OPP: "+slagalicaDB.dajBrojKorisnika());
            if (tb_regKorisnicko.Text.Length < 4)
            {
                lbl_regLoseKorisnicko.Text = "Korisnicko ime ne sme biti krace od 4 karaktera!";
                lbl_regLoseKorisnicko.Visible = true;
                skip = true;
            }
            if (!skip) {
                idIgraca = slagalicaDB.dodajKorisnika(tb_regKorisnicko.Text, tb_regLozinka.Text);
                if (idIgraca == -1)
                {
                    lbl_regLoseKorisnicko.Text = "Korisnicko ime vec postoji!";
                    lbl_regLoseKorisnicko.Visible = true;
                }
                else
                {
                    korisnik = new Korisnik(idIgraca, tb_regKorisnicko.Text, tb_regLozinka.Text);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //odustani
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
