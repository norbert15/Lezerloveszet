using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lezerloveszet
{
    class Program
    {
        static List<JatekosLovese> lovesek = new List<JatekosLovese>();
        static double x_kozeppont;
        static double y_kozeppont;
        static void Main(string[] args)
        {
            Console.WriteLine("Adatok beolvasása...");
            Beolvasas("lovesek.txt");
            Console.WriteLine("Adatok beolvasva");
            Console.WriteLine($"\n5.feladat: A lövések száma: {lovesek.Count} db");

            //7.feladat
            double legkozelebbi = 100;
            int azon = 0;
            foreach (var item in lovesek)
            {
                if(legkozelebbi > item.Tavolsag(x_kozeppont, y_kozeppont))
                {
                    legkozelebbi = item.Tavolsag(x_kozeppont, y_kozeppont);
                    azon = item.Loves_azon;
                }
            }
            azon -= 1;
            Console.WriteLine("\n7.feladat: A legpontosabb lövés:");
            Console.WriteLine($"\t{lovesek[azon].Loves_azon}.; {lovesek[azon].Nev}; x={lovesek[azon].X_koor}; y={lovesek[azon].Y_koor}; távolság: {legkozelebbi}");

            //9.feladat
            Console.WriteLine($"\n9.feladat: Nulla pontos lövések száma: {lovesek.FindAll(a => a.Pontszam(x_kozeppont, y_kozeppont) == 0).Count} db");

            //10.feladat
            Console.WriteLine($"\n10.feladat: Játékosok száma: {lovesek.GroupBy(a => a.Nev).Count()}");

            //11.feladat
            foreach (var item in lovesek.GroupBy(a => a.Nev).ToList())
            {
                Console.WriteLine($"\t{item.Key} - {lovesek.FindAll(a =>a.Nev == item.Key).Count} db");
            }

            //12.feladat
            Console.WriteLine("\n12.feladat: Átlagpontszámok");
            double legnagyobb = 0;
            string neve = "";
            foreach (var item in lovesek.GroupBy(a => a.Nev).ToList())
            {
                double atlag = 0;
                foreach (var it in lovesek.FindAll(a => a.Nev == item.Key))
                {
                    atlag += it.Pontszam(x_kozeppont, y_kozeppont);
                }
                atlag /= lovesek.FindAll(a => a.Nev == item.Key).Count;
                Console.WriteLine($"\t{item.Key} - {atlag}");

                if(legnagyobb < atlag)
                {
                    legnagyobb = atlag;
                    neve = item.Key;
                }
            }

            //13.feladat
            Console.WriteLine($"\n13.feladat: A játék nyertese: {neve}");
            Console.ReadKey();
        }

        //4.feladat
        static void Beolvasas(string file)
        {
            using (StreamReader sr = new StreamReader(file)) 
            {
                string[] sor = sr.ReadLine().Split(';');
                x_kozeppont = Convert.ToDouble(sor[0]);
                y_kozeppont = Convert.ToDouble(sor[1]);

                int azonosito = 1;
                while (!sr.EndOfStream)
                {
                    sor = sr.ReadLine().Split(';');
                    lovesek.Add(new JatekosLovese(sor[0], Convert.ToDouble(sor[1]), Convert.ToDouble(sor[2]), azonosito));
                    azonosito++;
                }
            }
        }
    }
}
