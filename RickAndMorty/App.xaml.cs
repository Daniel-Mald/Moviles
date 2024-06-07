using RickAndMorty.Views;

namespace RickAndMorty
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NewPage1();
        }
    }
}
