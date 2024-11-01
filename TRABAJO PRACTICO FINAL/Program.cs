using System;
using System.Text.RegularExpressions;
using TRABAJO_PRACTICO_FINAL;

class Program
{
    static void Main()
    {
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
            if (Flecha.Key == ConsoleKey.DownArrow && opcion < 8)
                opcion++;


        } while (Flecha.Key != ConsoleKey.Enter);

        switch (opcion)
        {
            case 0:
                Console.Clear();
                EsperarYVolverAlMenu();
                break;
            case 1:
                Console.Clear();
                
                EsperarYVolverAlMenu();
                break;
            case 2:
                Console.Clear();
                
                EsperarYVolverAlMenu();
                break;
            case 3:
                Console.Clear();
               
                Thread.Sleep(1500);
                EsperarYVolverAlMenu();
                break;
            case 4:
                Console.Clear();
              
                EsperarYVolverAlMenu();
                break;
            case 5:
                
                EsperarYVolverAlMenu();
                break;
            case 6:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saliendo del sistema...");
                Thread.Sleep(1500);
                Console.ResetColor();
                break;
            case 7:
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
                    " > Ver tabla de asientos ocupados de un vuelo.                   |" +
                    "\n -----------------------------------------------------------------";
            case 7:
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
    static List<Vuelo> DatosAerolinea()
    {
        string razonSocial = "Aerolíneas Argentinas S.A";
        string telefono = "011 5199-3555";
        string domicilio = "Aeroparque Jorge Newbery, CABA, Argentina";
        List<Vuelo> listaDeVuelos = new List<Vuelo>();
        return listaDeVuelos;
    }
    static void CreaciónVuelo(List<Vuelo> listaDeVuelos)
    {
        string clasificacion;
        string codigoVuelo = "";
        bool numeroNombrePiloto = false;
        bool numeroNombreCopiloto = false;
        Console.Clear();
    
        Console.Write("Escriba la clasifición del vuelo (Internacional / Nacional): ");
        clasificacion = Console.ReadLine();
        clasificacion.ToLower();
        if (clasificacion != "internacional" || clasificacion != "nacional")
        {
            Console.Write("Escriba de nuevo la clasificación del vuelo.");
            return;
        }
        else if(clasificacion == "internacional")
        {
            Console.WriteLine("Al tratarse de un vuelo internacional el código de vuelo sera un número igual o superior a 400, junto a un AA ya impuesto por el programa.");
            Console.Write("Escriba el código de vuelo: ");
            string entrada = Console.ReadLine();
            if(int.TryParse(entrada, out int codigo))
            {
                if(codigo<400)
                {
                    Console.Write("Debe escribir un número igual o superior a 400.");
                    return;
                }
                
            }
            else
            {
                Console.Write("Debe escribir un número.");
                return;
            }
            codigoVuelo = "AA" + codigo.ToString();
        }
        else if(clasificacion == "nacional")
        {
            Console.WriteLine("Al tratarse de un vuelo nacional el código de vuelo sera un número igual o superior a 100 y menor a 400, junto a un AA ya impuesto por el programa.");
            Console.Write("Escriba el código de vuelo: ");
            string entrada = Console.ReadLine();
            if(int.TryParse(entrada, out int codigo))
            {
                if (codigo < 100 || codigo >= 400)
                {
                    Console.Write("Debe escribir un número igual o superior a 100 y menor a 400.");
                    return;
                }
            }
            else
            {
                Console.Write("Debe escribir un número.");
                return;
            }

            codigoVuelo = "AA" + codigo.ToString();
        }

        Console.Write("Ingresa la fecha de salida (forma preferida: dd/mm/yyyy HH:mm):");
        string fechaUsuario = Console.ReadLine();
        if (DateTime.TryParse(fechaUsuario, out DateTime fechaSalidayHora))
        {
            if(fechaSalidayHora<DateTime.Now)
            {
                Console.WriteLine("Escriba una fecha posterior o igual a la actual.");
            }
        }
        else
        {
            Console.WriteLine("Escriba un formato de fecha válido.");
        }
        Console.Write("Ingrese la fecha de llegada (forma preferida: dd/mm/yyyy HH:mm): ");
        fechaUsuario = Console.ReadLine();
        if(DateTime.TryParse(fechaUsuario, out DateTime FechaLlegadayHora))
        {
            if(FechaLlegadayHora<= fechaSalidayHora)
            {
                Console.WriteLine("Escriba una fecha posterior a la fecha de salida.");
            }
        }
        else
        {
            Console.WriteLine("Escriba un formato de fecha valido.");
        }
        Console.Write("Escriba el nombre y apellido del piloto: ");
        string nombrePiloto = Console.ReadLine();
        foreach(char caracter in nombrePiloto)
        {
            if(Char.IsDigit(caracter))
            {
                Console.WriteLine("Escriba un nombre válido.");
                return;
            }
        }

        Console.Write("Escriba el nombre y apellido del copiloto: ");
        string nombreCopiloto = Console.ReadLine();
        foreach(char caracter in nombreCopiloto)
        {
            if(Char.IsDigit(caracter))
            {
                Console.WriteLine("Escriba un nombre válido.");
                return;
            }
        }
        Console.Write("Escriba la capacidad maxima del vuelo, lo minimo son 60 asientos: ");
        string entrada1 = Console.ReadLine();
        if (int.TryParse(entrada1, out int capacidadMaxima))
        {
            if(capacidadMaxima<60)
            {
                Console.WriteLine("Escriba una capacidad maxima válida.");
            }
        }
        else
        {
            Console.WriteLine("Escriba un número.");
        }

        
        int[] asientos = new int[capacidadMaxima];

        Vuelo vuelo = new Vuelo(clasificacion, codigoVuelo, fechaSalidayHora, FechaLlegadayHora, nombrePiloto, nombreCopiloto, capacidadMaxima, asientos);

        listaDeVuelos.Add(vuelo);
     

    }

    static void MostrarEstadoVuelo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        if (vueloCreado)
        {
            Console.WriteLine("|-----------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|                                           ESTADO DEL VUELO                                          |");
            Console.WriteLine("|-----------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|----ASIENTO1----|----ASIENTO2----|----ASIENTO3----|----ASIENTO4----|----ASIENTO5----|----ASIENTO6----|");
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
                            Console.Write($"F{fila}A{asiento}:RESERVADO".PadRight(16)); // Alinear
                            Console.ResetColor();
                        }


                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"F{fila}A{asiento}:LIBRE".PadRight(16)); // Alinear
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
            Console.WriteLine("|----------------|----------------|----------------|----------------|----------------|----------------|");
            Console.ResetColor();
        }





    }