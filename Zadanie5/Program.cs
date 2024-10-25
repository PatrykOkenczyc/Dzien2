using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5
{
    internal class Program
    {
        static void Main(string[] args)
        {            

            string website = "https://tomaszles.pl/wp-content/uploads/2019/06/zawodnicy.txt";
            WebClient wc = new WebClient();
            string dane = wc.DownloadString(website);

            string[] separatorWierszy = { "\r\n" };
            string[] wiersze = dane.Split(separatorWierszy, StringSplitOptions.RemoveEmptyEntries);

            int liczbaWierszy = wiersze.Length;
            int liczbaKolumn = wiersze[0].Split(';').Length;


            string[,] zawodnicy = new string[liczbaWierszy, liczbaKolumn];

            

            for (int i = 1; i < wiersze.Length; i++)
            {
                string[] komorki = wiersze[i].Split(';');
                for (int j = 0; j < komorki.Length; j++)
                {
                    zawodnicy[i-1,j] = komorki[j];
                }
            }

            for (int i = 0; i < zawodnicy.GetLength(0); i++)
            {
                
                for (int j = 0; j < zawodnicy.GetLength(1); j++)
                {
                    Console.Write(zawodnicy[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.ReadKey();



        }
    }
}
