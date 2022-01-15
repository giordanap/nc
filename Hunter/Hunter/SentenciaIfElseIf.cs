using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class SentenciaIfElseIf
    {
        public void OutPut()
        {
            bool areYouHungry = true;
            bool youHaveMoney = true;

            if (areYouHungry && youHaveMoney && IsOpenRestaurant("Lonches pepe", 12))
            {
                Console.WriteLine("Come");
            } else
            {
                Console.WriteLine("No comes");
            }

        }

        static bool IsOpenRestaurant(string name, int hour = 0)
        {
            if (name == "Lonches pepe" && hour > 8 && hour < 23)
            {
                return true;
            }
            else if (name == "Restaurant 24 horas")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
