using System;
using System.Collections.Generic; //agregar esta linea para que se reconozca

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

