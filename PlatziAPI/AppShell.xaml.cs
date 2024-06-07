using PlatziAPI.Views;

namespace PlatziAPI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Page1/ProductoView",typeof(VerPreductoView));
            Routing.RegisterRoute(nameof(EditarView),typeof(EditarView));
        }
    }
}
