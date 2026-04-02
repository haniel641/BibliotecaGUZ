using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class LoansManager
    {



        private Dictionary<String, Prestamo> buscarPrestamos = new Dictionary<string, Prestamo>();


        private UsersManager users;
        private BoksManager boks;

        public LoansManager(UsersManager users, BoksManager boks)
        {
            this.users = users;
            this.boks = boks;
        }
        public void prestamosUsuarios()
        {
            Usuarios haniel = users.BuscarUsers["001-0010201-2"];
            Usuarios alvarado = users.BuscarUsers["002-0012983-5"];

            var libro1 = boks.BuscarLibros["N003"];
            var libro2 = boks.BuscarLibros["N002"];

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
            Console.Clear();
            Console.WriteLine("Realizar Prestamos de Libros");
            Console.WriteLine();
            Console.WriteLine("Ingrese cedula:");
            string cedula = Console.ReadLine();

            if (!users.BuscarUsers.ContainsKey(cedula))
            {
                Console.WriteLine("Usuario no existe");
                return;
            }

            Console.WriteLine("Ingrese codigo del libro:");
            string codigo = Console.ReadLine();

            if (!boks.BuscarLibros.ContainsKey(codigo))
            {
                Console.WriteLine("Libro no existe");
                return;
            }

            var libro = boks.BuscarLibros[codigo];

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

            var usuario = users.BuscarUsers[cedula];

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
