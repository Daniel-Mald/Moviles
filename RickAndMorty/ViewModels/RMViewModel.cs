using RickAndMorty.Dtos;
using RickAndMorty.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.ViewModels
{
    public class RMViewModel : INotifyPropertyChanged
    {
        private ApiService api;
        public List<CharacterData> Personajes { get; set; } = new();
        public string Mensaje { get; set; } = "";
        public event PropertyChangedEventHandler? PropertyChanged;
        public RMViewModel()
        {
            LlamarApi();
        }
        async Task LlamarApi()
        {
            api = new();
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;
            if (accessType == NetworkAccess.Internet)
            {

             Personajes = await api.GetCharacter();
                Mensaje = "Si hay conexion";
            }
            else
            {
                Mensaje = "No hay conexion perro";
            }


            //PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(Personajes)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
