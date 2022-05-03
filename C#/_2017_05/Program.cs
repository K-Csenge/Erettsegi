using System;
using System.Collections.Generic;
using System.IO;

namespace _2017_05_idegen
{
    class Program
    {
        struct Furdozo
        {
            public int id;
            public int reszlegid;
            public int beki;
            public int ora;
            public int perc;
            public int mp;

            public Furdozo(string sor) : this()
            {
                var adatok = sor.Split(' ');
                id = int.Parse(adatok[0]);
                reszlegid = int.Parse(adatok[1]);
                beki = int.Parse(adatok[2]);
                ora = int.Parse(adatok[3]);
                perc = int.Parse(adatok[4]);
                mp = int.Parse(adatok[5]);

            }
        }
        static void Main(string[] args)
        {
            var furdozok = new List<Furdozo>();

            var sorok = File.ReadLines("../../../furdoadat.txt");

            foreach (var sor in sorok)
            {
                var ideiglenesFurdozo = new Furdozo(sor);
                furdozok.Add(ideiglenesFurdozo);
            }


            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az első vendég {furdozok[0].ora}:{furdozok[0].perc}:{furdozok[0].mp}-kor lépett ki az öltözőből.");

            //Furdozo utolsoKilep = new Furdozo();

            var ora = 0;
            var perc = 0;
            var mp = 0;

            for (int i = 0; i < furdozok.Count; i++)
            {
                if (furdozok[i].ora >= ora && furdozok[i].beki == 1 && furdozok[i].reszlegid == 0)
                {
                    ora = furdozok[i].ora;
                }
            }
            //Console.WriteLine($"MaxOra = {ora}");

            for (int i = 0; i < furdozok.Count; i++)
            {
                if (furdozok[i].perc >= perc && furdozok[i].ora == ora && furdozok[i].beki == 1 && furdozok[i].reszlegid == 0)
                {
                    perc = furdozok[i].perc;
                }
            }
            //Console.WriteLine($"MaxPerc = {perc}");

            for (int i = 0; i < furdozok.Count; i++)
            {
                if (furdozok[i].mp >= mp && furdozok[i].ora == ora && furdozok[i].perc == perc && furdozok[i].beki == 1 && furdozok[i].reszlegid == 0)
                {
                    mp = furdozok[i].mp;
                }
            }
            Console.WriteLine($"Az utolsó vendég {ora}:{perc}:{mp}-kor lépett ki az öltözőből.");
        }
    }
}
