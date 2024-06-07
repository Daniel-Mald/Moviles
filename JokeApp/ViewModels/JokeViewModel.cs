using JokeApp.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JokeApp.ViewModels
{
    public class JokeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private JokeApi api;
        public List<string> Categories { get; set; }
        public ICommand MostrarCommand { get; set; }
        public string Category { get; set; } = "any";
        public string Joke { get; set; } = "sandia";
        public JokeViewModel()
        {
            LLnarcategories();
            MostrarCommand = new AsyncCommand(Mostrar);
        }
        private async Task LLnarcategories()
        {
            api = new JokeApi();
            Categories = await api.GetCategories();
            OnPropertyChanged(nameof(Categories));
        }
        public async Task Mostrar()
        {
            api = new JokeApi();
            Joke = await api.GetJoke(Category);
            OnPropertyChanged(nameof(Joke));

        }
        //TODO: Disparar propertycahnged
        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
