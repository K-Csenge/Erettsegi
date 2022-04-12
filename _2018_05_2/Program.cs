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

            var legutolso = belepesek .Where(
                j => 
                j.ora == belepesek.Max(elem => elem.ora) && 
                j.perc == belepesek.Max(elem => elem.perc)
                ).LastOrDefault();

            var legelso = belepesek.Where(
                j =>
                j.ora == belepesek.Min(elem => elem.ora) &&
                j.perc == belepesek.Min(elem => elem.perc)
                ).FirstOrDefault();


            //Console.WriteLine($"Eloszor belepett ember id-je: {belepesek[0].id}, ora: {belepesek[0].ora}");
            //Console.WriteLine($"Utoljara belepett ember id-je: {belepesek[^3].id}, ora: {belepesek[^1].ora}");
            //Console.WriteLine();

            #endregion

            #region 3. Feladat
            #endregion
        }
    }
}
