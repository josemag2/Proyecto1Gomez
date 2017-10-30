using System;
using System.IO;

public class Ficheros
{

    // Leer un fichero
    private static string LeerFichero(string ruta)
    {
        string texto = "";

        try
        {
            StreamReader fichero = File.OpenText(ruta);
            string linea = "";
            //texto = fichero.ReadToEnd();
            while (linea != null)
            {
                linea = fichero.ReadLine();
                texto += linea + "\n";
            }
            fichero.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al leer en el fichero. " + e);
        }

        return texto;
    }

    // Crear un fichero con contenido nuevo
    private static void CrearFichero(string ruta, string contenido)
    {
        try
        {
            StreamWriter fichero = File.CreateText(ruta);
            fichero.Write(contenido);
            fichero.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al crear el fichero. " + e);
        }
    }

    // Modificar un fichero
    private static void ModificarFichero(string ruta, string contenido)
    {
        //Leer y almacenar el contenido original <-
        string contenidoOriginal = LeerFichero(ruta);
        //Concatenarlo (unirlo)
        string contenidoFinal = contenidoOriginal + contenido;
        //Escribir en el fichero <-
        CrearFichero(ruta, contenidoFinal);
    }



    public static void RealizarTest()
    {
        //string texto = LeerFichero("../../Resources/prueba.txt");
        //Console.WriteLine(texto);
        //CrearFichero("../../Resources/nuevo.txt", "Hola Mundo!");
        ModificarFichero("../../Resources/nuevo.txt", "Adios Mundo!");
    }
}