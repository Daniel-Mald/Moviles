using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers.Commands;
using PlatziAPI.Models.DTOs;
using PlatziAPI.Services;
using PlatziAPI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlatziAPI.ViewModels
{
    public partial class PlatzyViewModel : ObservableObject
    {

        
        public ObservableCollection<ProductoD> Productos { get; set; } = new();
        [ObservableProperty]
        ProductoD producto = new();
        [ObservableProperty]
        ProductoPostDTO prodPost = new();
        private PlatzyApiService _service;
        
        public PlatzyViewModel()
        {
            
            _service = new PlatzyApiService();
            VerProductos(); 
        }
        [RelayCommand]
        private async Task Agregar()
        {
            if(ProdPost != null)
            {
                 await _service.AddProduct(ProdPost);
            }
            
        }
        [RelayCommand]
        private async Task VerAgregar()
        {
            ProdPost = new();
            await Shell.Current.GoToAsync("//AgregarProducto");
        }
        [RelayCommand]
        private async Task Eliminar(int id)
        {
            var p = await _service.GetProducto(id);
            if(p != null)
            {
                Producto = p;
                
                await _service.DeleteProduct(id);
                
            }
            
        }
        
        [RelayCommand]
        private async Task Editar()
        {
            if(Producto!= null)
            await _service.UpdateProduct(Producto);
        }
        [RelayCommand]
        private async Task VerEditar(int id)
        {
            var p = await _service.GetProducto(id);
            Producto = p;
            
            await Shell.Current.GoToAsync(nameof(EditarView));
        }

        //
        [RelayCommand]
        public async Task VerProducto(int id)
        {
            
            var p = await _service.GetProducto(id);
            if (p != null)
            {
                Producto = p;
                Dictionary<string,object> data = new Dictionary<string, object>() 
                {
                    {"producto",Producto }
                };
                await Shell.Current.GoToAsync("ProductoView",data);
                //Por hacer
            }
            
        }
        [RelayCommand]
        public async Task VerProductos()
        {
            var p = await _service.GetProductos();
            if(p != null)
            {
                Productos.Clear();
                foreach (var item in p)
                {
                    Productos.Add(item);
                }
            }
        }
        
        

    }
}
