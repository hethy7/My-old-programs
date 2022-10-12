using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendezesi_alg
{
    class Tomb
    {
        private int n; // tömb mérete

        // tömb
        private int[] tomb;
        public int[] tombLeker // tömb getter
        {
            get { return tomb; }
        }

        // a tömb elemi alapértelmezetten 0..9 lehetnek
        private int m = 10;
        public int maxelem // max elem getter + setter
        {
            get { return m; }
            set { m = value + 1; frissites(); }
        }

        Random rand = new Random();

        // CONSTRUCTOR
        public Tomb(int n)
        {
            this.n = n;
            tomb = new int[n];

            for (int i = 0; i < n; i++)
            {
                tomb[i] = rand.Next(m);
            }
        }

        // tömb kiíratása
        public void tombKiiras()
        {
            String s = "";
            foreach (int szam in tomb)
            {
                s += szam.ToString() + ", ";
            }
            Console.WriteLine("A tömb elemei: " + s + "\n");
        }

        // megadott tömb kiíratása 
        public void tombKiiras(int[] tomb1)
        {
            String s = "";
            foreach (int szam in tomb1)
            {
                s += szam.ToString() + ", ";
            }
            Console.WriteLine("A tömb elemei: " + s + "\n");
        }

        // tömb eleminek frissítése
        public void frissites()
        {
            for (int i = 0; i < n; i++)
            {
                tomb[i] = rand.Next(m);
            }
        }

        // ha változik a tömb mérete
        public void meret(int n)
        {
            this.n = n;
            tomb = new int[n];

            frissites();
        }

        // tömb másolása
        public int[] masolas()
        {
            int[] tomb2 = new int[n];
            Array.Copy(tomb, tomb2, n);
            return tomb2;
        }

        // legroszabb tömb eset
        public int[] csokkenoTomb()
        {
            int[] tomb2 = new int[n];
            Array.Copy(tomb, tomb2, n);
            int x;

            // csökkenő sorrendbe rendezés Simple Sort-al
            for (int i = 0; i < tomb2.Length - 1; i++)
            {
                for (int j = i + 1; j < tomb2.Length; j++)
                {
                    if (tomb2[i] < tomb2[j])
                    {
                        x = tomb2[i];
                        tomb2[i] = tomb2[j];
                        tomb2[j] = x;
                    }
                }
            }
            return tomb2;
        }

        // legroszabb eset megadott tömbnél
        public int[] csokkenoTomb(int[] tomb1)
        {
            int[] tomb2 = new int[tomb1.Length];
            Array.Copy(tomb1, tomb2, tomb1.Length);
            int x;

            // csökkenő sorrendbe rendezés Simple Sort-al
            for (int i = 0; i < tomb2.Length - 1; i++)
            {

                for (int j = i + 1; j < tomb2.Length; j++)
                {
                    if (tomb2[i] < tomb2[j])
                    {
                        x = tomb2[i];
                        tomb2[i] = tomb2[j];
                        tomb2[j] = x;
                    }
                }
            }
            return tomb2;
        }

    }
}
