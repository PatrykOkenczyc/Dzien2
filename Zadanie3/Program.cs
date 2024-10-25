using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string website = "https://www.google.com/search?q=pogoda";
            string findSymbol = "°";
            string start = ">";
            string end = "<";
            int temperatura = 0; 
            List<string> miasta = new List<string>();
            List<int> srTemperatura = new List<int>();
            


            while (true)
            {

                Console.WriteLine("Podaj miasto : ");
                string city = Console.ReadLine().ToLower();
                miasta.Add(city);
                WebClient wc = new WebClient();
                string dane = wc.DownloadString(website + city);
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
                temperatura = Convert.ToInt32(dane.Substring((i + 1), (tempPlace - i - 1))); 
                string temp = dane.Substring((i + 1), (j - i - 1));
                Console.WriteLine(temp);
                srTemperatura.Add(temperatura);

                double srednia = 0;
                foreach (var s in srTemperatura)
                    srednia += s;

                srednia /= srTemperatura.Count;

                string raport = string.Format("Średnia temperatura z lista ({0}) to {1} °C",
                        string.Join(",", miasta), srednia);
                Console.WriteLine(raport);

            }
        }
    }
}
