using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class ExcepcionesPersonalizadas
    {
        public void OutPut()
        {
            try
            {
                Beer beer = new Beer()
                {
                    Name = "London Porter",
                    //Brand = "Fuller's"
                };
                Console.WriteLine(beer);
            }
            catch (InvalidBeerException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public class InvalidBeerException : Exception
        {
            // Para que el constructor invoque al metodo del padre
            // llamamos a base
            public InvalidBeerException() : base("La cerveza no tiene nombre o marca")
            {

            }
        }

        public class Beer
        {
            public string Name { get; set; }
            public string Brand { get; set; }

            public override string ToString()
            {
                if (Name == null || Brand == null)
                    throw new InvalidBeerException();

                return $"Cerveza: {Name}, Brand: {Brand}";
            }
        }

    }
}

