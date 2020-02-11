
using System.Net.Http;
using System.Threading.Tasks;


namespace HTTP_Test
{
    class Fethcer
    {
        static HttpClient client = new HttpClient();

        public static async Task<string> Get(string url)
        {
            return await client.GetStringAsync(url);

        }

        public static async void Delete(string url)
        {
            await client.DeleteAsync(url);

        }
        public static async void Post(string url, HttpContent data)
        {
            await client.PostAsync(url, data);
        }

        public static async void Put(string url, HttpContent data)
        {
            await client.PutAsync(url, data);
        }

        public static async void Patch(string url, HttpContent data)
        {
            await client.PatchAsync(url, data);
        }

    }
}
