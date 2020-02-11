using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IronWebScraper;
using Newtonsoft.Json;

namespace HTTP_Test
{
    public class Kompas
    {
        
        public class BlogScrapper : WebScraper
        {
            public override void Init()
            {
                LoggingLevel = WebScraper.LogLevel.All;
                Request("https://kompas.com", Parse);
            }

            //public override void Parse(Response response)
            //{
            //    foreach (var result in response.Css("div.headline.ga--headline.clearfix > h2"))
            //    {
            //        string title = result.TextContentClean;
            //        Console.WriteLine(title);
            //        Console.WriteLine("");
            //    }
            //}


            public override void Parse(Response response)
            {
                List<string> tit = new List<string>();
                List<string> url = new List<string>();
                foreach (var result in response.Css("div.headline.ga--headline.clearfix"))
                {
                    //string t = result.TextContentClean;
                    //foreach(var X in result.TextContentClean)
                    //Console.WriteLine(t);
                    //Console.WriteLine("");

                    //tit.Add(result.InnerTextClean("h2");

                    for (int i =0; i<result.Css("a[href]").Length;i++)
                    {
                        //tit.Add(result.Css("h2")[i].Attributes);
                        url.Add(result.Css("a[href]")[i].Attributes["href"]);

                    }
                    

                }
                for(int i =0;i<url.Count;i++)
                {
                    Console.WriteLine(tit[i]);
                    Console.WriteLine(url[i]);
                }
            }
        }
    
    }
}
