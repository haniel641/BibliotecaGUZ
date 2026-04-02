using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Prestamo
    {
         public string CodigoPrestamo { get; set; }
            public bool Devuelto { get; set; }
            public string estado { get; set; }
            public int cantidad { get; set; }
            public List<Libros> Libros { get; set; }
            public Usuarios Usuario { get; set; }
            public DateTime fechaPrestamo { get; set; }
            public DateTime fechaDevolucion { get; set; }

            public Prestamo(Usuarios usuario, string codigoPrestamo, bool devuelto, List<Libros> libros, int cantidadPrestada, DateTime fechaPrestamo, DateTime fechaDevolucion)
            {
                Usuario = usuario;
                CodigoPrestamo = codigoPrestamo.ToLower();
                Devuelto = devuelto;
                Libros = libros ?? new List<Libros>();
                cantidad = cantidadPrestada;
                this.fechaPrestamo = fechaPrestamo;
                this.fechaDevolucion = fechaDevolucion;

                if (Devuelto == true)
                {
                    estado = "Libros devueltos";
                }
                else
                {
                    estado = "Libros no devuetos";
                }
            }

        
    }
}
