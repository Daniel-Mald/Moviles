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
    }
}
