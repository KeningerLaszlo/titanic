﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace titanic
{
    class Program
    {
        static List<UKategoria> kategoriak;
        static string keresett;
        static bool talalat;
        struct UKategoria
        {
            public string Nev;

            public int Tulelok;

            public int Eltuntek;

        }
        static void Main()
        {
            F01();
            F02();
            F03();
            F04();
            F05();
            f06();
            F07();
            Console.ReadKey();
        }

        private static void F07()
        {
            int maxi = 0;
            for (int i = 0; i < kategoriak.Count; i++)
            {
                if (kategoriak[i].Tulelok > kategoriak[maxi].Tulelok) maxi = i;

            }
            Console.WriteLine($"7. feladat: {kategoriak[maxi].Nev}");
            
        }

        private static void f06()
        {
            Console.WriteLine("6.feladat:");
            foreach (var k in kategoriak)
            {
                if(k.Eltuntek + k.Tulelok * 6 < k.Eltuntek)
                {
                    Console.WriteLine($"\n {k.Nev}");

                }
            }
        }

        private static void F05()
        {
            if (talalat)
            {

                Console.WriteLine("5. feladat");
                foreach (var k in kategoriak)
                {
                    if(k.Nev.Contains(keresett))
                    {
                        Console.WriteLine($"\n{k.Nev} {k.Tulelok + k.Eltuntek} fő");

                    }
                }
            }
        }

        private static void F04()
        {
            Console.Write("4.feladat: kulcsszó:");
            keresett = Console.ReadLine();

            int i = 0;
            while (i < kategoriak.Count && !kategoriak[i].Nev.Contains(keresett))
            {
                i++;
            }

            if (i < kategoriak.Count)
            { 
             Console.WriteLine("\nvan találat");
                talalat = true;
            }
            else 
            {
                Console.WriteLine("\nnincs találat");
                talalat = false;
            }
        }

        private static void F03()
        {
            int sum = 0;
            foreach (var k in kategoriak)
            {
                sum += (k.Tulelok + k.Eltuntek);
            }

            Console.WriteLine($"3.feladat:{sum} fő");
        }

        private static void F02()
        {
            Console.WriteLine($"2. fealadat {kategoriak.Count}");        }

        private static void F01()
        {
            kategoriak = new List<UKategoria>();
            var sr = new StreamReader(@"..\..\res\titanic.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                var t = sr.ReadLine().Split(';');

                kategoriak.Add(new UKategoria()
                {
                    Nev = t[0],
                    Tulelok = int.Parse(t[1]),
                    Eltuntek = int.Parse(t[2]),
                });
            }
            sr.Close();
        }
    }
}
