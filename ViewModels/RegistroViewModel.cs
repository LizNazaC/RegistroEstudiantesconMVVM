using System.Collections.ObjectModel;
using System.Net.Mail;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistroEstudiantesApp.Models;
using RegistroEstudiantesApp.Services;

namespace RegistroEstudiantesApp.ViewModels;

public partial class RegistroViewModel : ObservableObject
{
    private readonly IRegistroEstudianteService registroService;

    public RegistroViewModel(IRegistroEstudianteService registroService)
    {
        this.registroService = registroService;
        Fecha = DateTime.Today;
    }

    public ObservableCollection<Estudiante> Estudiantes { get; } = [];

    public IReadOnlyList<string> Carreras { get; } =
    [
        "Administración de Empresas",
        "Ingeniería Informática",
        "Medicina",
        "Psicología",
        "Diseño Gráfico"
    ];

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NombreError))]
    private string nombre = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CorreoError))]
    private string correo = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TelefonoError))]
    private string telefono = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CarreraError))]
    private string? carrera;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FechaError))]
    private DateTime fecha;

    public string NombreError => string.IsNullOrWhiteSpace(Nombre) ? "Indica el nombre completo." : string.Empty;

    public string CorreoError => EsCorreoValido(Correo) ? string.Empty : "Introduce un correo electrónico válido.";

    public string TelefonoError => EsTelefonoValido(Telefono) ? string.Empty : "Introduce un teléfono válido (solo números).";

    public string CarreraError => string.IsNullOrWhiteSpace(Carrera) ? "Selecciona una carrera." : string.Empty;

    public string FechaError => Fecha > DateTime.Today ? "La fecha no puede ser futura." : string.Empty;

    partial void OnNombreChanged(string value) => ActualizarEstadoGuardado();

    partial void OnCorreoChanged(string value) => ActualizarEstadoGuardado();

    partial void OnTelefonoChanged(string value) => ActualizarEstadoGuardado();

    partial void OnCarreraChanged(string? value) => ActualizarEstadoGuardado();

    partial void OnFechaChanged(DateTime value) => ActualizarEstadoGuardado();

    [RelayCommand(CanExecute = nameof(PuedeGuardar))]
    private void Guardar()
    {
        var estudiante = new Estudiante
        {
            Nombre = Nombre.Trim(),
            Correo = Correo.Trim(),
            Telefono = Telefono.Trim(),
            Carrera = Carrera!.Trim(),
            Fecha = Fecha
        };

        registroService.Agregar(estudiante);
        Estudiantes.Add(estudiante);
        Limpiar();
    }

    [RelayCommand]
    private void Limpiar()
    {
        Nombre = string.Empty;
        Correo = string.Empty;
        Telefono = string.Empty;
        Carrera = null;
        Fecha = DateTime.Today;
        ActualizarEstadoGuardado();
    }

    private bool PuedeGuardar() =>
        !string.IsNullOrWhiteSpace(Nombre) &&
        EsCorreoValido(Correo) &&
        EsTelefonoValido(Telefono) &&
        !string.IsNullOrWhiteSpace(Carrera) &&
        Fecha <= DateTime.Today;

    private void ActualizarEstadoGuardado()
    {
        OnPropertyChanged(nameof(NombreError));
        OnPropertyChanged(nameof(CorreoError));
        OnPropertyChanged(nameof(TelefonoError));
        OnPropertyChanged(nameof(CarreraError));
        OnPropertyChanged(nameof(FechaError));
        GuardarCommand.NotifyCanExecuteChanged();
    }

    private static bool EsTelefonoValido(string? valor)
    {
        var telefono = valor?.Trim() ?? string.Empty;
        return telefono.Length >= 7 && telefono.All(char.IsDigit);
    }

    private static bool EsCorreoValido(string? valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            return false;
        }

        try
        {
            var correo = valor.Trim();
            var direccion = new MailAddress(correo);
            return direccion.Address.Equals(correo, StringComparison.OrdinalIgnoreCase);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
