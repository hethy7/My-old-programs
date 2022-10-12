using System;
using System.Diagnostics;
using System.Threading;

namespace Rendezesi_alg
{
    class Rendezesek
    {
        // a futási idő átváltása
        public void futasiIdo(int alg, double ido)
        {
            switch (alg)
            {
                case 1:
                    Console.Write("A Bubble Sort futási ideje: ");
                    break;
                case 2:
                    Console.Write("A Select Sort futási ideje: ");
                    break;
                case 3:
                    Console.Write("A Quick Sort futási ideje: ");
                    break;
            }

            if (ido >= 1000) Console.WriteLine(ido / 1000 + " s"); // sec
            else if (ido >= 1) Console.WriteLine(ido + " ms"); // milisec
            else if ((ido * 1000) >= 1) Console.WriteLine(ido * 1000 + " us"); // microsec
            else Console.WriteLine(ido * 1000000 + " ns"); // nanosec
        }

        // összefésülő metódus
        private int[] merge(int[] tomb1, int[] tomb2)
        {
            int[] rtomb1 = tomb1;
            int[] rtomb2 = tomb2;

            int n = rtomb1.Length;
            int m = rtomb2.Length;
            int[] tomb = new int[n + m];

            int a = 0, b = 0;   // az eredeti tömbök indexei
            int i = 0;          // az eredmény tömb indexe

            // összefésülés, míg 2 résztömb van
            while (a < n && b < m)
            {
                if (rtomb1[a] <= rtomb2[b]) tomb[i++] = rtomb1[a++];
                else tomb[i++] = rtomb2[b++];
            }

            // a maradék hozzászúrása
            if (a < n)
            {
                // az első tömbből
                for (int j = a; j < n; j++) tomb[i++] = rtomb1[j];
            }
            else
            {
                // a második tömbből
                for (int j = b; j < m; j++) tomb[i++] = rtomb2[j];
            }

            return tomb;
        }

        // résztömbökre bontás (2 szál)
        private void reszTomb(int[] tomb1, out int[] rtomb1, out int[] rtomb2)
        {
            int n = tomb1.Length;

            if (n % 2 == 0)
            {
                rtomb1 = new int[n / 2];
                Array.Copy(tomb1, 0, rtomb1, 0, n / 2);

                rtomb2 = new int[n / 2];
                Array.Copy(tomb1, n / 2, rtomb2, 0, n / 2);
            }
            else
            {
                rtomb1 = new int[(n / 2) + 1];
                Array.Copy(tomb1, 0, rtomb1, 0, (n / 2) + 1);

                rtomb2 = new int[n / 2];
                Array.Copy(tomb1, (n / 2) + 1, rtomb2, 0, n / 2);
            }
        }

        // résztömbökre bontás (4 szál)
        private void reszTomb4(int[] tomb1, out int[] rtomb1, out int[] rtomb2, out int[] rtomb3, out int[] rtomb4)
        {
            int n = tomb1.Length;

            if (n % 4 == 0)
            {
                rtomb1 = new int[n / 4];
                Array.Copy(tomb1, 0, rtomb1, 0, n / 4);

                rtomb2 = new int[n / 4];
                Array.Copy(tomb1, ((n / 2) - (n / 4)), rtomb2, 0, n / 4);

                rtomb3 = new int[n / 4];
                Array.Copy(tomb1, n / 2, rtomb3, 0, n / 4);

                rtomb4 = new int[n / 4];
                Array.Copy(tomb1, ((n / 2) + (n / 4)), rtomb4, 0, n / 4);
            }
            else
            {
                rtomb1 = new int[n / 4];
                Array.Copy(tomb1, 0, rtomb1, 0, n / 4);

                rtomb2 = new int[n / 4];
                Array.Copy(tomb1, ((n / 2) - (n / 4)) - 1, rtomb2, 0, n / 4);

                rtomb3 = new int[n / 4];
                Array.Copy(tomb1, (n / 2) - 1, rtomb3, 0, n / 4);

                rtomb4 = new int[(n / 4) + (n % 4)];
                Array.Copy(tomb1, ((n / 2) + (n / 4)) - 1, rtomb4, 0, (n / 4) + (n % 4));
            }
        }

        // SOROS RENDEZÉSEK
        // ---------------- Bubble Sort -------------------------
        #region Bubble Sort
        public int[] bubbleSort(int[] tomb1, ref long csereSzam, ref long osszhSzam, ref double ido)
        {
            // tömb másolása, hogy az eredeti megmaradjon
            int[] tomb2 = new int[tomb1.Length];
            Array.Copy(tomb1, tomb2, tomb1.Length);

            Stopwatch s = new Stopwatch(); // a futási idő méréséhez
            csereSzam = 0; // az elemcserék száma
            osszhSzam = 0; // az összehasonlítások száma

            s.Start(); // stopwatch indítása

            // az algoritmus
            bool csere;
            int x;
            do
            {
                csere = false;
                for (int i = 0; i < tomb2.Length - 1; i++)
                {
                    //összehasonlítások
                    if (tomb2[i] > tomb2[i + 1])
                    {
                        // elemek cseréje 
                        x = tomb2[i];
                        tomb2[i] = tomb2[i + 1];
                        tomb2[i + 1] = x;
                        csere = true;
                        ++csereSzam;
                    }
                    ++osszhSzam;
                }
            } while (csere);

            s.Stop(); // stopwatch leállítása

            ido = s.Elapsed.TotalMilliseconds;
            futasiIdo(1, ido); // az algoritmus futási idő
            // az elemcserék és az összehasonlítások száma adja meg az algoritmus bonyolultságát
            Console.WriteLine("Az elemcserék száma: {0} \nAz összehasonlítások száma: {1} \n", csereSzam, osszhSzam);

            return tomb2;
        }
        #endregion
        // ------------------------------------------------------
        // ---------------- Selection Sort ----------------------
        #region Selection Sort
        public int[] selectionSort(int[] tomb1, ref long csereSzam, ref long osszhSzam, ref double ido)
        {
            // tömb másolása, hogy az eredeti megmaradjon
            int[] tomb2 = new int[tomb1.Length];
            Array.Copy(tomb1, tomb2, tomb1.Length);

            Stopwatch s = new Stopwatch(); // a futási idő méréséhez
            csereSzam = 0; // az elemcserék száma
            osszhSzam = 0; // az összehasonlítások száma

            s.Start(); // stopwatch indítása

            // az algoritmus
            int i, j;
            int min, x;

            for (i = 0; i < tomb2.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < tomb2.Length; j++)
                {
                    // összehasonlítások
                    if (tomb2[j] < tomb2[min])
                    {
                        min = j;
                    }
                    ++osszhSzam;
                }
                // elemek cseréje
                if (min != i)
                {
                    x = tomb2[i];
                    tomb2[i] = tomb2[min];
                    tomb2[min] = x;
                    ++csereSzam;
                }
            }

            s.Stop(); // stopwatch leállítása

            ido = s.Elapsed.TotalMilliseconds;
            futasiIdo(2, ido); // a futási idő
            // az elemcserék és az összehasonlítások száma adja meg az algoritmus bonyolultságát
            Console.WriteLine("Az elemcserék száma: {0} \nAz összehasonlítások száma: {1} \n", csereSzam, osszhSzam);

            return tomb2;
        }
        #endregion
        // ------------------------------------------------------
        // ---------------- Quick Sort --------------------------
        #region Quick Sort
        public int[] quickSort(int[] tomb1, ref long csereSzam, ref long osszhSzam, ref double ido)
        {
            // tömb másolása, hogy az eredeti megmaradjon
            int[] tomb2 = new int[tomb1.Length];
            Array.Copy(tomb1, tomb2, tomb1.Length);

            Stopwatch s = new Stopwatch(); // a futási idő méréséhez
            csereSzam = 0; // az elemcserék száma
            osszhSzam = 0; // az összehasonlítások száma

            s.Start(); // stopwatch indítása

            // a quick sort meghívása
            qs(tomb2, 0, tomb2.Length - 1, ref csereSzam, ref osszhSzam);

            s.Stop(); // stopwatch leállítása

            ido = s.Elapsed.TotalMilliseconds;
            futasiIdo(3, ido); // a futási idő
            // az elemcserék és az összehasonlítások száma adja meg az algoritmus bonyolultságát
            Console.WriteLine("Az elemcserék száma: {0} \nAz összehasonlítások száma: {1} \n", csereSzam, osszhSzam);

            return tomb2;
        }

        // a quick sort algoritmus
        private void qs(int[] tomb, int left, int right, ref long csereSzam, ref long osszhSzam)
        {
            int i, j;
            int pivot, x;

            i = left;
            j = right;
            pivot = tomb[(left + right) / 2];

            do
            {
                // összehasonlítások
                while ((tomb[i] < pivot) && (i < right))
                {
                    i++;
                    ++osszhSzam;
                }
                while ((pivot < tomb[j]) && (j > left))
                {
                    j--;
                    ++osszhSzam;
                }

                // elemek cseréje
                if (i <= j)
                {
                    x = tomb[i];
                    tomb[i] = tomb[j];
                    tomb[j] = x;
                    i++; j--;
                    // igazából csak akkor történik csere, ha i < j
                    // if (i < j) ++csereSzam; //(csere????)
                    ++csereSzam;
                }
            } while (i <= j);

            // rekurzív meghívás a résztömbökre
            if (left < j) qs(tomb, left, j, ref csereSzam, ref osszhSzam);
            if (i < right) qs(tomb, i, right, ref csereSzam, ref osszhSzam);
        }
        #endregion
        // ------------------------------------------------------

        // PÁRHUZAMOS RENDEZÉSEK (2 szálon)
        // ---------------- Bubble Sort -------------------------
        #region Parallel Bubble Sort (2 szál)
        public int[] parallelBubbleSort(int[] tomb1, ref long csereSzam, ref long osszhSzam, ref double ido)
        {
            int n = tomb1.Length;
            // tömb másolása, hogy az eredeti megmaradjon
            int[] tomb2 = new int[n];
            Array.Copy(tomb1, tomb2, n);

            Stopwatch s = new Stopwatch();
            // lambda kifelyezésnek nem lehet referencia értékeket átadni
            long csereSz = 0;
            long osszhSz = 0;          

            s.Start();

            // a rendezendő tömb ketté osztása
            int[] rtomb1, rtomb2;
            reszTomb(tomb2, out rtomb1, out rtomb2);

            // a bubble sort meghívása a résztömbökre 2 szál segítségével
            // szálak létrehozása Thread osztály segítségével
            Thread t1 = new Thread(() => pBubbleSort(rtomb1, ref csereSz, ref osszhSz));
            Thread t2 = new Thread(() => pBubbleSort(rtomb2, ref csereSz, ref osszhSz));
            // szálak indítása
            t1.Start();
            t2.Start();
            // várakozás a szálak befejeződésére
            t1.Join();
            t2.Join();

            // a résztömbök összefésülése
            tomb2 = merge(rtomb1, rtomb2);

            s.Stop();

            // a referencia változókba átadódnak a mért értékek
            csereSzam = csereSz;
            osszhSzam = osszhSz;

            ido = s.Elapsed.TotalMilliseconds;
            futasiIdo(1, ido);
            Console.WriteLine("Az elemcserék száma: {0} \nAz összehasonlítások száma: {1} \n", csereSzam, osszhSzam);

            return tomb2;
        }

        // a bubble sort algoritmus párhuzamosításhoz
        private void pBubbleSort(int[] tomb, ref long csereSz, ref long osszhSz)
        {
            bool csere;
            int x;
            do
            {
                csere = false;
                for (int i = 0; i < tomb.Length - 1; i++)
                {
                    //összehasonlítások
                    if (tomb[i] > tomb[i + 1])
                    {
                        // elemek cseréje 
                        x = tomb[i];
                        tomb[i] = tomb[i + 1];
                        tomb[i + 1] = x;
                        csere = true;
                        Interlocked.Increment(ref csereSz); // atomi inkrementálás
                    }
                    Interlocked.Increment(ref osszhSz); // atomi inkrementálás
                }
            } while (csere);
        }
        #endregion
        // ------------------------------------------------------
        // ---------------- Selection Sort ----------------------
        #region Parallel Selection Sort (2 szál)
        public int[] parallelSelectionSort(int[] tomb1, ref long csereSzam, ref long osszhSzam, ref double ido)
        {
            int n = tomb1.Length;
            // tömb másolása, hogy az eredeti megmaradjon
            int[] tomb2 = new int[n];
            Array.Copy(tomb1, tomb2, n);

            Stopwatch s = new Stopwatch();
            // lambda kifelyezésnek nem lehet referencia értékeket átadni
            long csereSz = 0;
            long osszhSz = 0;

            s.Start();

            // a rendezendő tömb ketté osztása
            int[] rtomb1, rtomb2;
            reszTomb(tomb2, out rtomb1, out rtomb2);

            // a selection sort meghívása a résztömbökre 2 szál segítségével
            // szálak létrehozása Thread osztály segítségével
            Thread t1 = new Thread(() => pSelectionSort(rtomb1, ref csereSz, ref osszhSz));
            Thread t2 = new Thread(() => pSelectionSort(rtomb2, ref csereSz, ref osszhSz));
            // szálak indítása
            t1.Start();
            t2.Start();
            // várakozás a szálak befejeződésére
            t1.Join();
            t2.Join();

            // a résztömbök összefésülése
            tomb2 = merge(rtomb1, rtomb2);

            s.Stop();

            // a referencia változókba átadódnak a mért értékek
            csereSzam = csereSz;
            osszhSzam = osszhSz;

            ido = s.Elapsed.TotalMilliseconds;
            futasiIdo(2, ido);
            Console.WriteLine("Az elemcserék száma: {0} \nAz összehasonlítások száma: {1} \n", csereSzam, osszhSzam);

            return tomb2;
        }

        // a selection sort algoritmus párhuzamosításhoz
        private void pSelectionSort(int[] tomb, ref long csereSz, ref long osszhSz)
        {
            int i, j;
            int min, x;

            for (i = 0; i < tomb.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < tomb.Length; j++)
                {
                    // összehasonlítások
                    if (tomb[j] < tomb[min])
                    {
                        min = j;
                    }
                    Interlocked.Increment(ref osszhSz); // atomi inkrementálás
                }
                // elemek cseréje
                if (min != i)
                {
                    x = tomb[i];
                    tomb[i] = tomb[min];
                    tomb[min] = x;
                    Interlocked.Increment(ref csereSz); // atomi inkrementálás
                }
            }
        }
        #endregion
        // ------------------------------------------------------

        // PÁRHUZAMOS RENDEZÉSEK (4 szálon)
        // ---------------- Bubble Sort -------------------------
        #region Parallel Bubble Sort (4 szál)
        public int[] parallelBubbleSort4(int[] tomb1, ref long csereSzam, ref long osszhSzam, ref double ido)
        {
            int n = tomb1.Length;
            // tömb másolása, hogy az eredeti megmaradjon
            int[] tomb2 = new int[n];
            Array.Copy(tomb1, tomb2, n);

            Stopwatch s = new Stopwatch();
            // lambda kifelyezésnek nem lehet referencia értékeket átadni
            long csereSz = 0;
            long osszhSz = 0;

            s.Start();

            // a rendezendő tömb 4 részre bontása
            int[] rtomb1, rtomb2, rtomb3, rtomb4;
            reszTomb4(tomb2, out rtomb1, out rtomb2, out rtomb3, out rtomb4);

            // a bubble sort meghívása a résztömbökre 4 szál segítségével
            // szálak létrehozása Thread osztály segítségével
            Thread t1 = new Thread(() => pBubbleSort(rtomb1, ref csereSz, ref osszhSz));
            Thread t2 = new Thread(() => pBubbleSort(rtomb2, ref csereSz, ref osszhSz));
            Thread t3 = new Thread(() => pBubbleSort(rtomb3, ref csereSz, ref osszhSz));
            Thread t4 = new Thread(() => pBubbleSort(rtomb4, ref csereSz, ref osszhSz));
            // szálak indítása
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            // várakozás a szálak befejeződésére
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            // a résztömbök összefésülése
            int[] rtomb12 = new int[(n / 2)];
            int[] rtomb34 = new int[(n / 2) + (n % 4)];
            rtomb12 = merge(rtomb1, rtomb2);
            rtomb34 = merge(rtomb3, rtomb4);
            tomb2 = merge(rtomb12, rtomb34);

            s.Stop();

            // a referencia változókba átadódnak a mért értékek
            csereSzam = csereSz;
            osszhSzam = osszhSz;

            ido = s.Elapsed.TotalMilliseconds;
            futasiIdo(1, ido);
            Console.WriteLine("Az elemcserék száma: {0} \nAz összehasonlítások száma: {1} \n", csereSzam, osszhSzam);

            return tomb2;
        }
        #endregion
        // ------------------------------------------------------
        // ---------------- Selection Sort ----------------------
        #region Parallel Selection Sort (4 szál)
        public int[] parallelSelectionSort4(int[] tomb1, ref long csereSzam, ref long osszhSzam, ref double ido)
        {
            int n = tomb1.Length;
            // tömb másolása, hogy az eredeti megmaradjon
            int[] tomb2 = new int[n];
            Array.Copy(tomb1, tomb2, n);

            Stopwatch s = new Stopwatch();
            // lambda kifelyezésnek nem lehet referencia értékeket átadni
            long csereSz = 0;
            long osszhSz = 0;

            s.Start();

            // a rendezendő tömb ketté osztása
            int[] rtomb1, rtomb2, rtomb3, rtomb4;
            reszTomb4(tomb2, out rtomb1, out rtomb2, out rtomb3, out rtomb4);

            // a selection sort meghívása a résztömbökre 4 szál segítségével
            // szálak létrehozása Thread osztály segítségével
            Thread t1 = new Thread(() => pSelectionSort(rtomb1, ref csereSz, ref osszhSz));
            Thread t2 = new Thread(() => pSelectionSort(rtomb2, ref csereSz, ref osszhSz));
            Thread t3 = new Thread(() => pSelectionSort(rtomb3, ref csereSz, ref osszhSz));
            Thread t4 = new Thread(() => pSelectionSort(rtomb4, ref csereSz, ref osszhSz));
            // szálak indítása
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            // várakozás a szálak befejeződésére
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            // a résztömbök összefésülése
            int[] rtomb12 = new int[(n / 2)];
            int[] rtomb34 = new int[(n / 2) + (n % 4)];
            rtomb12 = merge(rtomb1, rtomb2);
            rtomb34 = merge(rtomb3, rtomb4);
            tomb2 = merge(rtomb12, rtomb34);

            s.Stop();

            // a referencia változókba átadódnak a mért értékek
            csereSzam = csereSz;
            osszhSzam = osszhSz;

            ido = s.Elapsed.TotalMilliseconds;
            futasiIdo(2, ido);
            Console.WriteLine("Az elemcserék száma: {0} \nAz összehasonlítások száma: {1} \n", csereSzam, osszhSzam);

            return tomb2;
        }
        #endregion
        // ------------------------------------------------------
    }
}
