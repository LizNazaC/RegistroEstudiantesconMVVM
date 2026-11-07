using Microsoft.Extensions.DependencyInjection;

namespace RegistroEstudiantesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var appShell = Current?.Handler?.MauiContext?.Services.GetRequiredService<AppShell>()
                ?? throw new InvalidOperationException("No se pudo resolver AppShell desde DI.");

            return new Window(appShell);
        }
    }
}