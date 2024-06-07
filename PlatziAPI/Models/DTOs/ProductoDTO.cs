using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziAPI.Models.DTOs
{
    public class ProductoD
    {

        public string Title { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public string Description { get; set; } = "";
        public int CategoryId { get; set; } = 1;
        public List<string> Images { get; set; } = new();
        public int Id { get; set; }

        //"https://placeimg.com/640/480/any"






    }
    public class ProductoDto
    {
        public List<ProductoD> Productos { get; set; }
    }
    
}
