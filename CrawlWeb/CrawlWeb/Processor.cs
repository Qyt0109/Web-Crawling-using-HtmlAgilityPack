using System;
using AngleSharp;
using AngleSharp.Html.Parser;
using Fizzler;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CrawlWeb
{
    public class Processor
    {
        public static IEnumerable<Question> GetQuestions(string url)
        {
            var web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };

            var document = web.Load(url);
            var questions = document.DocumentNode.QuerySelectorAll("div.s-post-summary.js-post-summary").ToList();
            
            foreach(var question in questions)
            {
                int votes = int.Parse(question.QuerySelectorAll("div.s-post-summary--stats.js-post-summary-stats > div:nth-child(1) > span.s-post-summary--stats-item-number").FirstOrDefault().InnerText);
                int answers = int.Parse(question.QuerySelectorAll("div.s-post-summary--stats.js-post-summary-stats > div:nth-child(2) > span.s-post-summary--stats-item-number").FirstOrDefault().InnerText);
                int views = int.Parse(question.QuerySelectorAll("div.s-post-summary--stats.js-post-summary-stats > div:nth-child(3) > span.s-post-summary--stats-item-number").FirstOrDefault().InnerText);
                string title = question.QuerySelectorAll("div.s-post-summary--content > h3.s-post-summary--content-title > a").FirstOrDefault().InnerText;
                string summary = question.QuerySelectorAll("div.s-post-summary--content > div.s-post-summary--content-excerpt").FirstOrDefault().InnerText.Replace("\r\n", "");
                summary = Regex.Replace(summary, @"\s+", " ");
                Console.WriteLine("Votes:  "+votes.ToString());
                Console.WriteLine("Answers:"+answers.ToString());
                Console.WriteLine("Views:  "+views.ToString());
                Console.WriteLine("Title:  "+title);
                Console.WriteLine("Summary:"+summary);
                Console.WriteLine("----------------------------------------------------------------------------");
            }
            
            return default;
        }

    }
}
