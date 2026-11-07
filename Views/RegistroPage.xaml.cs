using RegistroEstudiantesApp.ViewModels;

namespace RegistroEstudiantesApp.Views;

public partial class RegistroPage : ContentPage
{
    public RegistroPage(RegistroViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
