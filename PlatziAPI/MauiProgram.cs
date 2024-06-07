using Microsoft.Extensions.Logging;
using PlatziAPI.ViewModels;
using PlatziAPI.Views;

namespace PlatziAPI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

#endif
            builder.Services.AddSingleton<PlatzyViewModel>();
            builder.Services.AddSingleton<NewPage1>(x => new NewPage1()
            {
                BindingContext = x.GetRequiredService<PlatzyViewModel>()
            });
            builder.Services.AddSingleton<EditarView>(sr => new EditarView()
            {
                BindingContext = sr.GetRequiredService<PlatzyViewModel>()
            });
            return builder.Build();
        }
    }
}
