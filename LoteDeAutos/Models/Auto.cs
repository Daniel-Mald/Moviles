using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoteDeAutos.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public string Version { get; set; } = "";
        public short Año { get; set; }
        public decimal Precio { get; set; }
        public int Kilometraje { get; set; }
        public string Motor { get; set; } = "";
        public string Transmision { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public TipoCarroceria Carroceria { get; set; }
    }
    public enum TipoCarroceria 
    {
        Roadster,
        Camión_ligero,
        Vagoneta,
        Todo_terreno,
        Crossover,
        Furgoneta,
        Minivan,
        Convertible,
        Van,
        Coupé,
        Pick_Up,
        Hatchback,
        Sedán,
        SUV
    }
}
