using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj kraj zawodnika : ");
            string kraj = Console.ReadLine().ToLower();

            string website = "https://tomaszles.pl/wp-content/uploads/2019/06/zawodnicy.txt";
            WebClient wc = new WebClient();
            string dane = wc.DownloadString(website);

            string[] separatorWierszy = {"\r\n"};
            string[] wiersze = dane.Split(separatorWierszy, StringSplitOptions.RemoveEmptyEntries);

            List<string> zawodnicy = new List<string>();

            for (int i = 1; i < wiersze.Length; i++)
            {
                string[] komorki = wiersze[i].Split(';');
                if (komorki[4].ToLower() == kraj)
                    zawodnicy.Add(komorki[2] + " " + komorki[3]);
            }

            string sciezkaWynik = @"D:\dane\kraje";
            if(!Directory.Exists(sciezkaWynik))
                Directory.CreateDirectory(sciezkaWynik);


            if(!File.Exists(sciezkaWynik + $@"\{kraj}.txt"))
                File.WriteAllLines(sciezkaWynik + $@"\{kraj}.txt", zawodnicy);

           

        }
    }
}
