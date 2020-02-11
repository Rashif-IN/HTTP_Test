using System;
using IronWebScraper;


namespace HTTP_Test
{
    public class Kompas
    {
        
        public class num5 : WebScraper
        {
            public override void Init()
            {
                LoggingLevel = WebScraper.LogLevel.All;
                Request("https://kompas.com", Parse);
            }

            public override void Parse(Response response)
            { 
                foreach (var X in response.Css("a.headline__thumb__link"))
                {
                    Console.WriteLine();
                    Console.WriteLine(X.Attributes["href"]); //url
                    Console.WriteLine(X.InnerTextClean); //isinya, judul
                    Console.WriteLine();
                }
            }
        }
    
    }
}
