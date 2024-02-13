using JokeApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp.ViewModels
{
    public class JokeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private JokeApi api;
        public List<string> Categories;
        public string Category { get; set; } 
        public JokeViewModel()
        {
            LLnarcategories();
        }
        private async Task LLnarcategories()
        {
            api = new JokeApi();
            Categories = await api.GetCategories();
        }
        //TODO: Disparar propertycahnged
    }
}
