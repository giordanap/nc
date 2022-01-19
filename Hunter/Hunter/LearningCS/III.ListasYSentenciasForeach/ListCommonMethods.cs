using System;
using System.Collections.Generic;

namespace UdemyHDL
{
    class ListCommonMethods
    {
        public void OutPut()
        {
            List<int> numbers = new List<int>()
            {
                4,3,5,19
            };

            Show(numbers);

            // Insert
            numbers.Insert(1, 6);

            Show(numbers);

            // Contains
            if(numbers.Contains(33))
                Console.WriteLine("Existe");
            else
                Console.WriteLine("no existe");

            // IndexOf
            int pos = numbers.IndexOf(19);
            Console.WriteLine(pos);
            pos = numbers.IndexOf(100);
            Console.WriteLine(pos);

            // Sort
            // Es mutable porque modifican los valores del objeto
            numbers.Sort();
            Show(numbers);

            string name = "Giordan";
            name = name.ToUpper();
            Console.WriteLine(name);

            // Add Range
            var numbers2 = new List<int>()
            {
                200,300,400
            };
            numbers.AddRange(numbers2);
            Show(numbers);
        }

        public static void Show(List<int> numbers)
        {
            Console.WriteLine("-- Numeros --");
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }

    }
}
