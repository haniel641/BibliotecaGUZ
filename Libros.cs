using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteca.biblioteca;

namespace Biblioteca
{
    public class Libros
    {
        public string codigoLibro { get; set; }
        public string nombreLibro { get; set; }
        public string autorLibro { get; set; }
        public GenerosLiterarios Genero { get; set; }
        public int añoPublicacion { get; set; }
        public virtual int cantidadTotal { get; set; }
        public virtual int cantidadDisponible { get; set; }
        public DateTime fechaAdquisicion { get; set; }

        public Libros(string codigoLibro, string nombreLibro, string autorLibro, GenerosLiterarios Genero, int añoPublicacion, int cantidadTotal, DateTime fechaAdquisicion)
        {
            this.codigoLibro = codigoLibro.ToLower();
            this.nombreLibro = nombreLibro;
            this.autorLibro = autorLibro;
            this.Genero = Genero;
            this.añoPublicacion = añoPublicacion;
            this.cantidadTotal = cantidadTotal;
            this.cantidadDisponible = cantidadDisponible = cantidadTotal;
            this.fechaAdquisicion = fechaAdquisicion;
        }

        public virtual void mostrarLibros()
        {
            Console.WriteLine($"Codigo del libro: {codigoLibro}\n" +
               $"Libro: {nombreLibro}\n" +
               $"Autor: {autorLibro}\n" +
               $"Genero Literario: {Genero.generoLibro}\n" +
               $"Año de publicación: {añoPublicacion}\n" +
               $"Cantidad Total: {cantidadTotal}\n");
        }
    }
}
