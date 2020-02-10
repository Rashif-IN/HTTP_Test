using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IronWebScraper;
using System.Linq;

namespace HTTP_Test
{
    //num2
    public class Address
    {
        public string label { get; set; }
        public string address { get; set; }
        public string city { get; set; }
    }

    public class Phone
    {
        public string label { get; set; }
        public string phone { get; set; }
    }

    public class Department
    {
        public string name { get; set; }
    }

    public class Position
    {
        public string name { get; set; }
    }

    public class RootObject2
    {
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string birthday { get; set; }
        public List<Address> addresses { get; set; }
        public List<Phone> phones { get; set; }
        public List<string> presence_list { get; set; }
        public int salary { get; set; }
        public Department department { get; set; }
        public Position position { get; set; }
    }

    //num3
    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Address3
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address3 address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }

    public class RootObject3
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public User user { get; set; }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {

            //var res = await GetUser();
            //Console.WriteLine(String.Join(" ", res));
            //foreach (var X in res)
            //{
            //    Console.WriteLine(X.Name);
            //    Console.WriteLine(X.Id);

            //}
            //var res2 = await GetPosts();
            //Console.WriteLine(res2);
            //var scraper = new BlogScraper();
            //await scraper.StartAsync();

            var numTwo = await Fetch();
            Console.WriteLine("employees who have salary more than Rp15.000.000 :");
            List<string> sal = new List<string>();
            foreach (var X in numTwo)
            {
                if(X.salary>15000000)
                {
                    sal.Add($"{X.first_name} {X.last_name}");
                }
            }
            Console.WriteLine(String.Join(", ", sal));
            Console.WriteLine();
            
            Console.WriteLine("employees who live in jakara :");
            List<string> jkt48 = new List<string>();
            foreach (var X in numTwo)
            {
                foreach(var Y in X.addresses)
                {
                    if(Y.city== "DKI Jakarta")
                    {
                        jkt48.Add($"{X.first_name} {X.last_name}");
                    }
                }
            }
            var jkt96 = jkt48.Distinct();
            Console.WriteLine(String.Join(", ", jkt96));
            Console.WriteLine();

            Console.WriteLine("employees whos birthday on March :");
            List<string> Mar = new List<string>();
            foreach (var X in numTwo)
            {
                if ((X.birthday).Substring(5,2)=="03")
                {
                    Mar.Add($"{X.first_name} {X.last_name}");
                }
            }
            Console.WriteLine(String.Join(", ", Mar));
            Console.WriteLine();

            Console.WriteLine("employees in Research and Development departement :");
            List<string> RnD = new List<string>();
            foreach (var X in numTwo)
            {
                if(X.department.name== "Research and development")
                {
                    RnD.Add($"{X.first_name} {X.last_name}");
                }
            }
            Console.WriteLine(String.Join(", ", RnD));
            Console.WriteLine();

            Console.WriteLine("employee absences in October 2019 :");
            List<int> Absen = new List<int>();
            foreach (var X in numTwo)
            {
                int count = 0;
                foreach(var Y in X.presence_list)
                {
                    if(Y.Substring(5,2)=="10")
                    {
                        count++;
                    }
                    
                }
                Absen.Add(count);
                
            }
            Console.WriteLine(String.Join(", ", Absen));
        }

        public static async Task<List<RootObject2>> Fetch()
        {

            var client = new HttpClient();

            var result = await client.GetStringAsync("https://mul14.github.io/data/employees.json");

            var fet = JsonConvert.DeserializeObject<List<RootObject2>>(result);

            return fet;
        }

        public static async Task<List<RootObject3>> Join()
        {

            var client = new HttpClient();

            var post = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            var joPost = JsonConvert.DeserializeObject<List<RootObject3>>(post);

            var user = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            var joUser = JsonConvert.DeserializeObject<List<User>>(user);

            foreach(var X in joPost)
            {
                
                foreach(var Y in joUser)
                {
                    if (X.userId == Y.id)
                    {
                        //masukinnya gimana
                    }
                }
                
            }

            return joPost;
        }

        public static async Task<List<User>> GetUser()
        {

            var client = new HttpClient();

            var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            var user = JsonConvert.DeserializeObject<List<User>>(result);
            return user;
        }

        public static async Task<string> GetPosts()
        {
            var client = new HttpClient();

            var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            return result;
        }




    }

    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    class Post
    {
        public int Id { get; set; }
        public int Tittle { get; set; }
        public string body { get; set; }

    }
    class BlogScraper : WebScraper
    {
        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request("https://blog.scrapinghub.com", Parse);
        }
        public override void Parse(Response response)
        {
            //foreach (var title_link in response.Css("h2.entry-title a"))
            //{
            //    string strTitle = title_link.TextContentClean;
            //    Scrape(new ScrapedData() { { "Title", strTitle } });
            //}
            foreach (var X in response.Css("span.date"))
            {
                string tit = X.Css("a[href]")[0].Attributes["href"];
                Console.WriteLine(tit);
            }

            //if (response.CssExists("div.prev-post > a[href]"))
            //{
            //    var next_page = response.Css("div.prev-post > a[href]")[0].Attributes["href"];
            //    this.Request(next_page, Parse);
            //}

        }
    }
}
