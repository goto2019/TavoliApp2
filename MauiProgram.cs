using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using TavoliApp.AppViews;
using TavoliApp.ViewModels;
using TavoliApp.Views; // <- NECESSARIO
using TavoliApp.ApiClients;

namespace TavoliApp
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
                });

            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<ElencoTavoliPage>(); // CORRETTO NAMESPACE
            builder.Services.AddSingleton<ElencoTavoliViewModel>();
            builder.Services.AddSingleton<TavoloPageViewModel>();
            builder.Services.AddTransient<TavoloPage>();

            return builder.Build();
        }
    }
}
