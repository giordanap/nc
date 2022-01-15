using System;
using System.Collections.Generic;

namespace UdemyHDL
{
    class ForEach
    {
        public void OutPut()
        {
            // var reemplaza a List<int> porque el tipo de variable
            // es espcificado a la derecha. esto solo sirve en métodos.
            // No se puede usar en propiedades de la clase.
            var numbers = new List<int>()
            {
                23,3,5,10,22,12
            };

            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }

            var students = new List<People>()
            {
                new People(){ Name = "Gabriel", Country = "Mexico"},
                new People(){ Name = "Gius", Country = "Chile"},
                new People(){ Name = "Hunter", Country = "Peru"}
            };

            Show(students);
            students.RemoveAt(0);
            Show(students);
        }

        static void Show(List<People> students)
        {
            Console.WriteLine("-- Personas --");
            foreach (var people in students)
            {
                Console.WriteLine($"Nombre: {people.Name}, Pais: {people.Country}");
            }
        }

        class People
        {
            public string Name { get; set; }
            public string Country { get; set; }
        }
    }
}
