using System;

namespace UdemyHDL
{
    class While
    {
        public void OutPut()
        {
            int i = 0;
            
            while (i < 10)
            {
                Console.WriteLine("Iteracion de i " + i);
                i++;
            }

            int j = 0;
            while (j < 100)
            {
                if (j > 10)
                    break;

                Console.WriteLine("Iteracion de j " + j);
                j++;
            }

            string[] friends = new string[6]{
                "Pancho",
                "Paco",
                "Ana",
                "Ruben",
                "Karla",
                "Luis"
            };

            int index = 0;
            while (index < friends.Length)
            {
                Console.WriteLine(friends[index]);
                index++;
            }

            // Si se busca que entre al menos una vez al bucle
            bool run = false;
            do
            {
                Console.WriteLine("Entro una vez y ya");
            } while (run);

        }
    }
}
