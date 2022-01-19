using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class Sobrecarga
    {
        public void OutPut()
        {
            Math math = new Math();
            Console.WriteLine(math.Sum(1,2));
            Console.WriteLine(math.Sum("1", "2"));

            int[] numbers = new int[] { 1, 2, 5 };
            Console.WriteLine(math.Sum(numbers));
        }

        // Con public la clase math puede ser invocada desde cualquier parte
        public class Math
        {
            public int Sum(int a, int b)
            {
                return a + b;
            }

            public int Sum(string a, string b)
            {
                return int.Parse(a) + int.Parse(b)  ;
            }

            public int Sum(int[] numbers)
            {
                int result = 0;
                int i = 0;

                while (i < numbers.Length)
                {
                    result += numbers[i];
                    i++;
                }

                return result;
            }

        }

    }
}
