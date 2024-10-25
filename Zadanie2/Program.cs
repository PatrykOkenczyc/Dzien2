using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] miasta = File.ReadAllLines("D:\\miasta.txt");
            int x = 0;
            for (x = 0; x < miasta.Length; x++)
            {
                Console.WriteLine($"[{x}]  {miasta[x]}");
            }

            string website = "https://www.google.com/search?q=pogoda";
            string findSymbol = "°";
            string start = ">";
            string end = "<";

            while (true)
            {

                Console.WriteLine("Wybierz miasto : ");
                int city = Convert.ToInt32(Console.ReadLine());

                WebClient wc = new WebClient();
                string dane = wc.DownloadString(website + " " + miasta[city]);
                
                int tempPlace = dane.IndexOf(findSymbol);
                int i = tempPlace;
                int j = tempPlace;

                while (dane.Substring(i, 1) != start)
                {
                    i--;
                }
                while (dane.Substring(j, 1) != end)
                {
                    j++;
                }

                string temp = dane.Substring((i + 1), (j - i - 1));

                Console.WriteLine($"Temperatura dla miasta {miasta[city]} wynosi {temp}");
            }






        }
    }
}
