using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
   public class BoksManager
    {

        private List<GenerosLiterarios> generos = new List<GenerosLiterarios>();

        public void agregarGeneros()
        {
            generos.Add(new GenerosLiterarios("Narrativos"));
            generos.Add(new GenerosLiterarios("Tragedia"));
            generos.Add(new GenerosLiterarios("Drama"));
            generos.Add(new GenerosLiterarios("Aventura"));
            generos.Add(new GenerosLiterarios("Fantasía"));
            generos.Add(new GenerosLiterarios("Ciencia Ficcion"));
            generos.Add(new GenerosLiterarios("Terror"));
            generos.Add(new GenerosLiterarios("Romance"));
            generos.Add(new GenerosLiterarios("Misterio"));
            generos.Add(new GenerosLiterarios("Suspenso"));
        }

        private Dictionary<string, Libros> buscarLibros = new Dictionary<string, Libros>();
        public IReadOnlyDictionary<string, Libros> BuscarLibros => buscarLibros;
        public void almacen()
        {
            var Narrativo = generos.First(g => g.generoLibro == "Narrativos");
            var Drama = generos.First(g => g.generoLibro == "Drama");
            var Aventura = generos.First(g => g.generoLibro == "Aventura");
            var Fantasia = generos.First(g => g.generoLibro == "Fantasía");
            var Terror = generos.First(g => g.generoLibro == "Terror");

            // Narrativos
            buscarLibros.Add("N001", new Libros("N001", "Don Quijote de la Mancha", "Antoine de Saint - Exupéry", Narrativo, 1943, 10, new DateTime(2026, 3, 24)));
            buscarLibros.Add("N002", new Libros("N002", "Cien años de soledad", "Gabriel García Márquez", Narrativo, 1967, 15, new DateTime(2026, 3, 24)));
            buscarLibros.Add("N003", new Libros("N003", "La casa de los espíritus", "Isabel Allende", Narrativo, 1982, 5, new DateTime(2026, 3, 24)));

            // Drama
            buscarLibros.Add("D001", new Libros("D001", "Hamlet", "William Shakespeare", Drama, 1603, 15, new DateTime(2026, 3, 24)));
            buscarLibros.Add("D002", new Libros("D002", "Romeo y Julieta", "William Shakespeare", Drama, 1597, 9, new DateTime(2026, 3, 24)));
            buscarLibros.Add("D003", new Libros("D003", "Macbeth", "William Shakespeare", Drama, 1606, 18, new DateTime(2026, 3, 24)));

            // Aventura
            buscarLibros.Add("A001", new Libros("A001", "La isla del tesoro", "Robert Louis Stevenson", Aventura, 1883, 12, new DateTime(2026, 3, 24)));
            buscarLibros.Add("A002", new Libros("A002", "Robinson Crusoe", "Daniel Defoe", Aventura, 1719, 7, new DateTime(2026, 3, 24)));
            buscarLibros.Add("A003", new Libros("A003", "Las aventuras de Tom Sawyer", "Mark Twain", Aventura, 1876, 15, new DateTime(2026, 3, 24)));

            // Fantasía
            buscarLibros.Add("F001", new Libros("F001", "El Señor de los Anillos", "J.R.R. Tolkien", Fantasia, 1954, 13, new DateTime(2026, 3, 24)));
            buscarLibros.Add("F002", new Libros("F002", "El Hobbit", "J.R.R. Tolkien", Fantasia, 1937, 8, new DateTime(2026, 3, 24)));
            buscarLibros.Add("F003", new Libros("F003", "Alicia en el país de las maravillas", "Lewis Carroll", Fantasia, 1865, 17, new DateTime(2026, 3, 24)));

            // Terror
            buscarLibros.Add("H001", new Libros("H001", "Drácula", "Bram Stoker", Terror, 1897, 12, new DateTime(2026, 3, 24)));
            buscarLibros.Add("H002", new Libros("H002", "Frankenstein", "Mary Shelley", Terror, 1818, 7, new DateTime(2026, 3, 24)));
            buscarLibros.Add("H003", new Libros("H003", "It", "Stephen King", Terror, 1986, 18, new DateTime(2026, 3, 24)));

            string contenido = string.Format("{0,-15} | {1,-40} | {2,-30} | {3,-15} | {4,-15} | {5,-15} | {6,-20}\n\n",
             "Código Libro", "Nombre del Libro", "Autor", "Año Publicación", "Fecha Adquisición", "Cantidad Total", "Cantidad Disponible");

            foreach (var libros_info in buscarLibros)
            {
                var libros = libros_info.Value;

                contenido += string.Format("{0,-15} | {1,-40} | {2,-30} | {3,-15} | {4,-15} | {5,-15} | {6,-20}\n",
                    libros.codigoLibro,
                    libros.nombreLibro,
                    libros.autorLibro,
                    libros.añoPublicacion,
                    libros.fechaAdquisicion,
                    libros.cantidadTotal,
                    libros.cantidadDisponible);
            }

            string ruta = "Datos_Libros.txt";
            File.WriteAllText(ruta, contenido);

        }
        public void BuscarLibrosPorCodigo()
        {
            Console.Clear();
            Console.WriteLine("Porfavor ingrese el codigo del libro que quieres buscar");
            string Codigo = Console.ReadLine();

            if (buscarLibros.TryGetValue(Codigo, out Libros libro))
            {
                Console.WriteLine($"Codigo del libro: {libro.codigoLibro}\n" +
                   $"Libro: {libro.nombreLibro}\n" +
                   $"Autor: {libro.autorLibro}\n" +
                   $"Año de publicación: {libro.añoPublicacion}\n" +
                   $"Cantidad Disponible: {libro.cantidadDisponible}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
            }
            else
            {
                Console.WriteLine($"Lo siento, el codigo ingresado no existe \n"
                    + $"Porfavor intente otra vez");
            }
            Console.ReadKey();
        }

        public void mostrarLibros()
        {
            Console.Clear();
            Console.WriteLine("Repertorio de Libros en nuestra Biblioteca:");
            Console.WriteLine();
            foreach (var libros in buscarLibros.Values)
            {
                libros.mostrarLibros();
            }
        }
    }
}
