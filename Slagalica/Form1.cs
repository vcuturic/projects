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

namespace Slagalica_118_2018
{
    public partial class Form1 : Form
    {
        public Engine eng;
        public SlagalicaDB slagalicaDb;
        Login login;
        Registracija reg;
        private string filepath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
        Korisnik korisnik=null;
        Top10 igrac = null;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            eng = new Engine();
            slagalicaDb = new SlagalicaDB();
            foreach (Control c in tlp_mat.Controls)
                if (c is Panel)
                    c.MouseClick +=  new System.Windows.Forms.MouseEventHandler(this.tlp_mat_MouseClick);    
            
            osveziPrikaz();
            osveziTop10();
        }
        private void osveziTop10()
        {
            dgw_top10.Rows.Clear();
            foreach (var item in slagalicaDb.dajTop10())
            {
                DataGridViewRow red = (DataGridViewRow)dgw_top10.Rows[0].Clone();

                red.Cells[0].Value = item.ime;
                red.Cells[1].Value = item.brojPoteza;

                dgw_top10.Rows.Add(red);
            }
        }
        private void osveziPrikaz()
        {
            foreach (Control c in tlp_mat.Controls)
            {
                if (c is Panel)
                {
                    c.BackgroundImage = eng.vratiSliku(eng.matrica[eng.x, eng.y]);
                    if (eng.y == 3) { eng.y = 0; eng.x++; }
                    else eng.y++;
                }
            }
            eng.x = eng.y = 0;
            lbl_potezi.Text = "Potezi: " + eng.brojPoteza;
        }
        private void novaIgra()
        {
            eng.init();
            osveziPrikaz();
            tlp_mat.Enabled = true;
            if(korisnik!=null)
                btn_sacuvajIgru.Enabled = true;
            lbl_potezi.Text = "Potezi: " + eng.brojPoteza;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            novaIgra();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tlp_mat_MouseClick(object sender, MouseEventArgs e)
        {
            /*Console.WriteLine("kolona:" + tlp_mat.GetColumn((Control)sender));
            Console.WriteLine("red:" + tlp_mat.GetRow((Control)sender));*/

            int i, j, rekord;
            i = tlp_mat.GetRow((Control)sender);
            j = tlp_mat.GetColumn((Control)sender);

            bool odigran;
            odigran = eng.odigrajPotez(i, j);
            lbl_potezi.Text = "Potezi: " + eng.brojPoteza;
            if (odigran)
            {
                osveziPrikaz();
                if (eng.proveriPobedu())
                {
                    if (korisnik != null)
                    {
                        rekord = slagalicaDb.dajBrojPotezaSaTopListe(korisnik.ime);
                        Console.WriteLine("REKORD : " + rekord);
                        if (rekord == 0)
                            slagalicaDb.dodajTop10(korisnik.id, korisnik.ime, eng.brojPoteza);
                        else if (eng.brojPoteza < rekord)
                            slagalicaDb.azurirajTop10(korisnik.ime, eng.brojPoteza);
                        osveziTop10();
                    }
                    MessageBoxButtons dugmad = MessageBoxButtons.YesNo;
                    DialogResult rez = MessageBox.Show("Nova partija?", "Pobeda", dugmad);
                    if (rez == DialogResult.Yes)
                        novaIgra();
                    else
                    {
                        tlp_mat.Enabled = false;
                        btn_sacuvajIgru.Enabled = false;
                    }
                    
                }
            }
        }
        private enum Logovanje
        {
            REGULARNO,
            SA_REGISTERA
        }
        private void ulogujSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (korisnik == null)
            {
                login = new Login();
                login.ShowDialog();
                if (login.DialogResult == DialogResult.OK)
                    logovanjeUspesno(Logovanje.REGULARNO);
            }
        }
        private void logovanjeUspesno(Logovanje odakle)
        {
            btn_logout.Enabled = true;
            btn_upr.Enabled = true; // ucitaj poslednje rezultate
            btn_sacuvajIgru.Enabled = true;
            lbl_naopomena.Visible = false;
            if (odakle == Logovanje.REGULARNO)
                korisnik = login.Korisnik;
            else
                korisnik = reg.Korisnik;

            lbl_korisnickoIme.Text = korisnik.ToString();
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            //logout
            korisnik = null;
            btn_logout.Enabled = false;
            btn_upr.Enabled = false; // ucitaj poslednje rezultate
            btn_sacuvajIgru.Enabled = false;
            lbl_naopomena.Visible = true;
            lbl_naopomena.Text = "Naopomena: Neulogovani igraci nece moci da cuvaju rezultate!";

            lbl_korisnickoIme.Text = "NIJE ULOGOVAN";

        }
        private void registracijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //registracija
            if (korisnik == null) { 
                reg = new Registracija();
                reg.ShowDialog();
                if (reg.DialogResult == DialogResult.OK)
                    logovanjeUspesno(Logovanje.SA_REGISTERA);
            }
        }

        private void btn_sacuvajIgru_Click(object sender, EventArgs e)
        {
            string igracFajl = filepath + @"\igraci\"+korisnik.ToString()+".txt";
            //Top10 igrac = null;
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(igracFajl, FileMode.Create, FileAccess.Write);
            //igrac = slagalicaDb.dajKorisnikaSaTopListe(korisnik.ime);

            //formatter.Serialize(stream, igrac.id);
            //formatter.Serialize(stream, igrac.ime);
            formatter.Serialize(stream, eng.brojPoteza);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    formatter.Serialize(stream, eng.matrica[i, j]);
            stream.Close();
        }

        private void btn_upr_Click(object sender, EventArgs e)
        {
            //ucitaj prethodni rezultat
            string igracFajl = filepath + @"\igraci\" + korisnik.ToString() + ".txt";

            IFormatter formatter = new BinaryFormatter();
            try
            {
                Stream stream = new FileStream(igracFajl, FileMode.Open, FileAccess.Read);
                eng.brojPoteza = (int)formatter.Deserialize(stream);
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        eng.matrica[i, j] = (Znak)formatter.Deserialize(stream);
                stream.Close();
                osveziPrikaz();
            }
            catch (Exception)
            {
                lbl_naopomena.Text = "Nema sacuvane igre na ovom nalogu!";
                lbl_naopomena.Visible = true;
            }
        }
    }
}
