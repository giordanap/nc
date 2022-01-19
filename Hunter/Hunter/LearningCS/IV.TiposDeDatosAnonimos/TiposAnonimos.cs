using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class TiposAnonimos
    {
        public void OutPut()
        {
            // Crear objetos sin la necesidad de crear una clase
            // Estos objetos son solo de lectura (readonly)
            var giordan = new
            {
                Name = "Giordan",
                Country = "Peru" 
            };

            Console.WriteLine($"{giordan.Name} {giordan.Country}");

            var beers = new[]
            {
                new { Name = "Red", Brand = "Delirium"},
                new { Name = "Pilsen", Brand = "Backus"},

            };

            foreach (var p in beers)
            {
                Console.WriteLine($"cerveza {p.Name} {p.Brand}");
            }
        }
    }
}
