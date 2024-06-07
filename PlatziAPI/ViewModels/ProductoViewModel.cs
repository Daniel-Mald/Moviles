using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlatziAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziAPI.ViewModels
{
    [QueryProperty(nameof(Producto),"producto")]
    public partial class ProductoViewModel: ObservableObject
    {
        [ObservableProperty]
        ProductoD producto;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
