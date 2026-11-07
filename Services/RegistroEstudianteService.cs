using RegistroEstudiantesApp.Models;

namespace RegistroEstudiantesApp.Services;

public sealed class RegistroEstudianteService : IRegistroEstudianteService
{
    private readonly List<Estudiante> estudiantes = [];

    public void Agregar(Estudiante estudiante)
    {
        estudiantes.Add(estudiante);
    }
}
