using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoteDeAutos.Data;
using LoteDeAutos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoteDeAutos.ViewModels
{
    public partial class AutosViewModel:ObservableObject
    {
        AutoDbContext _context = new();
        [ObservableProperty]
        public Auto auto = new();

        public ObservableCollection<Auto> _autos { get; set; } = new ObservableCollection<Auto>();

        [RelayCommand]
        public async Task Agregar()
        {
            if(Auto != null) 
            {
                await _context.Add(Auto);
                 CambiarVista("Inicio");
            }
        }
        [RelayCommand]
        public async Task VerEditar(int id)
        {
            var x = await _context.GetById(id);
            if(x != null)
            {
                Auto = x;
                CambiarVista("Editar");
            }

        }
        [RelayCommand]
        public async Task Editar()
        {
            
            if(Auto != null)
            {
                await _context.Update(Auto);
                 CambiarVista("Inicio");
            }
        }
        
        [RelayCommand]
        public async Task Eliminar(int id)
        {
            var x = _context.GetById(id);
            if(x != null)
            {
                await _context.Delete(id);
                CambiarVista("Inicio");
            }
        }
        [RelayCommand]
        public  void CambiarVista(string view)
        {
            if(view == "Agregar")
            {
                Auto = new();
            }
                Shell.Current.GoToAsync(view);          
        }
    }
}
