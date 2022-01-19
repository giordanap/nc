using System;

namespace UdemyHDL
{
    class Variable
    {
        public void OutPut()
        {
            int numero1 = 1;
            // imprime uno
            Console.WriteLine(numero1);

            numero1++;
            // imprime dos y luego aumenta
            Console.WriteLine(numero1++);
            // imprime tres y luego aumenta
            Console.WriteLine(numero1++);
        }
    }
}
