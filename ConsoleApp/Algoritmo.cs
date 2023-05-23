using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Algoritmo
    {
        public void saludar()
        {
            //Genera el log con la fecha alctual
            Log.Logger = new LoggerConfiguration()
               .WriteTo.File("Logs/Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")
               .CreateLogger();

            try
            {
                Console.WriteLine("Ingrese su nombre: ");
                string nombre = Console.ReadLine();

                if (nombre.Length > 10)
                {
                    throw new Exception("Error: El nombre solo debe tener un maximo de 10 caracteres");
                    
                }

                Console.WriteLine("Ingrese su edad:");
                int edad = int.Parse(Console.ReadLine());

                if (edad < 0 || edad > 99)
                {
                    throw new Exception("Error: La edad debe del 0 a 99 años");
                }

                Console.WriteLine("Ingrese su genero:");
                string genero = Console.ReadLine();
                bool gen;
                if (genero.ToLower() == "masculino")
                {
                    gen = true;
                }
                else if (genero.ToLower() == "femenino")
                {
                    gen = false;
                }
                else
                {
                    throw new Exception("Error: El genero no es valido");
                }

                Log.Information("Datos ingresados: Nombre: {Nombre}, Edad: {Edad}, Género: {Genero}",
                    nombre, edad, (gen ? "masculino" : "femenino"));


                Console.WriteLine($"Hola {nombre}, {edad} años, género {(gen ? "masculino" : "femenino")}.");

            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error fuera de rango: " + ex.Message);
                Log.Error(ex, "Error fuera de rango");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error de formato: " + ex.Message);
                Log.Error(ex,"Error de formato");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex, "Se produjo un error");
            }
            

        }

    }
}
