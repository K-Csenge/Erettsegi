using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2018_05_2
{
    internal class Program
    {
        public const string utvonal = "../../../ajto.txt";
        public struct Belepes
        {
            public int ora;
            public int perc;
            public int ido;
            public int id;
            public string irany;
            public int athaladas;

            public Belepes(int ora, int perc, int id, string irany) : this()
            {
                this.ora = ora;
                this.perc = perc;
                this.id = id;
                this.irany = irany;
                athaladas = 0;
                ido = ora * 60 + perc;
            }

        }

        static void Main(string[] args)
        {
            #region 1. Feladat

            var sorok = File.ReadLines(utvonal);
            var belepesek = new List<Belepes>();

            foreach (var sor in sorok)
            {
                var adatok = sor.Split(' ');
                belepesek.Add(new Belepes(
                    int.Parse(adatok[0]),
                    int.Parse(adatok[1]),
                    int.Parse(adatok[2]),
                    adatok[3])
                    );

            }

            #endregion

            #region 2. Feladat

            Belepes legelso;
            Belepes legutolso;
            legelso.id = 0;
            legutolso.id = 0;
            legelso.ido = 15 * 60 + 60;
            legutolso.ido = 0;

            for (int i = belepesek.Count - 1; i >= 0; i--)
            {
                if (belepesek[i].ido <= legelso.ido && belepesek[i].irany == "be")
                {
                    legelso = belepesek[i];
                }
            }

            for (int i = 0; i <= belepesek.Count - 1; i++)
            {
                if (belepesek[i].ido >= legutolso.ido && belepesek[i].irany == "ki")
                {
                    legutolso = belepesek[i];
                }
            }

            Console.WriteLine($"Eloszor belepett ember id-je: {legelso.id}");
            Console.WriteLine($"Utoljara belepett ember id-je: {legutolso.id}");
            Console.WriteLine();

            #endregion

            #region 3. Feladat

            int[] athaladasok = new int[101];
            for(var i = 0; i < 101; i++)
            {
                athaladasok[i] = 0;
            }

            for(int i = 0; i <= belepesek.Count - 1; i++)
            {
                athaladasok[belepesek[i].id]++;
            }
            
            var athaladasokString = new List<string>();

            for(int i = 0; i < 101; i++)
            {
                if(athaladasok[i] > 0)
                {
                    athaladasokString.Add($"{i} {athaladasok[i]}");
                }
            }

            var sorok123 = File.ReadLines(utvonal);
            File.WriteAllLines("../../../athaladasok.txt", athaladasokString);
            
            #endregion

            #region 4. Feladat
            var bentmaradottak = new List<Belepes>();

            //foreach (var belepes in belepesek)
            //{
            //    if (belepes.irany == "be")
            //    {
            //        bentmaradottak.Add(belepes);
            //    }
            //    else
            //    {
            //        if (bentmaradottak.Contains(belepes))
            //        {
            //            bentmaradottak.Remove(belepes);
            //        }
            //    }
            //}

            //int count = 0;
            //for (int i = 0; i < belepesek.Count; i++)
            //{
            //    count = 0;
            //    for (int j = 0; j < belepesek.Count; j++)
            //    {
            //        if (belepesek[i].id == belepesek[j].id)
            //        {
            //            //Console.WriteLine($"I: {i}, J: {j}, Egyformak, id: {belepesek[i].id}");
            //            count++;
            //        }
            //    }
            //    if (count % 2 != 0)
            //    {
            //        bentmaradottak.Add(belepesek[i]);
            //        Console.WriteLine($"Id: {belepesek[i].id}, Megjeleness: {count}");
            //    }
            //}

            //var rendezettBentmaradottak = bentmaradottak.OrderBy(jarkalo => jarkalo.id);


            #endregion
        }
    }
}
