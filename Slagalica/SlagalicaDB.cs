using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slagalica_118_2018
{
    public class SlagalicaDB
    {
        SqliteConnection conn = KonekcijaDB.Instance;

        public Top10 dajKorisnikaSaTopListe(string ime)
        {
            Top10 k = null;
            string q = "select * from najbolji where ime = '"+ime+"'";
            var komanda = conn.CreateCommand();
            komanda.CommandText = q;

            conn.Open();
            try
            {
                using (var reader = komanda.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        k = new Top10(int.Parse(reader["id"].ToString()),
                                        reader["ime"].ToString(),
                                        int.Parse(reader["brojPoteza"].ToString())
                                        );
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
            conn.Close();
            return k;
        }
        public int dajBrojPotezaSaTopListe(string ime)
        {
            int broj = 0;
            string q = "select brojPoteza from najbolji where ime = '"+ime+"'";
            var komanda = conn.CreateCommand();
            komanda.CommandText = q;

            conn.Open();
            try
            {
                using (var reader = komanda.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        broj = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception)
            {
                //
            }
            
            conn.Close();
            return broj;
        }
        public int dajBrojKorisnika()
        {
            int broj = 0;
            string q = "select count(*) from korisnici";
            var komanda = conn.CreateCommand();
            komanda.CommandText = q;

            conn.Open();
            using(var reader = komanda.ExecuteReader())
            {
                if (reader.Read())
                {
                    broj = reader.GetInt32(0);
                }
            }
            conn.Close();
            return broj;
        }
        public int dodajKorisnika(string ime, string pw)
        {
            int idkorisnika = dajBrojKorisnika() + 1;
            string q = "insert into korisnici(id,ime,pw) values(" + idkorisnika + ", '" + ime + "', '" + pw + "')";
            var komanda = conn.CreateCommand();
            komanda.CommandText = q;
            conn.Open();
            try { komanda.ExecuteNonQuery(); }
            catch (Exception)
            {
                //throw new Exception("Korisnicko ime je duplikat!");
                return -1;
            }
            conn.Close();
            return idkorisnika;
        }
        public Korisnik proveriKorisnika(string ime , string sifra)
        {
            Korisnik k = null;

            string q = "select * from korisnici where ime = '"+ime+"' and pw='"+sifra+"'";

            var komanda = conn.CreateCommand();
            komanda.CommandText = q;

            conn.Open();
            using(var reader = komanda.ExecuteReader())
            {
                if (reader.Read())
                {
                    k = new Korisnik(int.Parse(reader["id"].ToString()),
                                    reader["ime"].ToString(),
                                    reader["pw"].ToString());
                }
            }
            conn.Close();
            return k;
        }
        
        public bool azurirajTop10(string ime, int brojPoteza)
        {
            string q = "update najbolji where ime = '"+ime+"' set brojPoteza = " + brojPoteza;
            var komanda = conn.CreateCommand();
            komanda.CommandText = q;

            conn.Open();

            try { komanda.ExecuteNonQuery(); }
            catch (Exception) { return false; }
            
            conn.Close();
            return true;
        }
        public void dodajTop10(int id, string ime , int brojpoteza)
        {
            string q = "insert into najbolji(id,ime,brojPoteza) values("+id+", '"+ime+"', "+brojpoteza+");";
            var komanda = conn.CreateCommand();
            komanda.CommandText = q;

            conn.Open();
                komanda.ExecuteNonQuery();
            conn.Close();
        }
        public List<Top10> dajTop10()
        {
            List<Top10> lista = new List<Top10>();
            string q = "select * from najbolji order by brojPoteza ASC LIMIT 10";

            var komanda = conn.CreateCommand();
            komanda.CommandText = q;

            conn.Open();
            using(var reader = komanda.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Top10(int.Parse(reader["id"].ToString()), 
                                        reader["ime"].ToString(),
                                        int.Parse(reader["brojPoteza"].ToString())
                                        ));
                }
            }

            conn.Close();
            return lista;
        }
    }
}
