using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class Static
    {
        public void OutPut()
        {
            People people1 = new People()
            {
                Name = "Giordan",
                Age = 28
            };

            People people2 = new People()
            {
                Name = "Gabriel",
                Age = 20
            };

            // Siendo estático, no ncesita de un objeto para existir
            Console.WriteLine(People.Count);
            Console.WriteLine(People.GetCount());

        }

        // Hacemos uso de Static cuando no es requerido la creacion de una clase
        // pe: una clase que contenga calculos como area, perimetro, etc.
        // Si una clase es Static, todos su metodos y propiedades tmbn lo son

        public static class A
        {
            public static void some()
            {
                Console.WriteLine("algo");
            }
        }

        public class People
        {
            public static int Count = 0;
            public string Name { get; set; }
            public int Age { get; set; }

            public People()
            {
                Count++;
            }

            public static string GetCount()
            {
                // string interpolation
                return $"Esta clase se ha utilizado {Count} veces";
            }
        }
    }
}
