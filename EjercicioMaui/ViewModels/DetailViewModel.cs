using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EjercicioMaui.ViewModels
{
    [QueryProperty("Text","mango")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        string text;


        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
