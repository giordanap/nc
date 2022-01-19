using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class Generic
    {
        public void OutPut()
        {
            Mylist<int> numbers = new Mylist<int>(10);
            numbers.Add(10);
            numbers.Add(6);

            Mylist<string> strings = new Mylist<string>(10);
            strings.Add("Babel");
            strings.Add("Chepingo");

            Mylist<People> people = new Mylist<People>(5);
            people.Add(new People() { Name = "Hunter", Country = "Aleman"});
            people.Add(new People() { Name = "Chata", Country = "Peru" });

            Console.WriteLine(numbers.GetString());
            Console.WriteLine(strings.GetString());
            Console.WriteLine(people.GetString());

            Console.WriteLine(numbers.GetElement(11));
            Console.WriteLine(strings.GetElement(0));


        }

        // Nos va a servir para reutilizar codigo
        // La clase va a tener la posibilidad de recibir un tipo de dato

        public class People
        {
            public string Name { get; set; }
            public string Country { get; set; }

            // si usamos el GetString usará el ToString, pero por defecto
            // usará el método de object. Podemos sobreescribir el metodo
            // porque es virtual.

            public override string ToString()
            {
                return $"Nombre: {Name}, Pais: {Country}";
            }
        }

        public class Mylist<T>
        {
            private T[] _elements;
            private int _index = 0;

            public Mylist(int n)
            {
                _elements = new T[n];
            }

            public void Add(T e)
            {
                if (_index < _elements.Length)
                {
                    _elements[_index] = e;
                    _index++;
                }
            }

            public T GetElement(int i)
            {
                if (i <= _index && i >= 0)
                {
                    return _elements[i];
                }

                return default(T);
            }

            public string GetString()
            {
                int i = 0;
                string result = "";

                while (i < _index)
                {
                    result += _elements[i].ToString() + "|";
                    i++;
                }

                return result;
            }
        }
    }
}
