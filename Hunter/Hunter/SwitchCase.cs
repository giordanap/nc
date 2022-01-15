using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class SwitchCase
    {
        public void OutPut()
        {
            int op = 3;

            switch (op)
            {
                case 1:
                    Console.WriteLine("Seleccionaste el 1");
                    break;
                case 2:
                    Console.WriteLine("Seleccionaste el 2");
                    break;
                // seleccion de multiples casos puntuales
                case 3:
                case 4:
                    Console.WriteLine("Seleccionaste 3 o 4");
                    break;
                case > 4 and < 10:
                    Console.WriteLine("Entre 5 y 9");
                    break;
                // se evalúa rango
                case < 0:
                case > 100:
                    Console.WriteLine("Fuera de rango");
                    break;
                default:
                    Console.WriteLine("Invalido");
                    break;
            }

        }

    }
}
