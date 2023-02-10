using System;

namespace CrawlWeb
{
    public static class LinkInfo
    {
        public const string WebURL = "https://stackoverflow.com/questions?tab=newest&page=";

        public static void GetPage(int a,int b)
        {
            for(int i =a;i<=b;i++)
            {
                Console.WriteLine("             ***--------Start of Page {0}-------***", i.ToString());
                string WebURLPage = WebURL + i.ToString();
                Processor.GetQuestions(WebURLPage);
                Console.WriteLine("             ***---------End of Page {0}--------***", i.ToString());
            }
        }
    }
}
