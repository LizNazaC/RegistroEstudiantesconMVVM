using RegistroEstudiantesApp.Views;

namespace RegistroEstudiantesApp
{
    public partial class AppShell : Shell
    {
        public AppShell(RegistroPage registroPage)
        {
            InitializeComponent();
            Items.Add(new ShellContent
            {
                Title = "Registro",
                Route = "RegistroPage",
                Content = registroPage
            });
        }
    }
}
