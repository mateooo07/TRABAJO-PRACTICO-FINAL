using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRABAJO_PRACTICO_FINAL
{
    internal class Aerolínea
    {
        public string razonSocial { get; set; }
        public string telefono { get; set; }
        public string domicilio { get; set; }
        public List<Vuelo> listaDeVuelos { get; set; }

        public Aerolínea(string razonSocial, string telefono, string domicilio, List<Vuelo> listaDeVuelos)
        {
            this.razonSocial = razonSocial;
            this.telefono = telefono;
            this.domicilio = domicilio;
            this.listaDeVuelos = listaDeVuelos;
        }
    }
}
