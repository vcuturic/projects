using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace vch_innovatec
{
    public class Funcs
    {
        public List<Utakmica> GenerisiUtakmice(List<Grupa> grupe)
        {
            // SVAK IGRA SA SVAKIM ALI SAMO 1 UTKAMNICU
            // EKIPA 1 IGRA SA 2 SA 3 SA 4
            // EKIPA 2 SA 3 SA 4
            // EKIPA 3 SA 4
            Random r2 = new Random();
            List<Utakmica> utakmice = new List<Utakmica>();
            int nazivGrupe = 65;
            int brojGolovaRep1;
            int brojGolovaRep2;
            for (int i = 0; i < grupe.Count; i++)
            {
                Grupa grupa = grupe[i];
                for (int j = 0; j < grupa.reprezentacijas.Count; j++) // reprezentacija 1
                {
                    for (int t = j + 1; t < grupa.reprezentacijas.Count; t++) // reprezentacija 2
                    {
                        brojGolovaRep1 = r2.Next(50);
                        brojGolovaRep2 = r2.Next(50);
                        grupa.reprezentacijas[j].koefGolova += brojGolovaRep1 - brojGolovaRep2;
                        grupa.reprezentacijas[t].koefGolova += brojGolovaRep2 - brojGolovaRep1;
                        utakmice.Add(new Utakmica(grupa, grupa.reprezentacijas[j], grupa.reprezentacijas[t], brojGolovaRep1, brojGolovaRep2));
                    }
                }
                nazivGrupe++;
            }
            return utakmice;
        }
        public void SacuvajUtakmice(List<Utakmica> utakmice)
        {
            using StreamWriter sw = new StreamWriter("rezultatiUtakmica.csv");
            //{
            foreach (var utakmica in utakmice)
            {
                sw.WriteLine(utakmica.grupa.naziv+","+ utakmica.r1.ime_reprezentacije+ "," + utakmica.r2.ime_reprezentacije + "," + utakmica.brojGolovaRep1 + "," + utakmica.brojGolovaRep2);
            }
            //}
        }
        public bool ProveriKvalZonu(string kvalZona, List<string> kvalZone)
        {
            if (kvalZone.Contains(kvalZona))
                return false;
            return true;
        }
        public void GenerisiGrupe(List<List<Reprezentacija>> sesiri, List<Grupa> grupe)
        {
            Random r = new Random();
            int index; // random index of country from Pot
            bool first = true; // just an flag

            // ideja: Imamo niz kvalifikacionih zona u duzini grupe
            List<int> kvalZonaEvropa = new List<int>();
            List<List<string>> kvalZone = new List<List<string>>();
            string kvalZona;

            int nazivGrupe = 65;

            foreach (var sesir in sesiri)
            {
                for (int j = 0; j < 8; j++) // grupe
                {
                    if (first) // first loop through 8 groups
                    {
                        grupe.Add(new Grupa());
                        grupe[j].reprezentacijas = new List<Reprezentacija>();
                        grupe[j].naziv = Convert.ToChar(nazivGrupe);
                        //
                        kvalZone.Add(new List<string>()); // adding a new list of strings so we can access it
                        kvalZonaEvropa.Add(0);
                        nazivGrupe++;
                    }
                    index = r.Next(sesir.Count);
                    kvalZona = sesir[index].kvalifikaciona_zona;
                    if (kvalZona.Equals("Evropa") && kvalZonaEvropa[j] < 2)
                    {
                        kvalZonaEvropa[j]++;
                    }
                    else
                        while (!ProveriKvalZonu(kvalZona, kvalZone[j]))
                        {
                            index = r.Next(sesir.Count);
                            kvalZona = sesir[index].kvalifikaciona_zona;
                        }
                    kvalZone[j].Add(kvalZona);
                    grupe[j].reprezentacijas.Add(sesir[index]);
                    sesir.RemoveAt(index);
                }
                if (first)
                    first = false;
            }
        }
        public void IspisiGrupe(List<Grupa> grupe)
        {
            Console.WriteLine("GRUPE: ");
            Console.WriteLine("------------------------------------------");
            foreach (var grupa in grupe)
            {
                foreach (var item in grupa.reprezentacijas)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("");
            }
        }
        public void SacuvajGrupe(List<Grupa> grupe)
        {
            int rbr = 1;
            using StreamWriter sw = new StreamWriter("grupe.csv");
            //{
                foreach (var grupa in grupe)
                {
                    sw.Write("" + grupa.naziv + ",");
                    foreach (var item in grupa.reprezentacijas)
                    {
                        sw.Write(rbr.ToString() + ". " + item.ime_reprezentacije + ",");
                        rbr++;
                    }
                    rbr = 1;
                    sw.WriteLine();
                }
            //}
        }
        public void GenerisiSledecuFazu(List<Grupa> grupe)
        {
            List<int> veciOd = new List<int>(); 
            // koristi se po grupi, koliko puta svaka reprezentacija ima vise Bodova od ostalih.

            foreach (var grupa in grupe)
            {
                for (int i = 0; i < 4; i++)
                    veciOd.Add(0); // adding item so we can access it later.
                for (int i = 0; i < grupa.reprezentacijas.Count; i++)
                {
                    for (int j = i + 1; j < grupa.reprezentacijas.Count; j++)
                    {
                        if (grupa.reprezentacijas[i].poeni > grupa.reprezentacijas[j].poeni)
                            veciOd[i]++;
                        else if (grupa.reprezentacijas[i].poeni < grupa.reprezentacijas[j].poeni)
                            veciOd[j]++;
                        else
                        {
                            if (grupa.reprezentacijas[i].koefGolova >= grupa.reprezentacijas[j].koefGolova)
                                veciOd[i]++;
                            else
                                veciOd[j]++;
                        }
                    }
                }
                for (int k = 0; k < 3; k++)
                {
                    int repID = veciOd.IndexOf(veciOd.OrderByDescending(x => x).First());
                    grupa.reprezentacijas[repID].prosao = true;
                    veciOd[repID] = -1;
                }
                veciOd.Clear();

            }
        }
        public void SacuvajSledecuFazu(List<Grupa> grupe)
        {
            int rbr = 1;
            string prosao;
            using StreamWriter sw = new StreamWriter("sledecaFaza.csv");
            //{
            foreach (var grupa in grupe)
            {
                sw.Write("" + grupa.naziv + ",");
                foreach (var item in grupa.reprezentacijas)
                {
                    prosao = item.prosao ? " - prosao" : "";
                    sw.Write(rbr.ToString() + ". " + item.ime_reprezentacije + prosao +",");
                    rbr++;
                }
                rbr = 1;
                sw.WriteLine();
            }
            //}
        }
        public void IspisiSledecuFazu(List<Grupa> grupe)
        {
            Console.WriteLine("SLEDECA FAZA: ");
            Console.WriteLine("------------------------------------------");
            string prosao;
            foreach (var grupa in grupe)
            {
                Console.WriteLine(grupa.naziv);
                foreach (var item in grupa.reprezentacijas)
                {
                    prosao = item.prosao ? " - prosao" : " - nije";
                    Console.WriteLine("\t" + item.ime_reprezentacije + " " + item.poeni + prosao);
                }
            }
        }
        public void IspisiSesire(List<List<Reprezentacija>> sesiri)
        {
            Console.WriteLine("SESIRI: ");
            Console.WriteLine("------------------------------------------");
            foreach (var list in sesiri)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("##");
            }
        }
    }
}
