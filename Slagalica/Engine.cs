using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slagalica_118_2018
{
    public enum Znak
    {
        PIK,
        KARO,
        TREF,
        SRCE,
        PRAZNO
    }
    public class Engine
    {
        public int x, y, brojPoteza;
        public Znak[,] matrica;
        public Engine()
        {
            init();
        }

        public void init()
        {
            x = y = brojPoteza = 0;
            matricaInit();
            
        }

        private void matricaInit()
        {
            matrica = new Znak[4, 4];
            int[] brojZnakova = new int[4];
            brojZnakova[0] = 0;
            brojZnakova[1] = 0;
            brojZnakova[2] = 0;
            brojZnakova[3] = 0;


            Random rand = new Random();
            int znak;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                { 
                    do
                    {
                        znak = rand.Next(0, 4);
                    } while (brojZnakova[znak] == 4);

                    brojZnakova[znak]++;
                    matrica[i, j] = (Znak)znak;
                }
            }
            matrica[rand.Next(0, 4), rand.Next(0, 4)] = Znak.PRAZNO;          
        }
        public bool odigrajPotez(int x, int y)
        {
            bool ind = true;
            if (x - 1 >= 0 && matrica[x - 1, y] == Znak.PRAZNO)
                matrica[x - 1, y] = matrica[x, y];

            else if(y - 1 >= 0 && matrica[x, y-1] == Znak.PRAZNO)
                matrica[x, y-1] = matrica[x, y];

            else if (x + 1 < 4 && matrica[x+1, y] == Znak.PRAZNO)
                matrica[x+1, y] = matrica[x, y];

            else if (y + 1 < 4 && matrica[x, y+1] == Znak.PRAZNO)
                matrica[x, y+1] = matrica[x, y];
            else
                 ind = false;

            if (ind)
            {
                matrica[x, y] = Znak.PRAZNO;
                brojPoteza++;
            }
            return ind;
        }
        public bool proveriPobedu()
        {
            bool ind = false;
            bool vrste = true;
            bool kolone= true;

            int brojac = 0;
            Znak znak;
            // # 1 da proveri vrste
            for (int i = 0; i < 4; i++)
            {
                ind = false;
                brojac = 0;
                if(matrica[i, 0] != Znak.PRAZNO)
                    znak = matrica[i, 0];
                else
                    znak = matrica[i, 1];
                for (int j = 0; j < 4; j++)
                {
                    if (matrica[i, j] == Znak.PRAZNO)
                    {
                        ind = true;
                        break;
                    }
                    if (matrica[i, j] == znak)
                        brojac++;
                }
                if (ind)
                    continue;
                if(brojac != 4) {
                    vrste = false;
                    break;
                }
                
            }
            if (vrste)
                return true;
            for (int i = 0; i < 4; i++)
            {
                ind = false;
                brojac = 0;
                if (matrica[0, i] != Znak.PRAZNO)
                    znak = matrica[0, i];
                else
                    znak = matrica[1, i];
                for (int j = 0; j < 4; j++)
                {
                    if (matrica[j, i] == Znak.PRAZNO)
                    {
                        ind = true;
                        break;
                    }
                    if (matrica[j, i] == znak)
                        brojac++;
                }
                if (ind)
                    continue;
                if (brojac != 4)
                {
                    kolone = false;
                    break;
                }

            }
            if (kolone)
                return true;
            return false;

        }
        public System.Drawing.Bitmap vratiSliku(Znak znak)
        {
            switch (znak)
            {
                case Znak.KARO:
                    return Properties.Resources.karo;
                case Znak.PIK:
                    return Properties.Resources.pik;
                case Znak.SRCE:
                    return Properties.Resources.hearts;
                case Znak.TREF:
                    return Properties.Resources.tref;
                default:
                    return Properties.Resources.prazno;
            }
        }

    }
}
