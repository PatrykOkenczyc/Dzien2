﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Zadanie1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string website = "https://www.google.com/search?q=pogoda";
            string findSymbol = "°";
            string start = ">";
            string end = "<";
            
            while (true)
            {

                Console.WriteLine("Podaj miasto : ");
                string city = Console.ReadLine().ToLower();

                WebClient wc = new WebClient();
                string dane = wc.DownloadString(website + city);
                int tempPlace = dane.IndexOf(findSymbol);
                int i = tempPlace;
                int j = tempPlace;

                while ( dane.Substring(i, 1) != start)
                {
                    i--;
                }
                while (dane.Substring(j, 1) != end)
                {
                    j++;
                }                
                
                string temp = dane.Substring((i + 1), (j - i - 1));

                Console.WriteLine(temp);
            }
           

        }
    }
}
