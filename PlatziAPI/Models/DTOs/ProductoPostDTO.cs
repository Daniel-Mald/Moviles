using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziAPI.Models.DTOs
{
    public class ProductoPostDTO
    {
        public string title { get; set; } = null!;
        public decimal price { get; set; } = 0;
        public string description { get; set; } = "";
        public int categoryId { get; set; } = 1;
        public List<string> images { get; set; } = new() { "https://i.imgur.com/QkIa5tT.jpeg" };
       
    }
}
