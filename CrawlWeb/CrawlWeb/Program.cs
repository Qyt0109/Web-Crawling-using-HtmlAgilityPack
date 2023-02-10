using System;

namespace CrawlWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("STACK OVERFLOW'S QUESTIONS [WEB CRAWL DEMO]");
                Console.Write("Choose start page: ");
                int startPage = int.Parse(Console.ReadLine());
                Console.Write("Choose stop page : ");
                int stopPage = int.Parse(Console.ReadLine());
                LinkInfo.GetPage(startPage, stopPage);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
