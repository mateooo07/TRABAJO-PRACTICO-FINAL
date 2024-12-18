﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TRABAJO_PRACTICO_FINAL
{
    [Serializable]
    public class Vuelo // Cambiado de internal a public
    {
        public string clasificación { get; set; }
        public string codigoVuelo { get; set; }
        public DateTime fechaSalida { get; set; }
        public DateTime fechaLlegada { get; set; }
        public string nombrePiloto { get; set; }
        public string nombreCopiloto { get; set; }
        public int capacidadMaxima { get; set; }
        public int capacidadDisponible { get; set; }
        public int[][] asientos { get; set; }

        public Vuelo()
        {
            
        }
        public Vuelo(string clasificación, string codigoVuelo, DateTime fechaSalida, DateTime fechaLlegada,
                     string nombrePiloto, string nombreCopiloto, int capacidadMaxima, int[][] asientos)
        {
            this.clasificación = clasificación;
            this.codigoVuelo = codigoVuelo;
            this.fechaSalida = fechaSalida;
            this.fechaLlegada = fechaLlegada;
            this.nombrePiloto = nombrePiloto;
            this.nombreCopiloto = nombreCopiloto;
            this.capacidadMaxima = capacidadMaxima;
            this.capacidadDisponible = capacidadMaxima;
            this.asientos = asientos;
        }



        public static void RegistrarPasajeros(List<Vuelo> listaDeVuelos, Aerolínea aerolinea)
        {
            Console.Clear();
            int contador = 0;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Escriba el código del vuelo al cual quiere registrarle cierta cantidad de pasajeros: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string codigoVuelo = Console.ReadLine();
            for (int i = 0; i < listaDeVuelos.Count; i++)
            {
                if (codigoVuelo == listaDeVuelos[i].codigoVuelo)
                {
                    if (listaDeVuelos[i].fechaLlegada < DateTime.Now)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("No puede registrarle ningun pasajero a este vuelo, porque ya despegó.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("Escriba la cantidad de pasajeros que quiera registrar en el vuelo: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string entrada = Console.ReadLine();
                        if (int.TryParse(entrada, out int cantidadPasajeros))
                        {
                            if (cantidadPasajeros > listaDeVuelos[i].capacidadMaxima)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("La cantidad de pasajeros a registrar excede la capacidad maxima del vuelo.");
                                return;
                            }
                            else if (cantidadPasajeros > listaDeVuelos[i].capacidadDisponible)

                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("La cantidad de pasajeros a registrar excede la cantidad disponible.");
                                return;
                            }
                            else
                            {
                                listaDeVuelos[i].capacidadDisponible -= cantidadPasajeros;
                                int cantidadDeFilas = listaDeVuelos[i].capacidadMaxima / 10;
                                while (contador != cantidadPasajeros)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write("Escriba la fila del asiento: ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    entrada = Console.ReadLine();
                                    if (int.TryParse(entrada, out int fila))
                                    {
                                        fila--;
                                        if (fila < 0 || fila > cantidadDeFilas)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Clear();
                                            Console.WriteLine($"Escriba un número de fila valido. El número de filas del vuelo con el código {codigoVuelo} es de: {cantidadDeFilas} filas.\n");
                                            Thread.Sleep(1500);
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            Console.Write("Escriba el número de asiento: ");
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            entrada = Console.ReadLine();
                                            if (int.TryParse(entrada, out int asiento))
                                            {
                                                asiento--;
                                                if (asiento < 0 || asiento > 10)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.Clear();
                                                    Console.WriteLine($"Escriba un número de asiento valido. El numero de asientos del vuelo con el código {codigoVuelo} es de: 10 asientos.\n");
                                                    Thread.Sleep(1500);
                                                    Console.Clear();
                                                }
                                                else
                                                {
                                                    if (listaDeVuelos[i].asientos[fila][asiento] == 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Clear();
                                                        Console.WriteLine("El asiento que seleccionó ya esta ocupado.\n");
                                                        Thread.Sleep(1500);
                                                        Console.Clear();
                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine("\nAsiento registrado.\n");
                                                        contador++;
                                                        listaDeVuelos[i].asientos[fila][asiento] = 1;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Escriba un número.\n");
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Clear();
                                        Console.WriteLine("Escriba un número.\n");
                                        Thread.Sleep(1500);
                                        Console.Clear();
                                    }
                                }
                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{cantidadPasajeros} Pasajeros registrados.");
                            listaDeVuelos[i].capacidadDisponible = listaDeVuelos[i].capacidadMaxima - cantidadPasajeros;
                            return;
                        }
                    }
                    
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("El código proporcionado no coincide con el código de ningún vuelo.");
        }



        public static void CalcularOcupacionMedia(List<Vuelo> listaDeVuelos)
        {
            Console.Clear();
            int asientosTotalesDeFlota = 0;
            int asientosOcupadosDeFlota = 0;
            int asientosDisponiblesDeFlota = 0;
            for (int i = 0; i < listaDeVuelos.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                int asientosOcupados = listaDeVuelos[i].capacidadMaxima - listaDeVuelos[i].capacidadDisponible;

                double ocupacionVuelo = ((double)asientosOcupados * 100) / listaDeVuelos[i].capacidadMaxima;

                Console.WriteLine($"Porcentaje de ocupación del vuelo {listaDeVuelos[i].codigoVuelo}: {ocupacionVuelo}%.\n");

                asientosOcupadosDeFlota = asientosOcupadosDeFlota + asientosOcupados;

                asientosDisponiblesDeFlota = asientosDisponiblesDeFlota + listaDeVuelos[i].capacidadDisponible;

            }

            double ocupacionMedia = ((double)asientosOcupadosDeFlota / (asientosOcupadosDeFlota + asientosDisponiblesDeFlota)) * 100;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"El porcentaje de la ocupación media de la flota es de {ocupacionMedia}%.");

        }

        public static void VueloConMayorOcupacion(List<Vuelo> listaDeVuelos)
        {
            Console.Clear();
            string codigoVueloMayorOcupacion = "";
            double porcentajeVueloConMayorOcupacion = 0;
            for (int i = 0; i < listaDeVuelos.Count; i++)
            {
                int asientosOcupados = listaDeVuelos[i].capacidadMaxima - listaDeVuelos[i].capacidadDisponible;

                double ocupacionVuelo = ((double)asientosOcupados * 100) / listaDeVuelos[i].capacidadMaxima;

                if (ocupacionVuelo > porcentajeVueloConMayorOcupacion)
                {
                    porcentajeVueloConMayorOcupacion = ocupacionVuelo;
                    codigoVueloMayorOcupacion = listaDeVuelos[i].codigoVuelo;
                }
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"El vuelo con mayor ocupación es el vuelo {codigoVueloMayorOcupacion}. Tiene una ocupación de {porcentajeVueloConMayorOcupacion}%.");
        }

        public static int BuscarVueloPorCodigo(List<Vuelo> listaDeVuelos)
        {
            int indiceLista = -1;
            int returnVacio = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Escriba el código del vuelo: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string codigoUsuario = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < listaDeVuelos.Count; i++)
            {
                if(codigoUsuario == listaDeVuelos[i].codigoVuelo)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    int asientosOcupados = listaDeVuelos[i].capacidadMaxima - listaDeVuelos[i].capacidadDisponible;
                    double ocupacionVuelo = ((double)asientosOcupados * 100) / listaDeVuelos[i].capacidadMaxima;
                    if (codigoUsuario == listaDeVuelos[i].codigoVuelo)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("---------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        if (listaDeVuelos[i].clasificación == "internacional")
                        {
                            Console.WriteLine($"Clasificación del vuelo: Internacional.");
                        }
                        else
                        {
                            Console.WriteLine($"Clasificación del vuelo: Nacional.");
                        }
                        Console.WriteLine($"Código: {listaDeVuelos[i].codigoVuelo}.");
                        Console.WriteLine($"Fecha y hora de salida: {listaDeVuelos[i].fechaSalida}.");
                        Console.WriteLine($"Fecha y hora de llegada: {listaDeVuelos[i].fechaLlegada}.");
                        Console.WriteLine("Personal de cabina: ");
                        Console.WriteLine($" Nombre del piloto: {listaDeVuelos[i].nombrePiloto}.");
                        Console.WriteLine($" Nombre del copiloto: {listaDeVuelos[i].nombreCopiloto}.");
                        Console.WriteLine($"Capacidad maxima de asientos del vuelo: {listaDeVuelos[i].capacidadMaxima}.");
                        Console.WriteLine($"Ocupación: {listaDeVuelos[i].capacidadMaxima - listaDeVuelos[i].capacidadDisponible} / {listaDeVuelos[i].capacidadMaxima}.");
                        Console.WriteLine($"Porcentaje: {ocupacionVuelo}%.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("---------------------------------------------------------\n\n");
                        indiceLista = i;
                        return indiceLista;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("El código proporcionado no coindice con el código de ningún vuelo.");
            return indiceLista;


        }

        public static void ListaVuelos(List<Vuelo> listaDeVuelos)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            listaDeVuelos.Sort((y, x) => (((double)x.capacidadMaxima - x.capacidadDisponible) * 100 / x.capacidadMaxima).CompareTo(((double)y.capacidadMaxima - y.capacidadDisponible) * 100 / y.capacidadMaxima)
);
            for (int i = 0; i < listaDeVuelos.Count; i++)
            {
                int asientosOcupados = listaDeVuelos[i].capacidadMaxima - listaDeVuelos[i].capacidadDisponible;
                double ocupacionVuelo = ((double)asientosOcupados * 100) / listaDeVuelos[i].capacidadMaxima;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (listaDeVuelos[i].clasificación == "internacional")
                {
                    Console.WriteLine($"Clasificación del vuelo: Internacional.");
                }
                else
                {
                    Console.WriteLine($"Clasificación del vuelo: Nacional.");
                }
                Console.WriteLine($"Código: {listaDeVuelos[i].codigoVuelo}.");
                Console.WriteLine($"Fecha y hora de salida: {listaDeVuelos[i].fechaSalida}.");
                Console.WriteLine($"Fecha y hora de llegada: {listaDeVuelos[i].fechaLlegada}.");
                Console.WriteLine("Personal de cabina: ");
                Console.WriteLine($" Nombre del piloto: {listaDeVuelos[i].nombrePiloto}.");
                Console.WriteLine($" Nombre del copiloto: {listaDeVuelos[i].nombreCopiloto}.");
                Console.WriteLine($"Capacidad maxima de asientos del vuelo: {listaDeVuelos[i].capacidadMaxima}.");
                Console.WriteLine($"Ocupación: {listaDeVuelos[i].capacidadMaxima - listaDeVuelos[i].capacidadDisponible} / {listaDeVuelos[i].capacidadMaxima}.");
                Console.WriteLine($"Porcentaje: {ocupacionVuelo}%.");
                if (i == listaDeVuelos.Count - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("---------------------------------------------------------");
                }

            }
        }

    }
}

