using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class Lists
    {
        public void OutPut()
        {
            List<int> numbers = new List<int>();
            numbers.Add(5);
            numbers.Add(2);

            Console.WriteLine(numbers.Count);

            List<int> numbers2 = new List<int>()
            {
                1,6,7,10,14
            };

            Console.WriteLine(numbers2.Count);

            numbers2.Add(55);
            Console.WriteLine(numbers2.Count);

            numbers2.Clear();
            Console.WriteLine(numbers2.Count);

            List<string> countries = new List<string>()
            {
                "Mexico","Argentina","Espeña"
            };
            Console.WriteLine(countries.Count);
        }
    }
}
