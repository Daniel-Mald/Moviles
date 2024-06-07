using Newtonsoft.Json;
using RickAndMorty.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RickAndMorty.Services
{
    public class ApiService
    {
        string url = "https://rickandmortyapi.com/api/character/?page=19";
        HttpClient client;

        public async Task<List<CharacterData>> GetCharacter()
        {
            client = new HttpClient();
            

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var categoryData = Newtonsoft.Json.JsonConvert.DeserializeObject<Personajes>(json);

            return categoryData.Results;
            
          // return data;
        }

    }
}
