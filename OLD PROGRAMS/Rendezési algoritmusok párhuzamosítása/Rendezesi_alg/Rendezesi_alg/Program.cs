using System;

namespace Rendezesi_alg
{
    class Program
    {
        static void Main(string[] args)
        {
            Tomb a = new Tomb(10);
            a.maxelem = 99;

            int[] tomb1 = a.tombLeker;
            int[] tomb2 = a.csokkenoTomb(tomb1);

            // RENDEZÉSEK ------------------------------------------
            
            // elemcserék száma, összehasonlítások száma, futási idő
            long csereSzam = 0, osszhSzam = 0;
            double ido = 0;
            
            Rendezesek rend = new Rendezesek();

            #region egyszeru teszt
            // EGYSZERŰ TESZTELÉS --------------------------------------------------------------------------------------------------------------
            /*
            Console.WriteLine("-------------- BUBBLE SORT --------------");
            a.tombKiiras();
            Console.WriteLine("(szekvenciális)");           
            rend.bubbleSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("(párhuzamos 2 szál)");
            rend.parallelBubbleSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("(párhuzamos 4 szál)");
            rend.parallelBubbleSort4(tomb1, ref csereSzam, ref osszhSzam, ref ido);

            Console.WriteLine("-------------- SELECTION SORT --------------");
            a.tombKiiras();
            Console.WriteLine("(szekvenciális)");
            rend.selectionSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("(párhuzamos 2 szál)");
            rend.parallelSelectionSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("(párhuzamos 4 szál)");
            rend.parallelSelectionSort4(tomb1, ref csereSzam, ref osszhSzam, ref ido);

            Console.WriteLine("-------------- QUICK SORT --------------");
            a.tombKiiras();
            Console.WriteLine("(szekvenciális)");
            rend.quickSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
            */
            //----------------------------------------------------------------------------------------------------------------------------------
            #endregion

            // tömb mérete
            Console.WriteLine("Adja meg a tömb méretét:");
            int n = Convert.ToInt32(Console.ReadLine());
            a.meret(n);
            Console.WriteLine();

            // BUBBLE SORT tesztelések -----------------------------

            #region nulla_ellenorzo rend (bubble)
            // A 0. RENDEZÉS + ELLENŐRZŐ RENDEZÉSEK --------------------------------------------------------------------------------------------            
            // (a 0. rendezést a for ciklusos előtt is használjuk)
            
            // Tömb típus kiválasztása:
            // (randomhoz)
            tomb2 = a.tombLeker;

            // (fordítotthoz)
            //tomb1 = a.tombLeker;
            //tomb2 = a.csokkenoTomb(tomb1);

            // (rendezetthez)
            //tomb1 = a.tombLeker;
            //tomb2 = rend.bubbleSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);

            // ----------------------------------------------------------------------
            // A 0. rendezés külön, hogy kiszűrjük a hibás legelső rendezést
            Console.WriteLine("HIBÁS RENDEZÉS KISZŰRÉSE:");
            Console.WriteLine("0. rendezés (soros)");
            rend.bubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("0. rendezés (2 szál)");
            rend.parallelBubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("0. rendezés (4 szál)");
            rend.parallelBubbleSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);

            Console.WriteLine("\n-----------------------------------------------------------------\n");
            // ----------------------------------------------------------------------
            /*
            // Ellenőrző rendezések ------------------------------------------------
            a.frissites();
            // itt változik... ha tömbtípust váltunk
            tomb2 = a.tombLeker;

            Console.WriteLine("ELLENŐRZŐ RENDEZÉS 1:");
            Console.WriteLine("1. rendezés (soros)");
            rend.bubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("1. rendezés (2 szál)");
            rend.parallelBubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("1. rendezés (4 szál)");
            rend.parallelBubbleSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);

            Console.WriteLine("\n-----------------------------------------------------------------\n");

            a.frissites();
            // itt változik... ha tömbtípust váltunk
            tomb2 = a.tombLeker;

            Console.WriteLine("ELLENŐRZŐ RENDEZÉS 2:");
            Console.WriteLine("2. rendezés (soros)");
            rend.bubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("2. rendezés (2 szál)");
            rend.parallelBubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("2. rendezés (4 szál)");
            rend.parallelBubbleSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            // ----------------------------------------------------------------------
            */
            //----------------------------------------------------------------------------------------------------------------------------------
            #endregion

            #region for_ciklus teszt (bubble) 
            // FOR CIKLUSOS TESZTELÉS ----------------------------------------------------------------------------------------------------------
            
            // átlagos csere, összehasonlíás, futási idő
            long osszCsere = 0, osszOsszh = 0, osszCsere2 = 0, osszOsszh2 = 0, osszCsere4 = 0, osszOsszh4 = 0;
            double osszIdo = 0, osszIdo2 = 0, osszIdo4 = 0;

            int m = 10; // a tesztelések száma
            
            // BUBBLE SORT - random tömb (soros - párhuzamos2 - párhuzamos4) 
            Console.WriteLine("BUBBLE SORT (Random tömb esetén)\n");
            for (int i = 0; i < m; i++)
            {
                a.frissites();
                tomb1 = a.tombLeker;

                Console.WriteLine((i+1) + ". rendezés (soros)");                
                rend.bubbleSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere += csereSzam;
                osszOsszh += osszhSzam;
                osszIdo += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (2 szál)");
                rend.parallelBubbleSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere2 += csereSzam;
                osszOsszh2 += osszhSzam;
                osszIdo2 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (4 szál)");
                rend.parallelBubbleSort4(tomb1, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere4 += csereSzam;
                osszOsszh4 += osszhSzam;
                osszIdo4 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");
                Console.WriteLine("\n-----------------------------------------------------------------\n");
            }
            /*
            // BUBBLE SORT - fordított tömb (soros - párhuzamos2 - párhuzamos4) 
            Console.WriteLine("BUBBLE SORT (Fordított tömb esetén)\n");
            for (int i = 0; i < m; i++)
            {
                a.frissites();
                tomb1 = a.tombLeker;
                tomb2 = a.csokkenoTomb(tomb1);

                Console.WriteLine((i + 1) + ". rendezés (soros)");
                rend.bubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere += csereSzam;
                osszOsszh += osszhSzam;
                osszIdo += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (2 szál)");
                rend.parallelBubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere2 += csereSzam;
                osszOsszh2 += osszhSzam;
                osszIdo2 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (4 szál)");
                rend.parallelBubbleSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere4 += csereSzam;
                osszOsszh4 += osszhSzam;
                osszIdo4 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");
                Console.WriteLine("\n-----------------------------------------------------------------\n");
            }
            
            // BUBBLE SORT - rendezett tömb (soros - párhuzamos2 - párhuzamos4) 
            Console.WriteLine("BUBBLE SORT (Rendezett tömb esetén)\n");
            for (int i = 0; i < m; i++)
            {
                a.frissites();
                tomb1 = a.tombLeker;
                tomb2 = rend.bubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);

                Console.WriteLine((i + 1) + ". rendezés (soros)");
                rend.bubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere += csereSzam;
                osszOsszh += osszhSzam;
                osszIdo += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (2 szál)");
                rend.parallelBubbleSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere2 += csereSzam;
                osszOsszh2 += osszhSzam;
                osszIdo2 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (4 szál)");
                rend.parallelBubbleSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere4 += csereSzam;
                osszOsszh4 += osszhSzam;
                osszIdo4 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");
                Console.WriteLine("\n-----------------------------------------------------------------\n");
            }
            */
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            Console.WriteLine("A rendezendő tömb mérete: " + n);
            Console.WriteLine("\n-----------------------------------------------------------------\n");

            Console.WriteLine("Bubble Sort - Szekvenciálisan:");
            Console.WriteLine("Átlagosan az elemcserék száma: {0} \nÁtlagosan az összehasonlítások száma: {1}", osszCsere / m, osszOsszh / m);
            Console.WriteLine("Az átlagos futási idő: " + osszIdo / m + " ms");
            Console.WriteLine("\n-----------------------------------------------------------------\n");

            Console.WriteLine("Bubble Sort - Párhuzamosan (2 szál):");
            Console.WriteLine("Átlagosan az elemcserék száma: {0} \nÁtlagosan az összehasonlítások száma: {1}", osszCsere2 / m, osszOsszh2 / m);
            Console.WriteLine("Az átlagos futási idő: " + osszIdo2 / m + " ms");
            Console.WriteLine("\n-----------------------------------------------------------------\n");

            Console.WriteLine("Bubble Sort - Párhuzamosan (4 szál):");
            Console.WriteLine("Átlagosan az elemcserék száma: {0} \nÁtlagosan az összehasonlítások száma: {1}", osszCsere4 / m, osszOsszh4 / m);
            Console.WriteLine("Az átlagos futási idő: " + osszIdo4 / m + " ms");
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            
            //----------------------------------------------------------------------------------------------------------------------------------
            #endregion

            // -----------------------------------------------------

            // SELECTION SORT tesztelések --------------------------

            #region nulla_ellenorzo rend (selection)
            // A 0. RENDEZÉS + ELLENŐRZŐ RENDEZÉSEK --------------------------------------------------------------------------------------------            
            // (a 0. rendezést a for ciklusos előtt is használjuk)
            /*
            // Tömb típus kiválasztása:
            // (randomhoz)
            //tomb2 = a.tombLeker;

            // (fordítotthoz)
            //tomb1 = a.tombLeker;
            //tomb2 = a.csokkenoTomb(tomb1);

            // (rendezetthez)
            //tomb1 = a.tombLeker;
            //tomb2 = rend.selectionSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);

            // ----------------------------------------------------------------------
            // A 0. rendezés külön, hogy kiszűrjük a hibás legelső rendezést
            Console.WriteLine("HIBÁS RENDEZÉS KISZŰRÉSE:");
            Console.WriteLine("0. rendezés (soros)");
            rend.selectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("0. rendezés (2 szál)");
            rend.parallelSelectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("0. rendezés (4 szál)");
            rend.parallelSelectionSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);

            Console.WriteLine("\n-----------------------------------------------------------------\n");
            // ----------------------------------------------------------------------
            
            // Ellenőrző rendezések ------------------------------------------------
            a.frissites();
            // itt változik... ha tömbtípust váltunk
            tomb2 = a.tombLeker;

            Console.WriteLine("ELLENŐRZŐ RENDEZÉS 1:");
            Console.WriteLine("1. rendezés (soros)");
            rend.selectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("1. rendezés (2 szál)");
            rend.parallelSelectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("1. rendezés (4 szál)");
            rend.parallelSelectionSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);

            Console.WriteLine("\n-----------------------------------------------------------------\n");
            
            a.frissites();
            // itt változik... ha tömbtípust váltunk
            tomb2 = a.tombLeker;

            Console.WriteLine("ELLENŐRZŐ RENDEZÉS 2:");
            Console.WriteLine("2. rendezés (soros)");
            rend.selectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("2. rendezés (2 szál)");
            rend.parallelSelectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
            Console.WriteLine("2. rendezés (4 szál)");
            rend.parallelSelectionSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);

            Console.WriteLine("\n-----------------------------------------------------------------\n");
            // ----------------------------------------------------------------------
            */
            //----------------------------------------------------------------------------------------------------------------------------------
            #endregion

            #region for_ciklus teszt (selection) 
            // FOR CIKLUSOS TESZTELÉS ----------------------------------------------------------------------------------------------------------
            /*
            // átlagos csere, összehasonlíás, futási idő
            long osszCsere = 0, osszOsszh = 0, osszCsere2 = 0, osszOsszh2 = 0, osszCsere4 = 0, osszOsszh4 = 0;
            double osszIdo = 0, osszIdo2 = 0, osszIdo4 = 0;

            int m = 10; // a tesztelések száma
            
            // SELECTION SORT - random tömb (soros - párhuzamos2 - párhuzamos4) 
            Console.WriteLine("SELECTION SORT (Random tömb esetén)\n");
            for (int i = 0; i < m; i++)
            {
                a.frissites();
                tomb1 = a.tombLeker;

                Console.WriteLine((i+1) + ". rendezés (soros)");                
                rend.selectionSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere += csereSzam;
                osszOsszh += osszhSzam;
                osszIdo += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (2 szál)");
                rend.parallelSelectionSort(tomb1, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere2 += csereSzam;
                osszOsszh2 += osszhSzam;
                osszIdo2 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (4 szál)");
                rend.parallelSelectionSort4(tomb1, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere4 += csereSzam;
                osszOsszh4 += osszhSzam;
                osszIdo4 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");
                Console.WriteLine("\n-----------------------------------------------------------------\n");
            }
            
            // SELECTION SORT - fordított tömb (soros - párhuzamos2 - párhuzamos4) 
            Console.WriteLine("SELECTION SORT (Fordított tömb esetén)\n");
            for (int i = 0; i < m; i++)
            {
                a.frissites();
                tomb1 = a.tombLeker;
                tomb2 = a.csokkenoTomb(tomb1);

                Console.WriteLine((i + 1) + ". rendezés (soros)");
                rend.selectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere += csereSzam;
                osszOsszh += osszhSzam;
                osszIdo += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (2 szál)");
                rend.parallelSelectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere2 += csereSzam;
                osszOsszh2 += osszhSzam;
                osszIdo2 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (4 szál)");
                rend.parallelSelectionSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere4 += csereSzam;
                osszOsszh4 += osszhSzam;
                osszIdo4 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");
                Console.WriteLine("\n-----------------------------------------------------------------\n");
            }
            
            // SELECTION SORT - rendezett tömb (soros - párhuzamos2 - párhuzamos4) 
            Console.WriteLine("SELECTION SORT (Rendezett tömb esetén)\n");
            for (int i = 0; i < m; i++)
            {
                a.frissites();
                tomb1 = a.tombLeker;
                tomb2 = rend.selectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                
                Console.WriteLine((i + 1) + ". rendezés (soros)");
                rend.selectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere += csereSzam;
                osszOsszh += osszhSzam;
                osszIdo += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (2 szál)");
                rend.parallelSelectionSort(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere2 += csereSzam;
                osszOsszh2 += osszhSzam;
                osszIdo2 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                Console.WriteLine((i + 1) + ". rendezés (4 szál)");
                rend.parallelSelectionSort4(tomb2, ref csereSzam, ref osszhSzam, ref ido);
                osszCsere4 += csereSzam;
                osszOsszh4 += osszhSzam;
                osszIdo4 += ido;
                Console.WriteLine("\n-----------------------------------------------------------------\n");
                Console.WriteLine("\n-----------------------------------------------------------------\n");
            }
            
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            Console.WriteLine("A rendezendő tömb mérete: " + n);
            Console.WriteLine("\n-----------------------------------------------------------------\n");

            Console.WriteLine("Selection Sort - Szekvenciálisan:");
            Console.WriteLine("Átlagosan az elemcserék száma: {0} \nÁtlagosan az összehasonlítások száma: {1}", osszCsere / m, osszOsszh / m);
            Console.WriteLine("Az átlagos futási idő: " + osszIdo / m + " ms");
            Console.WriteLine("\n-----------------------------------------------------------------\n");

            Console.WriteLine("Selection Sort - Párhuzamosan (2 szál):");
            Console.WriteLine("Átlagosan az elemcserék száma: {0} \nÁtlagosan az összehasonlítások száma: {1}", osszCsere2 / m, osszOsszh2 / m);
            Console.WriteLine("Az átlagos futási idő: " + osszIdo2 / m + " ms");
            Console.WriteLine("\n-----------------------------------------------------------------\n");

            Console.WriteLine("Selection Sort - Párhuzamosan (4 szál):");
            Console.WriteLine("Átlagosan az elemcserék száma: {0} \nÁtlagosan az összehasonlítások száma: {1}", osszCsere4 / m, osszOsszh4 / m);
            Console.WriteLine("Az átlagos futási idő: " + osszIdo4 / m + " ms");
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            */
            //----------------------------------------------------------------------------------------------------------------------------------
            #endregion

            // -----------------------------------------------------

            Console.ReadKey();
        }
    }
}
