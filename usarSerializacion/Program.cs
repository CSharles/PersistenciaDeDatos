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
            using (StreamWriter outputFile = new StreamWriter(folderTemporal + @"\ArchivoLineas.txt"))
            {
                foreach (string linea in lineas)
                    outputFile.WriteLine(linea);
            }
        }
    }
}
