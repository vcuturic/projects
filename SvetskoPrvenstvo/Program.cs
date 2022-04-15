using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace vch_innovatec
{
    class Program
    {
        private static readonly string filepath = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            //Console.WriteLine(filepath);
            Funcs funcs = new Funcs();

            List<Reprezentacija> reps = new List<Reprezentacija>();

            string[] lines = System.IO.File.ReadAllLines(filepath + "/ulaz.csv");

            int Afrika = 5;
            int Azija = 5;
            int Evropa = 14;
            int SiCAmerika = 3;
            int Okeanija = 0; // Okeanija i jAmerica igraju za 1 predstavnika
            int juznaAmerika = 4;

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                reps.Add(new Reprezentacija(columns[0], columns[1], int.Parse(columns[2])));
                if (columns[1].Equals("Afrika"))
                    Afrika--;
                else if (columns[1].Equals("Azija"))
                    Azija--;
                else if (columns[1].Equals("Evropa"))
                    Evropa--;
                else if (columns[1].Equals("Severna i Centralna Amerika"))
                    SiCAmerika--;
                else if (columns[1].Equals("Juzna Amerika"))
                    juznaAmerika--;
                else
                    Okeanija--;
            }

            if(Afrika != 0 || Azija !=0 ||
                Evropa !=0 || SiCAmerika !=0 || 
                juznaAmerika+Okeanija != -1 || Okeanija>0 || Okeanija < -1) {
                // condition for error
                Console.WriteLine("Greska pri izvlacenju reprezentacija!");
                Environment.Exit(0);
            }

            // ### SESIRI
            List<List<Reprezentacija>> sesiri = new List<List<Reprezentacija>>();
            Reprezentacija reprezentacija;

            for (int j = 0; j < 4; j++)
            {
                List<Reprezentacija> sesir = new List<Reprezentacija>();
                for (int i = 0; i < 8; i++)
                {
                    reprezentacija = reps.OrderBy(x => x.IHF_rang).First();
                    sesir.Add(reprezentacija);
                    reps.Remove(reprezentacija); 
                }
                sesiri.Add(sesir);
            }
            ///funcs.ispisiSesire(sesiri);

            // II - Grupe
            List<Grupa> grupe = new List<Grupa>();

            funcs.GenerisiGrupe(sesiri, grupe);
            ///funcs.ispisiGrupe(grupe);
            funcs.SacuvajGrupe(grupe); // saving csv

            // III - Generisanje utkamica, cuvanje u .csv fajlu
            List<Utakmica> utakmice = funcs.GenerisiUtakmice(grupe);
            funcs.SacuvajUtakmice(utakmice);

            // IV - Sledeca Faza
            /// i) Dodeljivanje bodova timovima 
            foreach (var utakmica in utakmice)
            {
                if (utakmica.brojGolovaRep1 > utakmica.brojGolovaRep2)
                    utakmica.r1.poeni += 3;
                else if (utakmica.brojGolovaRep1 < utakmica.brojGolovaRep2)
                    utakmica.r2.poeni += 3;
                else
                {
                    utakmica.r1.poeni += 1;
                    utakmica.r2.poeni += 1;
                }
            }
            /// ii) Provera ko je od reprezentacija prosao
            funcs.GenerisiSledecuFazu(grupe);
            funcs.SacuvajSledecuFazu(grupe); // saving sledecaFaza.csv
            ///funcs.ispisiSledecuFazu(grupe);
        }
    }
}
