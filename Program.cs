namespace Contar
{
    using System;
    using System.IO;
    using System.Text;
    class Resumen
    {
        static void Main(string[] args)
        {
            string directorioSalida = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            string nombreArchivoSalida = $"resumen_{DateTime.Now.Year:D4}{DateTime.Now.Month:D2}{DateTime.Now.Day:D2}_{DateTime.Now.Hour:D2}{DateTime.Now.Minute:D2}{DateTime.Now.Second:D2}.txt";
            string ruta = $"{directorioSalida}\\{nombreArchivoSalida}";

            FileStream archivo = File.Create(ruta);
            archivo.Close();

            EscribirEnArchivo(ruta, $"Conteo de archivos en {Directory.GetCurrentDirectory()} y sus sub-directorios");
            EscribirEnArchivo(ruta, "");
            
            EscribirContenido(ruta, Directory.GetCurrentDirectory());
            
        }

        static void EscribirContenido(String ruta, string nombreDirectorio)
        {
            string[] directorios = Directory.GetDirectories(nombreDirectorio);
            foreach (var dir in directorios)
            {
                EscribirContenido(ruta, dir);
            }

            EscribirEnArchivo(ruta, nombreDirectorio);
            EscribirEnArchivo(ruta, $"{Directory.GetFiles(nombreDirectorio).Length} archivos");
            EscribirEnArchivo(ruta, "");

        }

        static void EscribirEnArchivo(String ruta, string contenido)
        {
            using StreamWriter file = new StreamWriter(ruta, append:true);
            file.WriteLine(contenido);
        }

        static void CrearArchivo(String ruta)
        {
            FileStream archivo = File.Create(ruta);
            archivo.Close();
        }
    }

    
}