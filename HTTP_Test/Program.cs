using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IronWebScraper;
using System.Linq;
using System.IO;




namespace HTTP_Test
{

    class Program 
    {
        
        public static async Task Main(string[] args)
        {

            //var num1A = await Fethcer.Get("https://httpbin.org/get");
            //Fethcer.Delete("https://httpbin.org/delete");


            //NomerDua();


            //num3
            //var numTree = await Join();
            //var numTreeFile = JsonConvert.SerializeObject(numTree);
            //File.WriteAllText(@"//Users/user/Projects/HTTP_Test/HTTP_Test/num3.json", numTreeFile);

            //num4
            //var numFourA = await movieIndonesia();
            //var numFourAFile = JsonConvert.SerializeObject(numFourA);
            //File.WriteAllText(@"//Users/user/Projects/HTTP_Test/HTTP_Test/num4A.json", numFourAFile);
            //var numFourB = await movieKeanu();
            //var numFourBFile = JsonConvert.SerializeObject(numFourB);
            //File.WriteAllText(@"//Users/user/Projects/HTTP_Test/HTTP_Test/num4B.json", numFourBFile);
            //var numFourC = await movieRobertHolland();
            //var numFourCFile = JsonConvert.SerializeObject(numFourC);
            //File.WriteAllText(@"//Users/user/Projects/HTTP_Test/HTTP_Test/num4C.json", numFourCFile);
            //var numFourD = await movie2016();
            //var numFourDFile = JsonConvert.SerializeObject(numFourD);
            //File.WriteAllText(@"//Users/user/Projects/HTTP_Test/HTTP_Test/num4D.json", numFourDFile);

            //num5
            var Num5 = new Kompas.num5();
            await Num5.StartAsync();

            //num6
            //var Num6 = new num6();
            //await Num6.StartAsync();
        }



        static async void NomerDua()
        {
            var numTwo = await Fetch();
            Console.WriteLine("employees who have salary more than Rp15.000.000 :");
            List<string> sal = new List<string>();
            foreach (var X in numTwo)
            {
                if (X.salary > 15000000)
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
                foreach (var Y in X.addresses)
                {
                    if (Y.city == "DKI Jakarta")
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
                if ((X.birthday).Substring(5, 2) == "03")
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
                if (X.department.name == "Research and development")
                {
                    RnD.Add($"{X.first_name} {X.last_name}");
                }
            }
            Console.WriteLine(String.Join(", ", RnD));
            Console.WriteLine();

            Console.WriteLine("employee absences in October 2019 :");
            List<int> Absen = new List<int>();
            List<string> Name = new List<string>();
            foreach (var X in numTwo)
            {
                int count = 0;
                foreach (var Y in X.presence_list)
                {
                    if (Y.Substring(5, 2) == "10")
                    {
                        count++;
                    }

                }
                Absen.Add(count);
                Name.Add($"{X.first_name} {X.last_name}");
            }
            var Names = Name.Distinct();

            Console.WriteLine(String.Join(", ", Names));
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

            var result = new List<RootObject3>();

            foreach(var X in joPost)
            {
                
                foreach(var Y in joUser)
                {
                    if (X.userId == Y.id)
                    {
                        result.Add(new RootObject3
                        {
                            userId = X.userId,
                            id = X.id,
                            title = X.title,
                            body = X.body,
                            user = new User
                            {
                                id = Y.id,
                                name = Y.name,
                                username = Y.username,
                                email = Y.email,
                                address = new Address3
                                {
                                    street = Y.address.street,
                                    suite = Y.address.suite,
                                    city = Y.address.city,
                                    zipcode = Y.address.zipcode,
                                    geo = new Geo
                                    {
                                        lat = Y.address.geo.lat,
                                        lng = Y.address.geo.lng
                                    }
                                },
                                phone = Y.phone,
                                website = Y.website,
                                company = new Company
                                {
                                    name = Y.company.name,
                                    catchPhrase = Y.company.catchPhrase,
                                    bs = Y.company.bs
                                }
                            }
                        });
                    }   
                }
                
            }

            return result;
        }

        public static async Task<string> movieIndonesia()
        {
            var client = new HttpClient();
            var resource = await client.GetStringAsync("https://api.themoviedb.org/3/discover/movie?api_key=8cd7fddc5897bc4305410d8af106f7d0&language=en-US&sort_by=popularity.desc&include_video=false&with_original_language=id");

            var listTitle = new List<string>();
            var filmIndonesia = JsonConvert.DeserializeObject<RootObject4>(resource);

            foreach (var X in filmIndonesia.results)
            {
                listTitle.Add(X.title);
            }

            return String.Join(", ", listTitle);

        }

        public static async Task<string> movieKeanu()
        {
            var client = new HttpClient();
            var resource = await client.GetStringAsync("https://api.themoviedb.org/3/discover/movie?api_key=8cd7fddc5897bc4305410d8af106f7d0&with_people=6384&sort_by=popularity.desc");

            var listTitle = new List<string>();
            var filmKeanu = JsonConvert.DeserializeObject<RootObject4>(resource);

            foreach (var X in filmKeanu.results)
            {
                listTitle.Add(X.title);
            }

            return String.Join(", ", listTitle);

        }

        public static async Task<string> movieRobertHolland()
        {
            var client = new HttpClient();
            var resource = await client.GetStringAsync("https://api.themoviedb.org/3/discover/movie?api_key=8cd7fddc5897bc4305410d8af106f7d0&with_people=3223,1136406&sort_by=popularity.desc");

            var listTitle = new List<string>();

            var filmRobertHolland = JsonConvert.DeserializeObject<RootObject4>(resource);

            foreach (var X in filmRobertHolland.results)
            {
                listTitle.Add(X.title);
            }

            return String.Join(", ", listTitle);


        }

        public static async Task<string> movie2016()
        {
            var client = new HttpClient();
            var resource = await client.GetStringAsync("https://api.themoviedb.org/3/discover/movie?api_key=8cd7fddc5897bc4305410d8af106f7d0&language=en-US&sort_by=popularity.desc&include_adult=true&include_video=false&year=2016&vote_average.gte=7.5");

            var listTitle = new List<string>();

            var filmRobertHolland = JsonConvert.DeserializeObject<RootObject4>(resource);

            foreach (var X in filmRobertHolland.results)
            {
                listTitle.Add(X.title);
            }

            return String.Join(", ", listTitle);


        }





    }

    
    
}
