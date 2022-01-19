using System;
using System.IO; // Nos permite leer archivos de texto

namespace UdemyHDL
{
    class Excepciones
    {
        public void OutPut()
        {
            try
            {
                string content = File.ReadAllText(@"C:\Users\Usuario\Documents\GitHub\files_github\hunter.txt");
                Console.WriteLine(content);

                //string content2 = File.ReadAllText(@"C:\Users\Usuario\Documents\GitHub\files_github\hunter2.txt");
                //Console.WriteLine(content2);

                throw new Exception("Ocurrio algo raro");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("El archivo no existe");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Aqui me he ejecutado, pase lo que pase");
            }

            // Esta parte de codigo no se ejecutaria si no se controla la excepcion
            Console.WriteLine("Aqui se sigue ejecutando");
        }

        // Es para controlar situaciones inesperadas
        // pe: la bd no tiene coleccion, esta caida.
        // Un servicio esta caido, un archivo no existe
        // Una validacion que no se esperaba, la lectura
        // de un dato como entero, pero llega como string
    }
}
