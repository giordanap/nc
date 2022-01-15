using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class ClasesYObjetos
    {
        public void OutPut()
        {
            Sale sale1 = new Sale(100, DateTime.Now);
            Console.WriteLine(sale1.GetInfo());
        }

        class Sale
        {
            int total;
            DateTime date;

            public Sale(int total, DateTime date)
            {
                this.total = total;
                this.date = date;
            }

            public string GetInfo()
            {
                return total + " " + date.ToLongDateString();
            }

            public void Show()
            {
                Console.WriteLine("Hola soy una venta");
            }
        }
    }
}
