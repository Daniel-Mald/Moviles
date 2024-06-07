using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp.Services
{
    public class JokeApi
    {
        private string url = "https://v2.jokeapi.dev/";
        HttpClient client;
        public async Task<List<string>> GetCategories()
        {
            client = new HttpClient();
            var respuesta = await client.GetAsync($"{url}categories");
            respuesta.EnsureSuccessStatusCode();
            var json = await respuesta.Content.ReadAsStringAsync();
            var categoryData = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoriesData>(json);
            return categoryData.Categories;
        }
        public async Task<string> GetJoke(string category)
        {
            client = new HttpClient();
            var respuesta = await client.GetAsync($"{url}joke/{category}"); 
            respuesta.EnsureSuccessStatusCode();
            var json = await respuesta.Content.ReadAsStringAsync();
            var JokeData = Newtonsoft.Json.JsonConvert.DeserializeObject<JokeData> (json);
            return (JokeData.Type == "single" ? JokeData.Joke :
                $"{JokeData.SetUp} {JokeData.Delivery}");
        }
    }
}
