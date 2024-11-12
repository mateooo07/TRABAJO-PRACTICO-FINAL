﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TRABAJO_PRACTICO_FINAL;

class Program
{
    public static bool vueloCreado = false;
    public static List<Vuelo> listaDeVuelos = new List<Vuelo>();
    public static int indiceLista;
    static void Main()
    {
        DatosAerolinea();
        Inicio();
        Menú();
    }
    static void Inicio() // Función correspondiente a la pantalla de bienvenida.
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("| ¡Bienvenido a Aerolíneas Argentinas! |");
        Console.WriteLine("----------------------------------------");
        Bandera();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ResetColor();
        Console.ReadKey();
    }

    static void Bandera()
    {
        ConsoleColor colorCeleste = ConsoleColor.Cyan;
        ConsoleColor colorBlanco = ConsoleColor.White;
        int ancho = 40;
        int alto = 9;

        for (int i = 0; i < alto; i++)
        {

            if (i < 3)
            {
                Console.BackgroundColor = colorCeleste;
            }
            else if (i >= 3 && i < 6)
            {
                Console.BackgroundColor = colorBlanco;
            }
            else
            {
                Console.BackgroundColor = colorCeleste;
            }


            Console.WriteLine(new string(' ', ancho));
        }
        Console.ResetColor();
    }
    static void Menú() //Función correspondiente al menu principal del programa.
    {
        ConsoleKeyInfo Flecha;
        Console.CursorVisible = false;

        int opcion = 0;
        do
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("----------");
            Console.WriteLine("|| MENÚ ||");
            Console.WriteLine("----------\n");
            Console.ResetColor();


            for (int i = 0; i <= 7; i++)
            {
                if (opcion == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(MenuNumeros(i));
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(MenuNumeros(i));
                    Console.ResetColor();
                }
            }


            Flecha = Console.ReadKey(true);
            if (Flecha.Key == ConsoleKey.UpArrow && opcion > 0)
                opcion--;
            if (Flecha.Key == ConsoleKey.DownArrow && opcion < 6)
                opcion++;


        } while (Flecha.Key != ConsoleKey.Enter);

        switch (opcion)
        {
            case 0:
                Console.Clear();
                CreaciónVuelo(listaDeVuelos, ref vueloCreado);
                EsperarYVolverAlMenu();
                break;
            case 1:
                Console.Clear();
                Vuelo.RegistrarPasajeros(listaDeVuelos);
                EsperarYVolverAlMenu();
                break;
            case 2:
                Console.Clear();
                Vuelo.CalcularOcupacionMedia(listaDeVuelos);
                EsperarYVolverAlMenu();
                break;
            case 3:
                Console.Clear();
                Vuelo.VueloConMayorOcupacion(listaDeVuelos);
                Thread.Sleep(1500);
                EsperarYVolverAlMenu();
                break;
            case 4:
                Console.Clear();
                if (vueloCreado)
                {
                    MostrarEstadoVuelo(vueloCreado, listaDeVuelos, indiceLista);
                }
                else
                {
                    Console.WriteLine("El vuelo no ha sido creado. No se puede mostrar el estado del vuelo.");
                }
                EsperarYVolverAlMenu();
                break;
            case 5:
                Console.Clear();

                EsperarYVolverAlMenu();
                break;
            case 6:
                Console.Clear();

                EsperarYVolverAlMenu();
                break;
            case 7:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saliendo del sistema...");
                Thread.Sleep(1500);
                Console.ResetColor();
                break;
        }
    }

    static string MenuNumeros(int indice) // Devuelve el texto de las opciones del menú según el índice.
    {
        switch (indice)
        {
            case 0:
                return "------------------------------------------------------------------\n" +
                      " > Agregar Vuelo.                                                |" +
                      "\n -----------------------------------------------------------------";
            case 1:
                return "------------------------------------------------------------------\n" +
                    " > Registrar pasajeros en un vuelo.                              |" +
                    "\n -----------------------------------------------------------------";
            case 2:
                return "------------------------------------------------------------------\n" +
                    " > Calcular ocupación media de la flota.                         |" +
                    "\n -----------------------------------------------------------------";
            case 3:
                return "------------------------------------------------------------------\n" +
                    " > Vuelo con mayor ocupación                                     |" +
                    "\n -----------------------------------------------------------------";
            case 4:
                return "------------------------------------------------------------------\n" +
                    " > Buscar vuelo por código.                                      |" +
                    "\n -----------------------------------------------------------------";
            case 5:
                return "------------------------------------------------------------------\n" +
                    " > Lista de vuelos                                               |" +
                    "\n -----------------------------------------------------------------";
            case 6:
                return "------------------------------------------------------------------\n" +
                    " > Salir del sistema.                                            |" +
                    "\n -----------------------------------------------------------------";
            default:
                return "";
        }
    }
    static void EsperarYVolverAlMenu() // Espera que el usuario presione 'M' para volver al menú.
    {
        ConsoleKeyInfo volverMenu;
        bool volverValido = false;
        while (volverValido != true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nPresiona 'M' para volver al menú.");

            volverMenu = Console.ReadKey(true);
            Console.ResetColor();

            if (volverMenu.Key == ConsoleKey.M)
            {
                volverValido = true;
            }
        }
        Menú(); // Volver al menú principal
    }
    public static void DatosAerolinea()
    {
        string razonSocial = "Aerolíneas Argentinas S.A";
        string telefono = "011 5199-3555";
        string domicilio = "Aeroparque Jorge Newbery, CABA, Argentina";
    }
    static void CreaciónVuelo(List<Vuelo> listaDeVuelos, ref bool vueloCreado)
    {
        string clasificacion;
        string codigoVuelo = "";
        bool numeroNombrePiloto = false;
        bool numeroNombreCopiloto = false;
        int contador = 0;
        bool capacidadMaximaValida = false;
        string fechaUsuario;
        int fechaSalidaLenght;
        DateTime fechaSalidayHora;
        DateTime fechaLlegadayHora;
        Console.Clear();

        Console.Write("Escriba la clasifición del vuelo (Internacional / Nacional): ");
        clasificacion = Console.ReadLine();
        clasificacion = clasificacion.ToLower();
        if (clasificacion != "internacional" && clasificacion != "nacional")
        {
            Console.Clear();
            Console.Write("Escriba de nuevo la clasificación del vuelo.");
            return;
        }
        else if (clasificacion == "internacional")
        {
            Console.WriteLine("\nAl tratarse de un vuelo internacional el código de vuelo sera un número igual o superior a 400, junto a un 'AA' ya impuesto por el programa.");
            Console.Write("Escriba el código de vuelo: ");
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int codigo))
            {
                if (codigo < 400)
                {
                    Console.Clear();
                    Console.Write("Debe escribir un número igual o superior a 400.");
                    return;
                }

            }
            else
            {
                Console.Clear();
                Console.Write("Debe escribir un número.");
                return;
            }
            codigoVuelo = "AA" + codigo.ToString();
        }
        else if (clasificacion == "nacional")
        {
            Console.WriteLine("\nAl tratarse de un vuelo nacional el código de vuelo sera un número igual o superior a 100 y menor a 400, junto a un 'AA' ya impuesto por el programa.");
            Console.Write("Escriba el código de vuelo: ");
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int codigo))
            {
                if (codigo < 100 || codigo >= 400)
                {
                    Console.Clear();
                    Console.Write("Debe escribir un número igual o superior a 100 y menor a 400.");
                    return;
                }
            }
            else
            {
                Console.Clear();
                Console.Write("Debe escribir un número.");
                return;
            }

            codigoVuelo = "AA" + codigo.ToString();
        }
        while (true)
        {
            Console.Write("\nIngresa la fecha de salida (forma preferida: dd/mm/yyyy HH:mm):");
            fechaUsuario = Console.ReadLine();
            fechaSalidaLenght = fechaUsuario.Length;
            if (DateTime.TryParse(fechaUsuario, out fechaSalidayHora) && fechaUsuario.Length >= 16)
            {
                if (fechaSalidayHora < DateTime.Now)
                {
                    Console.Clear();
                    Console.WriteLine("Escriba una fecha posterior o igual a la actual.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Escriba un formato de fecha válido.");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }
        while (true)
        {
            Console.Write("\nIngrese la fecha de llegada (forma preferida: dd/mm/yyyy HH:mm): ");
            fechaUsuario = Console.ReadLine();
            int fechaLlegadaLenght = fechaUsuario.Length;
            if (DateTime.TryParse(fechaUsuario, out fechaLlegadayHora) && fechaSalidaLenght >= 16)
            {
                if (fechaLlegadayHora <= fechaSalidayHora)
                {
                    Console.Clear();
                    Console.WriteLine("Escriba una fecha posterior a la fecha de salida.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Escriba un formato de fecha valido.");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }

        Console.Write("\nEscriba el nombre y apellido del piloto: ");
        string nombrePiloto = Console.ReadLine();
        foreach (char caracter in nombrePiloto)
        {
            if (Char.IsDigit(caracter))
            {
                Console.Clear();
                Console.WriteLine("Escriba un nombre válido.");
                return;
            }
        }

        Console.Write("\nEscriba el nombre y apellido del copiloto: ");
        string nombreCopiloto = Console.ReadLine();
        foreach (char caracter in nombreCopiloto)
        {
            if (Char.IsDigit(caracter))
            {
                Console.Clear();
                Console.WriteLine("Escriba un nombre válido.");
                return;
            }
        }
        Console.WriteLine("\nDetermine la capacidad máxima del vuelo, lo mínimo son 60 asientos, y lo máximo 200 asientos.");
        Console.WriteLine("Tenga en cuenta que deberá saltar de 10 en 10 en tamaño (60 - 70 - 80 - etc).");
        Console.Write("\nEscriba la capacidad: ");
        string entrada1 = Console.ReadLine();

        // Verificar si la entrada es un número válido
        if (int.TryParse(entrada1, out int capacidadMaxima))
        {
            // Verificar si el número está entre 60 y 200 y es múltiplo de 10
            if (capacidadMaxima >= 60 && capacidadMaxima <= 200 && capacidadMaxima % 10 == 0)
            {
                Console.WriteLine("\nVuelo Creado.");
                vueloCreado = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Escriba una capacidad máxima válida (entre 60 y 200, múltiplo de 10).");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Escriba un número");
            return;
        }

        int filas = capacidadMaxima / 10;
        int[][] asientos = new int[filas][];
        for (int i = 0; i < filas; i++)
        {
            asientos[i] = new int[10];
        }

        Vuelo vuelo = new Vuelo(clasificacion, codigoVuelo, fechaSalidayHora, fechaLlegadayHora, nombrePiloto, nombreCopiloto, capacidadMaxima, asientos);

        listaDeVuelos.Add(vuelo);

    }

    static void MostrarEstadoVuelo(bool vueloCreado, List<Vuelo> listaDeVuelos, int indiceLista)
    {
        int indiceTabla = Vuelo.BuscarVueloPorCodigo(listaDeVuelos);
        Console.ForegroundColor = ConsoleColor.Blue;
        if (vueloCreado)
        {
            if (indiceTabla == -1)
            {
                return;
            }
            else
            {
                int[][] asientos = listaDeVuelos[indiceTabla].asientos;
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("|                                                                    ESTADO DEL VUELO                                                                                      |");
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("|----ASIENTO1----|----ASIENTO2----|----ASIENTO3----|----ASIENTO4----|----ASIENTO5----|----ASIENTO6----|----ASIENTO7----|----ASIENTO8----|----ASIENTO9----|----ASIENTO10----|");
                Console.ResetColor();
                for (int i = 0; i < asientos.Length; i++)
                {

                    for (int j = 0; j < asientos[i].Length; j++)
                    {
                        string fila = (i + 1).ToString("D2");
                        string asiento = (j + 1).ToString();
                        if (asientos[i][j] == 1)
                        {
                            if (asiento == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"F{fila}A{asiento}:RESERVADO".PadRight(16)); // Alinear
                                Console.ResetColor();

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                if (j == 9)
                                {
                                    Console.Write($"F{fila}A{asiento}:RESERVADO".PadRight(17)); // Alinear
                                }
                                else
                                {
                                    Console.Write($"F{fila}A{asiento}:RESERVADO".PadRight(16));
                                }
                                Console.ResetColor();
                            }


                        }
                        else
                        {

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (j == 9)
                            {
                                Console.Write($"F{fila}A{asiento}:LIBRE".PadRight(17));
                            }
                            else
                            {
                                Console.Write($"F{fila}A{asiento}:LIBRE".PadRight(16));
                            }
                            Console.ResetColor();


                        }
                    }

                    // Separador de final de fila
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("|");
                    Console.ResetColor();
                }

                // Línea final de la tabla
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|----------------|----------------|----------------|----------------|----------------|----------------|----------------|----------------|----------------|-----------------|");
                Console.ResetColor();
            }
        }

    }




}