using System;
using System.Collections.Generic;
using System.IO;

namespace Biblioteca
{
    public class LoansManager
    {



        private Dictionary<String, Prestamo> buscarPrestamos = new Dictionary<string, Prestamo>();


        private UsersManager users;
        private BooksManager books;

        public LoansManager(UsersManager users, BooksManager boks)
        {
            this.users = users;
            this.books = boks;
        }
        public void prestamosUsuarios()
        {
            Usuarios haniel = users.BuscarUsers["001-0010201-2"];
            Usuarios alvarado = users.BuscarUsers["002-0012983-5"];

            var libro1 = books.BuscarLibros["N003"];
            var libro2 = books.BuscarLibros["N002"];

            buscarPrestamos.Add("HH098", new Prestamo(haniel, "HH098", false,
                new List<Libros> { libro1, libro2 }, 2, new DateTime(2026, 3, 26), new DateTime(2026, 5, 26)));

            buscarPrestamos.Add("AL098", new Prestamo(alvarado, "AL098", false,
                new List<Libros> { libro1 }, 1, new DateTime(2026, 3, 20), new DateTime(2026, 5, 20)));

            libro1.cantidadDisponible--;
            libro2.cantidadDisponible--;


            string contenido = "";
            foreach (var Prestamos_Usuarios in buscarPrestamos)
            {
                var prestamo = Prestamos_Usuarios.Value;

                foreach (var libro in prestamo.Libros)
                {
                    contenido += prestamo.Usuario.Cedula + " | " +
                                 prestamo.Usuario.nombreCompleto + " | " +
                                 libro.nombreLibro + " | " +
                                 prestamo.fechaPrestamo.ToShortDateString() + " | " +
                                 prestamo.fechaDevolucion.ToShortDateString() + " | " +
                                 prestamo.Devuelto + Environment.NewLine;
                }
            }
            string ruta = "Info_Prestamos.txt";
            File.WriteAllText(ruta, contenido);

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
            string AgregarcodigoPrestamo;
            string codigo;
            string AgregarFechaPrestamo;
            string AgregarFechaDevolucion;



            Console.Clear();
            Console.WriteLine("Realizar Prestamos de Libros");
            Console.WriteLine();
            Console.WriteLine("Ingrese su cedula de identidad:");
            string cedula = Console.ReadLine();

            if (!users.BuscarUsers.ContainsKey(cedula))
            {
                Console.WriteLine("error: El usuario no existe. Por favor debe crear un usuario.");
                return;
            }



            Console.WriteLine("Ingrese codigo del libro:");
            do
            {

                codigo = Console.ReadLine().ToUpper(); ;

                if (!books.BuscarLibros.ContainsKey(codigo))
                {
                    Console.WriteLine("El libro que estas buscando no existe, agrega otra vez el codigo del libro correcto: ");

                }

            } while (!books.BuscarLibros.ContainsKey(codigo));




            var libro = books.BuscarLibros[codigo];

            if (libro.cantidadDisponible <= 0)
            {
                Console.WriteLine("Lo siento el libro que estas buscando no esta disponible.");
                return;
            }



            Console.WriteLine("Agrega un codigo unico al prestamo:");
            do
            {

                AgregarcodigoPrestamo = Console.ReadLine().ToUpper();
                if (AgregarcodigoPrestamo.Length > 5 || AgregarcodigoPrestamo.Length < 5)
                {
                    Console.WriteLine("El codigo del prestamo debe tener maximo 5 caracteres, (formato: AA111)");
                }
                if (buscarPrestamos.ContainsKey(AgregarcodigoPrestamo))
                {
                    Console.WriteLine("El codigo del prestamo a esta en uso, Agrega otro codigo ");

                }

            } while (buscarPrestamos.ContainsKey(AgregarcodigoPrestamo) || AgregarcodigoPrestamo.Length > 5 || AgregarcodigoPrestamo.Length < 5);


            DateTime fechaPrestamo;
            Console.WriteLine("Porfavor agrega la fecha actual para realizar el prestamo (formato: 00/00/0000):");

            do
            {
                AgregarFechaPrestamo = Console.ReadLine();
                if ((!DateTime.TryParse(AgregarFechaPrestamo, out fechaPrestamo)))
                {
                    Console.WriteLine("La fecha no tiene el formato correcto. Porfavor intente otra vez (formato: 00/00/0000): ");

                }
                if (DateTime.TryParse(AgregarFechaPrestamo, out fechaPrestamo))
                {
                    Console.WriteLine($"La fecha del prestamo ha sido registrada correctamente: {fechaPrestamo}");
                }

            } while (!DateTime.TryParse(AgregarFechaPrestamo, out fechaPrestamo));



            DateTime fechaDevolucion;
            Console.WriteLine("Porfavor agregue una fecha de devolucion (formato: 00/00/0000):");
            do
            {

                AgregarFechaDevolucion = Console.ReadLine();
                if ((!DateTime.TryParse(AgregarFechaDevolucion, out fechaDevolucion)))
                {
                    Console.WriteLine("La fecha no tiene el formato correcto. Porfavor intente otra vez (formato: 00/00/0000): ");

                }
                if (fechaDevolucion < fechaPrestamo)
                {
                    Console.WriteLine("La feca de devolucion no debe ser menor a la feca del inicio del prestamo. Intente otra vez");
                }
                if (DateTime.TryParse(AgregarFechaDevolucion, out fechaDevolucion))
                {
                    Console.WriteLine($"La fecha de devolucion ha sido registrada correctamente: {fechaDevolucion}");
                }


            } while (!DateTime.TryParse(AgregarFechaDevolucion, out fechaDevolucion) || fechaDevolucion < fechaPrestamo);
            libro.cantidadDisponible--;




            var usuario = users.BuscarUsers[cedula];



            string codigoPrestamo = AgregarcodigoPrestamo;

            buscarPrestamos.Add(codigoPrestamo, new Prestamo(usuario, codigoPrestamo, false,
                new List<Libros> { libro }, 1, fechaPrestamo, fechaDevolucion));


            Console.WriteLine("El prestamo ha sido realizado correctamente.");
        }



        public void DevolverLibro()
        {
            Console.Clear();
            Console.WriteLine("Realizar Devolucion de Libros");
            Console.WriteLine();
            Console.WriteLine("Porfavor ingrese codigo del prestamo:");
            string codigo = Console.ReadLine();

            if (!buscarPrestamos.ContainsKey(codigo))
            {
                Console.WriteLine("El prestamo que estas buscando NO existe, porfavor revise el codigo del prestamo");
                return;
            }

            var prestamo = buscarPrestamos[codigo];

            if (prestamo.Devuelto)
            {
                Console.WriteLine($"El prestamo {codigo} ya fue devuelto");

                return;
            }

            foreach (var libro in prestamo.Libros)
            {
                libro.cantidadDisponible++;
            }

            prestamo.Devuelto = true;
            prestamo.estado = "Libros devueltos";

            Console.WriteLine($"El libro se ha devuelto correctamente. Gracias por utilizar nuestro servicio.");
        }
    }
}
