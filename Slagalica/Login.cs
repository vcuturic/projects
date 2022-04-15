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
    public partial class Login : Form
    {
        SlagalicaDB slagalicaDb = null;
        private Korisnik korisnik = null;

        public Korisnik Korisnik { get => korisnik; set => korisnik = value; }

        public Login()
        {
            InitializeComponent();
            slagalicaDb = new SlagalicaDB();
        }

        private void btn_prijava_Click(object sender, EventArgs e)
        {
            
            Korisnik = slagalicaDb.proveriKorisnika(tb_korisnickoIme.Text, tb_lozinka.Text);
            if (Korisnik != null)
                this.DialogResult = DialogResult.OK;
            
            else
            {
                lbl_losLogin.Visible = true;
                //Console.WriteLine("POGRESNO KORISNICKO IME / LOZINKA!");
            }
        }

        private void btn_odustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
