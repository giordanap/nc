using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class Tuplas
    {
        public void OutPut()
        {
            (int id, string name) product = (1, "cerveza stout");

            Console.WriteLine($"{product.id} {product.name}");

            product.name = "cerveza porter";

            Console.WriteLine($"{product.id} {product.name}");

            var person = (1, "Hector");

            Console.WriteLine($"persona {person.Item1} {person.Item2}");

            var people = new[]
            {
                (1, "Hector"),
                (2, "Pedro"),
                (3, "Juan")
            };

            foreach (var p in people)
            {
                Console.WriteLine($"{p.Item1} {p.Item2}");
            }

            (int id, string name)[] people2 = new[]
            {
                (1, "Hector"),
                (2, "Pedro"),
                (3, "Juan")
            };

            foreach (var p in people2)
            {
                Console.WriteLine($"{p.id} {p.name}");
            }

            var cityInfo = GetLocationLima();
            Console.WriteLine($"lat: {cityInfo.lat} lng: {cityInfo.lng} nombre: {cityInfo.name}");

            // parecido a desestructuracion en JS
            var (_, lng,_) = GetLocationLima();
            Console.WriteLine(lng);

        }

        public static (float lat, float lng, string name) GetLocationLima()
        {
            float lat = 19.12121f;
            float lng = -99.19212f;
            string name = "Lima";

            return (lat, lng, name);
        }
    }
}
