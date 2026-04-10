using System;

namespace Biblioteca
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            BooksManager booksManager = new BooksManager();
            booksManager.agregarGeneros();
            booksManager.almacen();


            UsersManager usersManager = new UsersManager();
            usersManager.buscarUsuarios();


            LoansManager loansManager = new LoansManager(usersManager, booksManager);
            loansManager.prestamosUsuarios();


            Biblioteca GUZ = new  Biblioteca(booksManager, usersManager, loansManager);
            GUZ.Menu();
            Console.ReadKey();
        }
    }

    public class Biblioteca
    {

        private BooksManager BManager;
        private UsersManager UManager;
        private LoansManager LManager;



        public Biblioteca(BooksManager BManager, UsersManager Umanager, LoansManager LManager)
        {
            this.BManager = BManager;
            this.UManager = Umanager;
            this.LManager = LManager;
        }

        static void ContinuarMensaje()
        {
            Console.WriteLine("Presione una tecla cualquiera para continuar");
            Console.ReadKey();
        }

        public void Menu()
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========BIBLIOTECA NUEVO PENSAMIENTO==========");
                Console.WriteLine("1. Buscar Libros");
                Console.WriteLine("2. Mostrar Repertorios de Libros");
                Console.WriteLine("3. Agregar Usuarios");
                Console.WriteLine("4. Buscar Usuarios");
                Console.WriteLine("5. Mostrar Repertorio de Usuarios");
                Console.WriteLine("6. Informacion Prestamos");
                Console.WriteLine("7. Prestar Libros");
                Console.WriteLine("8. Devolver Libros");
                Console.WriteLine("9. Salir");
                string opcion = Console.ReadLine();

                if (!int.TryParse(opcion, out int opcionNumero))
                {
                    Console.WriteLine("Haz ingresado una letra, porfavor ingrese un numero");

                    continue;
                }
                switch (opcionNumero)
                {
                    case 1:
                        BManager.BuscarLibrosPorCodigo();
                        break;

                    case 2:
                        BManager.mostrarLibros();
                        break;

                    case 3:
                        UManager.agregarUsuario();
                        break;
                    case 4:
                        UManager.buscarUserporCedula();
                        break;

                    case 5:
                        UManager.mostrarUsuarios();
                        break;

                    case 6:
                        LManager.prestamosActivos();
                        break;

                    case 7:
                        LManager.PrestarLibro();
                        break;

                    case 8:
                        LManager.DevolverLibro();
                        break;

                    case 9:
                        Console.Write("SALIENDO DEL PROGRAMA, HASTA LUEGO");
                        return;

                    default:
                        Console.WriteLine("Opcion invalida, Intente otra vez");
                        break;
                }
                ContinuarMensaje();
            }
        }

    }
}