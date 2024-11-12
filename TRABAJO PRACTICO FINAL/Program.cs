using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using TRABAJO_PRACTICO_FINAL;
using System.Text.Json;
using System.Xml.Serialization;

class Program
{

    public static bool vueloCreado = false;
    public static List<Vuelo> listaDeVuelos = new List<Vuelo>();
    public static int indiceLista;
    public static Aerolínea aerolinea;
    public static string filePath = "aerolinea.xml";
    static void Main()
    {
        DatosAerolinea();
        Inicio();
        Console.WindowHeight = 45;
        Console.WindowWidth = 180;
        Menú(aerolinea);
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
    static void Menú(Aerolínea aerolinea) //Función correspondiente al menu principal del programa.
    {
        ConsoleKeyInfo Flecha;
        Console.CursorVisible = false;

        int opcion = 0;
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.WriteLine("----------");
            Console.WriteLine("|| MENÚ ||");
            Console.WriteLine("----------\n");
            Console.ResetColor();


            for (int i = 0; i <= 8; i++)
            {
                if (opcion == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(MenuNumeros(i));
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
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
                CreaciónVuelo(listaDeVuelos, ref vueloCreado);
                EsperarYVolverAlMenu();
                break;
            case 1:
                Console.Clear();
                if (vueloCreado)
                {
                    Vuelo.RegistrarPasajeros(listaDeVuelos, aerolinea);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se ha creado ningún vuelo. No se puede mostrar el vuelo con mayor ocupación");
                }
                EsperarYVolverAlMenu();
                break;
            case 2:
                Console.Clear();
                if (vueloCreado)
                {
                    Vuelo.CalcularOcupacionMedia(listaDeVuelos);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se ha creado ningún vuelo. No se puede mostrar el vuelo con mayor ocupación");
                }
                EsperarYVolverAlMenu();
                break;
            case 3:
                Console.Clear();
                if (vueloCreado)
                {
                    Vuelo.VueloConMayorOcupacion(listaDeVuelos);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se ha creado ningún vuelo. No se puede mostrar el vuelo con mayor ocupación");
                }
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se ha creado ningún vuelo. No se puede mostrar el estado del vuelo.");
                }
                EsperarYVolverAlMenu();
                break;
            case 5:
                Console.Clear();
                if (vueloCreado)
                {
                    Vuelo.ListaVuelos(listaDeVuelos);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se ha creado ningún vuelo. No se puede mostrar el estado del vuelo.");
                }
                EsperarYVolverAlMenu();
                break;
            case 6:
                Console.Clear();
                GuardarEnXML(aerolinea, "aerolinea.xml");
                EsperarYVolverAlMenu();
                break;
            case 7:
                Console.Clear();
                CargarDesdeXML("aerolinea.xml");
                if(listaDeVuelos.Count > 0)
                {
                    vueloCreado = true;
                }
                EsperarYVolverAlMenu();
                break;
            case 8:
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
                    " > Guardar datos                                                 |" +
                    "\n -----------------------------------------------------------------";
            case 7: 
                return "------------------------------------------------------------------\n" +
                    " > Cargar datos                                                  |" +
                    "\n -----------------------------------------------------------------";
            case 8:
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
            Console.WriteLine("Presiona 'M' para volver al menú.");

            volverMenu = Console.ReadKey(true);
            Console.ResetColor();

            if (volverMenu.Key == ConsoleKey.M)
            {
                volverValido = true;
            }
        }
        Menú(aerolinea); // Volver al menú principal
    }
    public static void DatosAerolinea()
    {
        string razonSocial = "Aerolíneas Argentinas S.A";
        string telefono = "011 5199-3555";
        string domicilio = "Aeroparque Jorge Newbery, CABA, Argentina";
        aerolinea = new Aerolínea(razonSocial, telefono, domicilio, listaDeVuelos);
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
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Escriba la clasifición del vuelo (Internacional / Nacional): ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        clasificacion = Console.ReadLine();
        clasificacion = clasificacion.ToLower();
        if (clasificacion != "internacional" && clasificacion != "nacional")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Escriba de nuevo la clasificación del vuelo.\n");
            return;
        }
        else if (clasificacion == "internacional")
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nAl tratarse de un vuelo internacional el código de vuelo sera un número igual o superior a 400, junto a un 'AA' ya impuesto por el programa.");
            Console.Write("Escriba el código de vuelo: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int codigo))
            {
                if (codigo < 400)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Debe escribir un número igual o superior a 400.\n");
                    return;
                }

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Debe escribir un número.");
                return;
            }
            codigoVuelo = "AA" + codigo.ToString();
        }
        else if (clasificacion == "nacional")
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nAl tratarse de un vuelo nacional el código de vuelo sera un número igual o superior a 100 y menor a 400, junto a un 'AA' ya impuesto por el programa.");
            Console.Write("Escriba el código de vuelo: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int codigo))
            {
                if (codigo < 100 || codigo >= 400)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Debe escribir un número igual o superior a 100 y menor a 400.\n");
                    return;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Debe escribir un número.\n");
                return;
            }

            codigoVuelo = "AA" + codigo.ToString();
        }
        for (int i = 0; i < listaDeVuelos.Count; i++)
        {
            if(codigoVuelo == listaDeVuelos[i].codigoVuelo)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ya existe un vuelo con ese código de vuelo.\n");
                return;
            }
        }
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nIngresa la fecha de salida (forma preferida: dd/mm/yyyy HH:mm):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            fechaUsuario = Console.ReadLine();
            fechaSalidaLenght = fechaUsuario.Length;
            if (DateTime.TryParse(fechaUsuario, out fechaSalidayHora) && fechaUsuario.Length >= 16)
            {
                if (fechaSalidayHora < DateTime.Now)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escriba una fecha posterior o igual a la actual.\n");
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escriba un formato de fecha válido.\n");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nIngrese la fecha de llegada (forma preferida: dd/mm/yyyy HH:mm): ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            fechaUsuario = Console.ReadLine();
            int fechaLlegadaLenght = fechaUsuario.Length;
            if (DateTime.TryParse(fechaUsuario, out fechaLlegadayHora) && fechaSalidaLenght >= 16)
            {
                if (fechaLlegadayHora <= fechaSalidayHora)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escriba una fecha posterior a la fecha de salida.\n");
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escriba un formato de fecha valido.\n");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("\nEscriba el nombre y apellido del piloto: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string nombrePiloto = Console.ReadLine();
        foreach (char caracter in nombrePiloto)
        {
            if (Char.IsDigit(caracter))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escriba un nombre válido.\n");
                return;
            }
        }
        if(nombrePiloto == "" || nombrePiloto == " ")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Escriba un nombre válido.\n");
            return;
        }
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("\nEscriba el nombre y apellido del copiloto: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string nombreCopiloto = Console.ReadLine();
        foreach (char caracter in nombreCopiloto)
        {
            if (Char.IsDigit(caracter))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escriba un nombre válido.\n");
                return;
            }
        }
        if(nombreCopiloto == "" || nombreCopiloto == " ")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Escriba un nombre válido.\n");
            return;
        }
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nDetermine la capacidad máxima del vuelo, lo mínimo son 60 asientos, y lo máximo 200 asientos.");
        Console.WriteLine("Tenga en cuenta que deberá saltar de 10 en 10 en tamaño (60 - 70 - 80 - etc).");
        Console.Write("\nEscriba la capacidad: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string entrada1 = Console.ReadLine();

        // Verificar si la entrada es un número válido
        if (int.TryParse(entrada1, out int capacidadMaxima))
        {
            // Verificar si el número está entre 60 y 200 y es múltiplo de 10
            if (capacidadMaxima >= 60 && capacidadMaxima <= 200 && capacidadMaxima % 10 == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nVuelo Creado.");
                vueloCreado = true;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Escriba una capacidad máxima válida (entre 60 y 200, múltiplo de 10).\n");
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Escriba un número\n");
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
    public static void GuardarEnXML(Aerolínea aerolinea, string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("La ruta del archivo no puede ser nula o vacía.");
            return;
        }

        try
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            XmlSerializer serializer = new XmlSerializer(typeof(Aerolínea));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, aerolinea);
            }
            Console.WriteLine("Datos guardados exitosamente en formato XML.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al guardar los datos en XML: {ex.Message}");
        }
    }

    public static Aerolínea CargarDesdeXML(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("La ruta del archivo no puede ser nula o vacía.");
            return null;
        }

        try
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Aerolínea));
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    aerolinea = (Aerolínea)serializer.Deserialize(stream);
                    listaDeVuelos = aerolinea.listaDeVuelos ?? new List<Vuelo>();
                    Console.WriteLine("Datos cargados correctamente desde el archivo XML.");
                    return aerolinea;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El archivo XML no existe.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al cargar los datos desde XML: {ex.Message}");
            return null;
        }
    }
}
