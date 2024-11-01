using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRABAJO_PRACTICO_FINAL
{
    internal class Vuelo
    {
        public string clasificación { get; set; }
        public string codigoVuelo { get; set; }
        public DateTime fechaSalida {  get; set; }
        public DateTime fechaLlegada { get; set; }
        public string nombrePiloto { get; set; }
        public string nombreCopiloto { get; set; }
        public int capacidadMaxima { get; set; }
        public int capacidadDisponible { get; set; }
        public int[] asientos { get; set; }

        public Vuelo(string clasificación, string codigoVuelo, DateTime fechaSalida, DateTime fechaLlegada, string nombrePiloto, string nombreCopiloto, int capacidadMaxima, int[] asientos)
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

        public static void RegistrarPasajeros(List<Vuelo>listaDeVuelos)
        {
            Console.Clear();
            Console.Write("Escriba el código del vuelo al cual quiere registrarle cierta cantidad de pasajeros: ");
            string codigoVuelo = Console.ReadLine();
            for(int i=0; i< listaDeVuelos.Count; i++)
            {
                if(codigoVuelo == listaDeVuelos[i].codigoVuelo)
                {
                    Console.Write("Escriba la cantidad de pasajeros que quiera registrar en el vuelo: ");
                    string entrada = Console.ReadLine();
                    if(int.TryParse(entrada, out int cantidadPasajeros))
                    {
                        if(cantidadPasajeros> listaDeVuelos[i].capacidadMaxima)
                        {
                            Console.WriteLine("La cantidad de pasajeros a registrar excede la capacidad maxima del vuelo.");
                            return; 
                        }
                        else if(cantidadPasajeros > listaDeVuelos[i].capacidadDisponible)
                        {
                            Console.WriteLine("La cantidad de pasajeros a registrar excede la cantidad disponible.");
                            return;
                        }
                        else
                        {
                            listaDeVuelos[i].capacidadDisponible -= cantidadPasajeros;
                            for(int j = 0; j < cantidadPasajeros; j++)
                            {
                                listaDeVuelos[i].asientos[j] = 1;
                            }
                            Console.WriteLine($"{cantidadPasajeros} Pasajeros registrados.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Escriba un número.");
                        return;
                    }
                }
            }
        }
    }
}
