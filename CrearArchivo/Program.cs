using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearArchivo
{
    class Program
    {
        static void Main(string[] args)
        {
            string rutaApp = Directory.GetCurrentDirectory();
            string rutaTemp = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Desktop\temp");
            string nombreArchivo = "prueba.txt";
            Console.WriteLine("Directorio Actual: " + rutaApp);
            if (!Directory.Exists(rutaTemp))
            {
                Directory.CreateDirectory(rutaTemp);
            }
            if (rutaApp.Equals(Directory.GetCurrentDirectory()))
            {
                Console.WriteLine("Trabajando en carpeta temporal");
                Console.WriteLine("Creando archivo prueba.txt");
                string rutaArchivo = Path.Combine(rutaTemp, nombreArchivo);
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Append))
                {
                    //se crea el archivo vacio.
                }
            }
            else
            {
                Console.WriteLine("No esta en la carpeta temporal");
            }
        }
    }
}
