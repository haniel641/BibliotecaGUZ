using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class UsersManager
    {
        private Dictionary<string, Usuarios> buscarUsers = new Dictionary<string, Usuarios>();
        public IReadOnlyDictionary<string, Usuarios> BuscarUsers => buscarUsers;
        public void buscarUsuarios()
        {
            buscarUsers.Add("001-0010201-2", new Usuarios($"Haniel Hernandez", "0001-0010201-2", "haniel0027@gmail.com", "Calle Dr. Mario García Alvarado #61\n" +
                "Distrito Nacional, Santo Domingo ", "809-000-0000"));
            buscarUsers.Add("002-0012983-5", new Usuarios($"Alvarado Jazmin", "002-0012983-5", "alvarado99@gmail.com", "Calle Héroes de Luperón esq. Rafael Damirón,\n" +
                "Centro de Los Héroes, Santo Domingo, República Dominicana", "829-000-0012"));
            buscarUsers.Add("002-2019302-1", new Usuarios($"willie Hernandez", "002-2019302-1", "willie0019@gmail.com", "Calle Luperón esq. Rafael Damirón,\n" +
                           "Santo Domingo, República Dominicana", "829-000-0012"));

            string contenido = string.Format("{0,-15} | {1,-40} | {2,-40} | {3,-55} | {4,-15}\n\n",
             "Cédula", "Nombre Completo", "Correo Electronico", "Direccion de Residencia", "Número Telefonico");
            

            foreach (var usuarios_Agreg in buscarUsers)
            {
                var usuarios = usuarios_Agreg.Value;

                contenido += string.Format("{0,-15} | {1,-40} | {2,-40} | {3,-55} | {4,-15}\n",
                    usuarios.Cedula,
                    usuarios.nombreCompleto,
                    usuarios.correoElectronico,
                    usuarios.direccionResidencia,
                    usuarios.numeroTelefono);
            }

            string ruta = "Datos_Usuarios.txt";
            File.WriteAllText(ruta, contenido);

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
    }
}
