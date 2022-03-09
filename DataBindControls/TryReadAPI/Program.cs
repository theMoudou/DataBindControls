using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryReadAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //string url = "http://localhost:8081/FirstAPI.ashx?q=John";
            string url = "https://www.google.com";

            System.Net.WebClient client = new System.Net.WebClient();
            string apiData = client.DownloadString(url);

            Console.WriteLine(apiData);
            Console.ReadLine();
        }
    }
}
