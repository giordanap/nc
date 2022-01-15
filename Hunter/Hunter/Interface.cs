using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class Interface
    {
        public void OutPut()
        {
            Shark[] sharks = new Shark[]
            {
                new Shark("Hunter", 25),
                new Shark("Tiburoncin", 32)
            };

            // Los elementos del arreglos cumplen con el contrato
            IFish[] fishs = new IFish[]
            {
                new Siren(100),
                new Shark("Tiburoncin", 32)
            };

            // Las interfaces no sirven para crear objetos
            // sirven para categorizar a los objetos

            ShowFish(sharks);
            ShowAnimals(sharks);
            ShowFish(fishs);
        }

        // el los parámetros se especifica que lineas arriba se debe
        // implementar la interfaz pero en el parentesis donde van los
        // parametros se especifica la interfaz a implementar, pero 
        // si quisieras implementar varias interfaces, entonces se
        // sugiere usar una interzas que herede de varias interfaces.
        public static void ShowAnimals(IAnimal[] animals)
        {
            Console.WriteLine("- Mostramos los animales --");
            int i = 0;
            while (i < animals.Length)
            {
                Console.WriteLine(animals[i].Name);
                i++;
            }

        }

        public static void ShowFish(IFish[] fishs)
        {
            Console.WriteLine("- Mostramos los peces --");
            int i = 0;
            while (i < fishs.Length)
            {
                Console.WriteLine(fishs[i].Swim());
                i++;
            }

        }

        public class Siren: IFish
        {
            public int Speed { get; set; }

            public Siren(int speed)
            {
                this.Speed = speed;
            }

            public string Swim()
            {
                return $"La Sirena nada a {Speed}km/h";
            }
        }

        public class Shark : IAnimal, IFish
        {
            public string Name { get; set; }
            public int Speed { get; set; }

            public string Swim()
            {
                return $"{Name} Nada {Speed} Km/h";
            }

            public Shark(string name, int speed)
            {
                this.Name = name;
                this.Speed = speed;
            }
        }

        public interface IAnimal
        {
            public string Name { get; set; }
        }

        public interface IFish
        {
            public int Speed { get; set; }

            public string Swim();
            
        }

        // Una interfaz es como un contrato, que cuando una clase quiere
        // implementar entonces debe respetar el contrato. Los contratos
        // tienen anexos, lo que vendria a ser en POO las propiedades y
        // métodos.
        
        // Dato adicional: es la base de patrones de diseño

        // 1. Tiene como fin darle un comportamiento o una categoría a una clase
        // pero que esta categoria no sea solo una. Cuando se hereda, solo se
        // puede heredar una vez (de otra clase), pero podemos implementar las
        // interfaces que queremos
    }
}
