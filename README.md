# RegistroEstudiantesApp

Aplicación desarrollada con **.NET MAUI** para registrar estudiantes y visualizarlos en una lista, aplicando el patrón de arquitectura **MVVM** (Model-View-ViewModel).

## Funcionalidades

- Formulario para registrar un estudiante.
- Lista de estudiantes registrados.
- Separación de responsabilidades mediante MVVM y una capa de servicios.

## Tecnologías

- .NET MAUI
- C# / XAML
- Patrón MVVM

## Estructura del proyecto

```
RegistroEstudiantesApp/
├── Models/
│   └── Estudiante.cs
├── Services/
│   ├── IRegistroEstudianteService.cs
│   └── RegistroEstudianteService.cs
├── ViewModels/
│   └── RegistroViewModel.cs
├── Views/
│   └── RegistroPage.xaml
├── App.xaml
├── AppShell.xaml
├── MainPage.xaml
└── MauiProgram.cs
```

## Arquitectura (MVVM)

```mermaid
flowchart LR
    subgraph View
        A[RegistroPage.xaml<br/>Formulario y Lista]
    end
    subgraph ViewModel
        B[RegistroViewModel]
    end
    subgraph Services
        C[IRegistroEstudianteService]
        D[RegistroEstudianteService]
    end
    subgraph Model
        E[Estudiante]
    end

    A -->|Binding y Commands| B
    B -->|notifica cambios| A
    B -->|usa| C
    D -.->|implementa| C
    D -->|maneja| E
    B -->|expone| E
```

### Descripción de las capas

| Capa | Archivo | Responsabilidad |
|------|---------|-----------------|
| **Model** | `Estudiante.cs` | Representa los datos de un estudiante. |
| **View** | `RegistroPage.xaml` | Interfaz con el formulario y la lista. No contiene lógica de negocio. |
| **ViewModel** | `RegistroViewModel.cs` | Expone propiedades y comandos a la vista mediante data binding. |
| **Services** | `IRegistroEstudianteService.cs`, `RegistroEstudianteService.cs` | Lógica de registro y consulta de estudiantes, desacoplada mediante una interfaz. |

## Capturas de pantalla
<img width="1440" height="737" alt="image" src="https://github.com/user-attachments/assets/e0d4fa93-28c3-43a9-9529-06703ceeff9b" />

