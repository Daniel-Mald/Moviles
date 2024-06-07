using EjercicioMaui.ViewModels;

namespace EjercicioMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new();
        }
    }
}
