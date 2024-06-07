using AppInventario.Data;
using AppInventario.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoreImage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInventario.ViewModels
{
    public partial class InventoryViewModel:ObservableObject
    {
        ObservableCollection<Articulo> Articulos { get; set; } = new ObservableCollection<Articulo>();
        [ObservableProperty]
        public Articulo _articulo;
        ArticuloDbContext _db = new();
        [RelayCommand]
        void ChangeView(string? view = "Main")
        {

        }
        [RelayCommand]
        void Add()
        {

        }
        [RelayCommand]
        void Remove()
        {

        }
        [RelayCommand]
        void Update()
        {

        }
    }
}
