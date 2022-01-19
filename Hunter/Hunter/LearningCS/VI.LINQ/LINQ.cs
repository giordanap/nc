using System;
using System.Collections.Generic;
using System.Linq;


namespace UdemyHDL
{
    class LINQ
    {
        public void OutPut()
        {
            List<Beer> beers = new List<Beer>()
            {
                new Beer()
                {
                    Name = "Corona", Country ="Mexico"
                },
                new Beer()
                {
                    Name = "Delirium", Country ="Belgica"
                },
                new Beer()
                {
                    Name = "Erdinger", Country ="Alemania"
                }
            };

            foreach (var beer in beers)
                Console.WriteLine(beer);

            Console.WriteLine("-----------------");
            //Select
            var beersName = from b in beers
                            select new
                            {
                                Name = b.Name,
                                Letters = b.Name.Length,
                                Fixed = 1
                            };

            foreach (var beer in beersName)
                Console.WriteLine($"{beer.Name} {beer.Letters} {beer.Fixed}");

            Console.WriteLine("-----------------");
            var beersNameReal = from b in beersName
                            select new
                            {
                                Name = b.Name
                            };

            foreach (var beer in beersNameReal)
                Console.WriteLine(beer.Name);

            Console.WriteLine("-----------------");
            var beersCountry = from b in beers
                               where b.Country == "Mexico"
                               || b.Country == "Alemania"
                               select b;

            foreach (var beer in beersCountry)
                Console.WriteLine(beer);

            Console.WriteLine("-----------------");
            var beersOrders = from b in beers
                               orderby b.Country
                               select b;

            foreach (var beer in beersOrders )
                Console.WriteLine(beer);

        }
    }

    public class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Name} Pais: {Country}";
        }
    }
}
