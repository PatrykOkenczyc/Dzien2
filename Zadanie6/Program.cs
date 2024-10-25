using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string website = "https://tomaszles.pl/wp-content/uploads/2019/06/zawodnicy.txt";
            WebClient wc = new WebClient();
            string dane = wc.DownloadString(website);

            string[] separatorWierszy = {Environment.NewLine};
            string[] wiersze = dane.Split(separatorWierszy, StringSplitOptions.RemoveEmptyEntries);

            int liczbaWierszy = wiersze.Length - 1;            

            string[][] tabela = new string[liczbaWierszy][];

            for (int i = 1; i <= liczbaWierszy; i++)
            {
                tabela[i - 1] = wiersze[i].Split(';');
            }

            foreach (var zw in tabela)
            {
                Console.WriteLine(string.Join(" ", zw));
            }
            Console.ReadKey();
        }
    }
}
