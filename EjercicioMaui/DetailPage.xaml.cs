using EjercicioMaui.ViewModels;

namespace EjercicioMaui;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}