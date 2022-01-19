using System;
using System.Text.Json;

namespace UdemyHDL
{
    class Json
    {
        public void OutPut()
        {
            Beer myBeer = new Beer()
            {
                Name = "Pikantus",
                Brand = "Erdinger"
            };

            // El formato escape para poder agregar comillas en un texto es "\"
            //string json = "{\"Name\": \"Pikantus\", \"Brand\": \"Erdinger\"}";
            string json = JsonSerializer.Serialize(myBeer);
            Beer beer = JsonSerializer.Deserialize<Beer>(json);

            Beer[] beers = new Beer[]
            {
                new Beer()
                {
                    Name = "Pikantus",
                    Brand = "Erdinger"
                },
                new Beer()
                {
                    Name = "Corona",
                    Brand = "Modelo"
                }
            };

            //string json2 = "[" +
            //    "{\"Name\": \"Pikantus\", \"Brand\": \"Erdinger\"}," +
            //    "{\"Name\": \"Corona\", \"Brand\": \"Modelo\"}," +
            //    "]";
            string json2 = JsonSerializer.Serialize(beers);
            Beer[] beers2 = JsonSerializer.Deserialize<Beer[]>(json2);

        }

        public class Beer
        {
            public string Name { get; set; }
            public string Brand { get; set; }
        }
    }
}
