using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziAPI.Models.DTOs
{
    public class ProductoPutDTO
    {
        public decimal Price { get; set; }
        public string Title { get; set; } = "";
    }
}
