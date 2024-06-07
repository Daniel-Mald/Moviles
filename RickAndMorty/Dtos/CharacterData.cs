using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Dtos
{
    public class CharacterData
    {
        public string Name { get; set; } = null!;
        public string image { get; set; } = "";

    }
    public class Personajes
    {
        public List<CharacterData> Results { get; set; } = new();
    }
}
