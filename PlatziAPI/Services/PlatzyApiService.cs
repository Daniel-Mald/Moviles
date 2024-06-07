//using AuthenticationServices;
//using Microsoft.UI.Xaml.Controls;
using PlatziAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatziAPI.Services
{
    public class PlatzyApiService
    {
        string url = "https://api.escuelajs.co/api/v1/products";
        HttpClient client;

        public async Task<List<ProductoD>> GetProductos()
        {
            client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            //var data = JsonSerializer.Deserialize<List<ProductoD>>(json);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductoD>>(json);
            return data;
            //var categoryData = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductoDTO>(json);
        }
        public async Task<ProductoD> GetProducto(int id)
        {
            client = new HttpClient();

            var response = await client.GetAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //var data = JsonSerializer.Deserialize<ProductoD>(json);
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductoD>(json);
                return data;

            }
            return new ProductoD();

        }
        public async Task AddProduct(ProductoPostDTO p)
        {
            client = new HttpClient();
            var json = JsonSerializer.Serialize<ProductoPostDTO>(p);
            HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage mensaje=  await client.PostAsync(url, contenido);
            if(mensaje.IsSuccessStatusCode)
            {
                string respuesta = "nice";
            }
        }
        public async Task UpdateProduct(ProductoD p)
        {
            
            client = new HttpClient();
            var json = JsonSerializer.Serialize<ProductoD>(p);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage mensaje = await client.PutAsync($"{url}/{p.Id}", content);
            //no lo edita, talvez hay que hacer un nuevo dto
            if (mensaje.IsSuccessStatusCode)
            {
                string respuesta = "editado";
            }
        }
        public async Task DeleteProduct(int Id)
        {
            client = new();
            HttpResponseMessage mensaje = await client.DeleteAsync($"{url}/{Id}");
            if (mensaje.IsSuccessStatusCode)
            {

                string respuesta = "eliminado";
            }
        }
    }
}
