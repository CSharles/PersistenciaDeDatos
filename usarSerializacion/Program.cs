using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace usarSerializacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crea un arreglo de tres lineas
            string[] lineas = { "Primera Linea", "Segunda Linea", "Tercera Linea" };

            // Establecemos la ruta donde se guardara el archivo y la carpeta.
            string rutaEscritorio =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderTemporal = Path.Combine(rutaEscritorio, "temporal");
            if (!Directory.Exists(folderTemporal))
            {
                Directory.CreateDirectory(folderTemporal);
            }
            // Escribimos las lineas del arreglo en el archivo.
            try
            {
                using (StreamWriter archivo = new StreamWriter(folderTemporal + @"\ArchivoLineas.txt"))
                {
                    foreach (string linea in lineas)
                        archivo.WriteLine(linea);
                }
                Console.WriteLine("Los datos han sido almacenados en:\n \t"+folderTemporal);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al almacenar los datos.\n"+e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para terminar");
                Console.ReadKey();
                //Console.Clear();

               // serializarBinario.main();
            }
        }
    }
}
