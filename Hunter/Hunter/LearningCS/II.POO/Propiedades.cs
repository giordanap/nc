using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class Propiedades
    {
        public void OutPut()
        {
            Sale mySale = new Sale(100, DateTime.Now);
            mySale.Total = 120;
            Console.WriteLine(mySale.Total);
            //mySale.Date = DateTime.Now.ToLongDateString(); // solo lectura
            Console.WriteLine(mySale.Date);
        }

        class Sale
        {
            private int total; // Si la variable es privada
            private DateTime date;

            public string Date
            {
                get
                {
                    return date.ToLongDateString();
                }
            }

            // Creamos una propiedad para poder acceder
            public int Total
            {
                get
                {
                    return total;
                }
                set
                {
                    if (value < 0)
                        value = 0;
                    total = value;
                }
            }

            public Sale(int total, DateTime date)
            {
                this.total = total;
                this.date = date;
            }

        }
    }
}
