# Sesión 02: ASP.NET y C#

## Fecha: 13/05/2025

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

### Ejercicio 03: Login

```c#
// program.cs
using System;
using System.ComponentModel;
using System.Text;

class Program
{

    private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        {"admin", "qwerty"},
        {"user", "pass"},
        {"liz", "1234"}
    };

    private const int MAX_ATTEMPS = 3;
    static void Main(string[] args)
    {
        // Mensaje de bienvenida
        Console.WriteLine("Este es el programa oficial de Hola Mendo");
        Console.WriteLine("Tienes que iniciar sesión");

        Console.WriteLine("Escribe tu usuario");
        string? usuarioIngresado = TryLogin();

        if(usuarioIngresado != null)
        {
            Console.WriteLine($"Hola {usuarioIngresado}");
        }
        else
        {
            Console.WriteLine("Has accedido el número máximo de intentos.");
        }
        Console.WriteLine("Presiona Enter para salir.");
        Console.ReadLine();

    }

    private static string? TryLogin()
    {
        int intentosRestantes = MAX_ATTEMPS;
        while(intentosRestantes > 0)
        {
            Console.WriteLine($"\nIntentos restantes: {intentosRestantes}");
            Console.Write("Ingresa tu nombre de usuario: ");
            string? userLogged = Console.ReadLine();
            Console.WriteLine("Escribe tu contraseña");
            string? passIngresada = ReadPassword();

            if (string.IsNullOrWhiteSpace(userLogged) || string.IsNullOrWhiteSpace(passIngresada))
            {
                Console.WriteLine("\nError: El usuario y contraseña no pueden estar vacíos.");
                intentosRestantes--;
                continue;
            }
            if(usuarios.ContainsKey(userLogged) &&
            usuarios[userLogged] == passIngresada)
            {
                Console.WriteLine("\nAcceso concedido!!");
                return userLogged;
            }
            else
            {
                Console.WriteLine("Contraseña y/o usuario incorrectos");
                Console.WriteLine("\n Intentalo de nuevo...");
                intentosRestantes--;
            }
        }
        return null;
    }

    private static string? ReadPassword()
    {
        StringBuilder password = new StringBuilder();
        ConsoleKeyInfo keyInfo;

        do{
            keyInfo = Console.ReadKey(true);

            if(!char.IsControl(keyInfo.KeyChar))
            {
                password.Append(keyInfo.KeyChar);
                Console.Write("*");
            }
            else if(keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password.Remove(password.Length - 1, 1);
                Console.Write("\b \b");
            }

        }
        while(keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password.ToString();

    }
}
```

## Desafíos Encontrados

- **Impedimentos:** Para esta actividad tuve un problema con la versión de dotnet que tengo instalada, por lo que tuve que corregir una linea de codigo en el archivo HelloWorld.csproj  

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