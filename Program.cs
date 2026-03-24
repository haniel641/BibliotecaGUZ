using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            biblioteca GUZ = new biblioteca();
            GUZ.agregarGeneros();
            GUZ.almacen();
            GUZ.buscarUsuarios();
            GUZ.prestamosUsuarios();
            GUZ.Menu();
            Console.ReadKey();
        }
    }

    public class biblioteca
    {
        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========BIBLIOTECA NUEVO PENSAMIENTO==========");
                Console.WriteLine("1. Buscar Libros");
                Console.WriteLine("2. Mostrar Repertorios de Libros");
                Console.WriteLine("3. Buscar Usuarios");
                Console.WriteLine("4. Mostrar Repertorio de Usuarios");
                Console.WriteLine("5. Informacion Prestamos");
                Console.WriteLine("6. Prestar Libros");
                Console.WriteLine("7. Devolver Libros");
                Console.WriteLine("8. Salir");
                string opcion = Console.ReadLine();

                if (!int.TryParse(opcion, out int opciones))
                {
                    Console.WriteLine("Haz ingresado una letra, porfavor ingrese un numero");
                    Console.WriteLine("Presione una tecla cualquiera para continuar");
                    Console.ReadKey();
                    continue;
                }
                switch (opciones)
                {
                    case 1:
                        BuscarLibrosPorCodigo();
                        break;

                    case 2:
                        mostrarLibros();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 3:
                        buscarUserporCedula();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 4:
                        mostrarUsuarios();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 5:
                        prestamosActivos();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 6:
                        PrestarLibro();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 7:
                        DevolverLibro();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.Write("SALIENDO DEL PROGRAMA, HASTA LUEGO");
                        return;

                    default:
                        Console.WriteLine("Opcion invalida, Intente otra vez");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public class GenerosLiterarios
        {
            public string generoLibro { get; set; }

            public GenerosLiterarios(string generoLibro)
            {
                this.generoLibro = generoLibro;
            }
        }

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

        private Dictionary<string, Libros> buscarLibros = new Dictionary<string, Libros>();

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

        private Dictionary<string, Usuarios> buscarUsers = new Dictionary<string, Usuarios>();

        public void buscarUsuarios()
        {
            buscarUsers.Add("001-0010201-2", new Usuarios($"Haniel Hernandez", "0001-0010201-2", "haniel0027@gmail.com", "Calle Dr. Mario García Alvarado #61\n" +
                "Distrito Nacional, Santo Domingo ", "809-000-0000"));
            buscarUsers.Add("002-0012983-5", new Usuarios($"Alvarado Jazmin", "002-0012983-5", "alvarado99@gmail.com", "Calle Héroes de Luperón esq. Rafael Damirón,\n" +
                "Centro de Los Héroes, Santo Domingo, República Dominicana", "829-000-0012"));
            buscarUsers.Add("002-2019302-1", new Usuarios($"willie Hernandez", "002-2019302-1", "willie0019@gmail.com", "Calle Luperón esq. Rafael Damirón,\n" +
                           "Santo Domingo, República Dominicana", "829-000-0012"));
        }

        public void buscarUserporCedula()
        {
            Console.Clear();
            Console.WriteLine("Porfavor ingrese la cedula del usuario que desea buscar:");
            string cedulaUsuario = Console.ReadLine();

            if (buscarUsers.TryGetValue(cedulaUsuario, out Usuarios usuario))
            {
                Console.WriteLine($"El usuario {cedulaUsuario} ha sido encontrado");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"Nombre: {usuario.nombreCompleto}\n" +
                $"Cedula de identidad: {usuario.Cedula}\n" +
                $"Correo electronico: {usuario.correoElectronico}\n" +
                $"Direccion de residencia: {usuario.direccionResidencia}\n" +
                $"Numero de telefono: {usuario.numeroTelefono}");
            }
            else
            {
                Console.WriteLine($"Lo siento, el usuario que intentas buscar no se ha encuentrado \n"
                    + $"Porfavor revise los datos e intente otra vez");
            }
        }

        public void mostrarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("Repertorio de usuarios registrados en nuestra biblioteca:");
            Console.WriteLine();
            foreach (var usuarios in buscarUsers.Values)
            {
                Console.WriteLine($"Nombre: {usuarios.nombreCompleto}\n" +
                    $"Cedula de identidad: {usuarios.Cedula}\n" +
                    $"Correo electronico: {usuarios.correoElectronico}\n" +
                    $"Direccion de residencia: {usuarios.direccionResidencia}\n" +
                    $"Numero de telefono: {usuarios.numeroTelefono}");
                Console.WriteLine();
            }
        }

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

        private Dictionary<String, Prestamo> buscarPrestamos = new Dictionary<string, Prestamo>();

        public void prestamosUsuarios()
        {
            Usuarios haniel = buscarUsers["001-0010201-2"];
            Usuarios alvarado = buscarUsers["002-0012983-5"];

            var libro1 = buscarLibros["N003"];
            var libro2 = buscarLibros["N002"];

            buscarPrestamos.Add("HH098", new Prestamo(haniel, "HH098", false,
                new List<Libros> { libro1, libro2 }, 2, new DateTime(2026, 3, 26), new DateTime(2026, 5, 26)));

            buscarPrestamos.Add("AL098", new Prestamo(alvarado, "AL098", false,
                new List<Libros> { libro1 }, 1, new DateTime(2026, 3, 20), new DateTime(2026, 5, 20)));

            libro1.cantidadDisponible--;
            libro2.cantidadDisponible--;
        }

        public void prestamosActivos()
        {
            Console.Clear();
            int cantidadTotalPrestada = 0;

            foreach (var prestamo in buscarPrestamos.Values)
            {
                cantidadTotalPrestada += prestamo.cantidad;
            }

            Console.WriteLine($"La biblioteca ha prestado {cantidadTotalPrestada} libros");
            Console.WriteLine();

            foreach (var prestamo in buscarPrestamos.Values)
            {
                Console.WriteLine($"Nombre: {prestamo.Usuario.nombreCompleto}\n" +
                $"Cedula: {prestamo.Usuario.Cedula}");
                Console.WriteLine("Libros:");

                foreach (var libro in prestamo.Libros)
                {
                    Console.WriteLine($"{libro.nombreLibro}");
                }

                Console.WriteLine($"Cantidad prestada: {prestamo.cantidad}\n" +
                $"Codigo del Prestamo: {prestamo.CodigoPrestamo}\n" +
                $"Devuelto: {prestamo.estado}\n" +
                $"Fecha del pretamo: {prestamo.fechaPrestamo}\n" +
                $"Fecha de devolucion esperada: {prestamo.fechaDevolucion}");
                Console.WriteLine();
            }
        }

        public void PrestarLibro()
        {
            Console.Clear();
            Console.WriteLine("Realizar Prestamos de Libros");
            Console.WriteLine();
            Console.WriteLine("Ingrese cedula:");
            string cedula = Console.ReadLine();

            if (!buscarUsers.ContainsKey(cedula))
            {
                Console.WriteLine("Usuario no existe");
                return;
            }

            Console.WriteLine("Ingrese codigo del libro:");
            string codigo = Console.ReadLine();

            if (!buscarLibros.ContainsKey(codigo))
            {
                Console.WriteLine("Libro no existe");
                return;
            }

            var libro = buscarLibros[codigo];

            if (libro.cantidadDisponible <= 0)
            {
                Console.WriteLine("No hay disponibilidad");
                return;
            }
            Console.WriteLine("Agrega un codigo del prestamo:");
            string AgregarcodigoPrestamo = Console.ReadLine();

            Console.WriteLine("Porfavor agrega la fecha actual para realizar el prestamo:");
            string AgregarFechaPrestamo = Console.ReadLine();

            if (DateTime.TryParse(AgregarFechaPrestamo, out DateTime fechaPrestamo))
            {
                Console.WriteLine($"La fecha del prestamo ha sido registrada correctamente: {fechaPrestamo}");
            }

            Console.WriteLine("Porfavor agregue una fecha de devolucion:");
            string AgregarFechaDevolucion = Console.ReadLine();

            if (DateTime.TryParse(AgregarFechaDevolucion, out DateTime fechaDevolucion))
            {
                Console.WriteLine($"La fecha de devolucion ha sido registrada correctamente: {fechaDevolucion}");
            }
            libro.cantidadDisponible--;

            var usuario = buscarUsers[cedula];

            string codigoPrestamo = AgregarcodigoPrestamo;

            buscarPrestamos.Add(codigoPrestamo, new Prestamo(usuario, codigoPrestamo, false,
                new List<Libros> { libro }, 1, fechaPrestamo, fechaDevolucion));

            Console.WriteLine("Prestamo realizado");
        }

        public void DevolverLibro()
        {
            Console.Clear();
            Console.WriteLine("Realizar Devolucion de Libros");
            Console.WriteLine();
            Console.WriteLine("Ingrese codigo del prestamo:");
            string codigo = Console.ReadLine();

            if (!buscarPrestamos.ContainsKey(codigo))
            {
                Console.WriteLine("No existe");
                return;
            }

            var prestamo = buscarPrestamos[codigo];

            if (prestamo.Devuelto)
            {
                Console.WriteLine("Ya fue devuelto");
                return;
            }

            foreach (var libro in prestamo.Libros)
            {
                libro.cantidadDisponible++;
            }

            prestamo.Devuelto = true;
            prestamo.estado = "Libros devueltos";

            Console.WriteLine($"El libro se ha devuelto correctamente");
        }
    }
}