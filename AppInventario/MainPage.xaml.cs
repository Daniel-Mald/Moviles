using AppInventario.Data;
using AppInventario.Models;

namespace AppInventario
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {

        }

        private void ContentPage_Loaded_1(object sender, EventArgs e)
        {
            var db = new ArticuloDbContext();
            var articulo = new Articulo
            {
                Descripcion = "Pancho zote 500 gr.",
                Precio = 59,
                Existencia = 100
            };
            db.Agregar(articulo);
            awa();
            var lista = db.GetAll();
        }
        async Task awa()
        {
            var db = new ArticuloDbContext();
            //Articulo x = await db.GetById(1);
            //x.Precio = 20;
            //db.Editar(x);
            var y = await db.GetById(1);
            var a = db.GetAll();
            
            //await db.Eliminar(1);
        }
    }

}
