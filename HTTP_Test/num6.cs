
using System;
using IronWebScraper;
using System.Linq;

namespace HTTP_Test
{
    public class num6 : WebScraper
    {
        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request("https://www.cgv.id/en/", Parse);
        }

        public override void Parse(Response response)
        {
            foreach (var titleLink in response.Css("ul.slides > li > a"))
            {
                string link = titleLink.Attributes["href"];
                this.Request(link, Parse2);
          
            }
        }
        public void Parse2(Response response)
        {
            string title = response.Css("div.movie-info-title").First().InnerText.Replace("\t", "");
            Console.WriteLine(title);
            foreach (var X in response.Css("div.movie-add-info > ul"))
            {
                string info = X.InnerText.Replace("\t", "");
                Console.WriteLine(info);
            }
            string synopsis = response.Css("div.movie-synopsis").First().InnerText.Replace("\t", "");

            Console.WriteLine(synopsis);
        }
    }
}
