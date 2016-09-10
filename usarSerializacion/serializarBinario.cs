using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace usarSerializacion
{
    class serializarBinario
    {
        public static void main()
        {
            string opcion;
            Dictionary<int, string> hotel = new Dictionary<int, string>();
            do
            {
                Console.WriteLine("Opciones del sistema:\n 1-ingresar datos, 2-guardar datos y salir, 3-recuperar datos y mostrarlos");
                opcion = Console.ReadLine();

                if (opcion.Equals("1"))
                {
                    PedirDatos(hotel); 
                }
                if (opcion.Equals("3"))
                {
                    string ruta = CrearCarpeta();
                    DeserializarDatos(ruta,hotel);
                }

                if (opcion.Equals("2"))
                {
                    string ruta= CrearCarpeta();
                    SerializarDatos(ruta, hotel);
                }
                 
            } while (!opcion.Equals("2")); 
    }

        private static void DeserializarDatos(string ruta, Dictionary<int, string> hotel)
        {
            using (FileStream fs = new FileStream(ruta+"hoteldata.bin", FileMode.Open))
            {
                // Creación de instancia de BinaryFormatter para deserializar:
                BinaryFormatter bf = new BinaryFormatter();

                hotel = (Dictionary<int,string>)bf.Deserialize(fs);
            }

            // Verificamos que el contenido ha sido correctamente deserializado:
            Console.WriteLine("Datos de hotel");
            foreach (KeyValuePair<int,string> huesped in hotel)
            {
                Console.WriteLine("\nHabitacion:" + huesped.Key + "\nNombre:" + huesped.Value);
                                  
            }
        }

        private static void SerializarDatos(string ruta, Dictionary<int,string> hotel)
        {
            // Creación de un flujo para escritura de los elementos del hashtable:
            using (FileStream fs = new FileStream(ruta +@"\hoteldata.bin",FileMode.Append))
            {
                // Creación instancia BinaryFormatter para serializar el diccionario.
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, hotel);
            }
        }

        private static string CrearCarpeta()
        {
            // Establecemos la ruta donde se guardara el archivo y la carpeta.
            string rutaEscritorio =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderDatos = Path.Combine(rutaEscritorio, "carpetaHotel");
            if (!Directory.Exists(folderDatos))
            {
                Directory.CreateDirectory(folderDatos);
            }
            return folderDatos;
        }

        private static void PedirDatos(Dictionary<int,string>hotel)
        {
            string opcion;
            do
            {
                Console.Clear();
                string nombreCliente;
                int numeroHabitacion = 0;
                Console.WriteLine("Ingrese la habitacion del hueped:");
                int.TryParse(Console.ReadLine(), out numeroHabitacion);
                Console.WriteLine("Ingrese el nombre del cliente:");
                nombreCliente = Console.ReadLine();
                hotel.Add(numeroHabitacion, nombreCliente);
                Console.WriteLine("Agregar otro cliente? S/N:");
                opcion = Console.ReadLine();
            } while (opcion.Equals("s"));
        }

    }
}
