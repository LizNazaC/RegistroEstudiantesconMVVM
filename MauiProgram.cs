using Microsoft.Extensions.Logging;
using RegistroEstudiantesApp.Services;
using RegistroEstudiantesApp.ViewModels;
using RegistroEstudiantesApp.Views;

namespace RegistroEstudiantesApp
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

            builder.Services.AddSingleton<IRegistroEstudianteService, RegistroEstudianteService>();
            builder.Services.AddTransient<RegistroViewModel>();
            builder.Services.AddTransient<RegistroPage>();
            builder.Services.AddTransient<AppShell>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
