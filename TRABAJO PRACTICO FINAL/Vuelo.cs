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
            this.asientos = asientos;
        }
    }
}
