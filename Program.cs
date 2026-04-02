using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Biblioteca
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            BoksManager BoksData = new BoksManager();
            BoksData.agregarGeneros();
            BoksData.almacen();
           
          
            UsersManager UsersData = new UsersManager();
            UsersData.buscarUsuarios();

            LoansManager LoansData = new LoansManager(UsersData, BoksData);
            LoansData.prestamosUsuarios();


            biblioteca GUZ = new biblioteca(BoksData, UsersData, LoansData);
            GUZ.Menu();
            Console.ReadKey();
        }
    }

    public class biblioteca
    {

        private BoksManager BManager;
        private UsersManager UManager;
        private LoansManager LManager;
       


           public biblioteca(BoksManager BManager, UsersManager Umanager, LoansManager LManager)
        {
            this.BManager = BManager;
            this.UManager = Umanager;
            this.LManager = LManager;
        }

        
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
                       BManager.BuscarLibrosPorCodigo();
                        break;

                    case 2:
                        BManager.mostrarLibros();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 3:
                        UManager.buscarUserporCedula();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 4:
                        UManager.mostrarUsuarios();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 5:
                        LManager.prestamosActivos();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 6:
                        LManager.PrestarLibro();
                        Console.WriteLine("Presione una tecla cualquiera para volver al menú principal");
                        Console.ReadKey();
                        break;

                    case 7:
                        LManager.DevolverLibro();
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
        
    }
}