# Sesión 01: ASP.NET y C#

## Fecha: 12/05/2025

## Objetivos de la Sesión

- Introducción a ASP.NET y C#

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción a .NET 8 y Visual Studio Code
   - Fundamentos de sintaxis y tipos de datos
   - Operadores y entradas/salidas básicas
   - Estructuras de control - Condicionales
   - Estructuras de control - Bucles

## Ejercicios Realizados

### Ejercicio 01: Hello World y Dictionary con C#

```c#
// program.cs
using System;
using System.Collections.Generic; //agregar esta linea para que se reconozca Dictionary<...>

class Program
{

    private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        {"admin", "qwerty"},
        {"user", "pass"},
        {"liz", "1234"}
    };
    static void Main(string[] args)
    {
        // Mensaje de bienvenida
        Console.WriteLine("Este es el programa oficial de Hola Mendo");
        Console.WriteLine("Tienes que iniciar sesión");

        Console.WriteLine("Escribe tu usuario");
        string? usuarioIngresado = Console.ReadLine();
        Console.WriteLine("Escribe tu contraseña");
        string? passIngresada = Console.ReadLine();

        if (usuarioIngresado != null)
        {
            if(usuarios.ContainsKey(usuarioIngresado) &&
            usuarios[usuarioIngresado] == passIngresada)
            {
                Console.WriteLine("Has ingresado con éxito");
                for (int i = 1; i <= 50; i++)
                {
                    Console.WriteLine($"{i}. Hola Usuario, gracias!!");
                }
                Console.WriteLine("\n Presiona Enter para salir del programa...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Contraseña y/o usuario incorrectos");
                Console.WriteLine("\n Presiona Enter para salir del programa...");
                Console.ReadLine();
            }
        }
    }
}
```

## Desafíos Encontrados

- **Impedimentos:** Para esta actividad tuve un problema con la versión de dotnet que tengo instalada, por lo que tuve que agregar la linea "using System.Collections.Generic;" para que fuera reconocido el Dictionary.   

## Recursos Adicionales

- .NET 8: Arquitectura, Seguridad, Monitoreo y Doc. de APIs
- C# TOTAL . Programador Experto en 28 días
- Master en ASP.NET MVC - Entity Framework (.NET 9)
- Curso de C#
- Aprende a programar desde cero con C#, Microsoft .NET y WPF
- Domina la programación C# con Visual Studio Code DESDE CERO
- Programación en C de Cero a Experto con Estructuras de Datos
- Master en C# de Cero (Windows Form - Xamarin -APP Consola)

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre C#.

---

*Entregable correspondiente a la Semana 9 del Módulo 3: ASP.NET y C#*