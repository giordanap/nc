using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class For
    {
        public void OutPut()
        {
            string[] friends = new string[6]{
                "Pancho",
                "Paco",
                "Ana",
                "Ruben",
                "Karla",
                "Luis"
            };

            int n = friends.Length;
            bool run = true;

            for (int i = 0, j = (n - 1); i < n && run; i++, j--)
            {
                Console.WriteLine(friends[i] + " y " + friends[j]);
            }
        }
    }
}
