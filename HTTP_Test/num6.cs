
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
            foreach (var X in response.Css("ul.slides > li > a"))
            {
                string url = X.Attributes["href"];
                this.Request(url, Parse2);
          
            }
        }
        public void Parse2(Response response)
        {

            Console.WriteLine(response.Css("div.movie-info-title").First().InnerText.Replace("\t", ""));
            foreach (var X in response.Css("div.movie-add-info > ul"))
            {
                Console.WriteLine(X.InnerText.Replace("\t", ""));
            }
            Console.WriteLine(response.Css("div.movie-synopsis").First().InnerText.Replace("\t", ""));
        }
    }
}
