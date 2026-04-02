using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuarios
    {
        public string nombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string correoElectronico { get; set; }
        public string direccionResidencia { get; set; }
        public string numeroTelefono { get; set; }

        public Usuarios(string nombreCompleto, string Cedula, string correoElectronico, string direccionResidencia, string numeroTelefono)
        {
            this.nombreCompleto = nombreCompleto;
            this.Cedula = Cedula;
            this.correoElectronico = correoElectronico;
            this.direccionResidencia = direccionResidencia;
            this.numeroTelefono = numeroTelefono;
        }
    }
}
