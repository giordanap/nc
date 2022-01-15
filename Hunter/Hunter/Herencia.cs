using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL
{
    class Herencia
    {
        public void OutPut()
        {
            Doctor doctor1 = new Doctor("Juan", 40, "Cardiologo");
            Console.WriteLine(doctor1.GetInfo());
            Console.WriteLine(doctor1.GetData());
        }

        class People
        {
            private string _name;
            private int _age;

            public People(string name, int age)
            {
                _name = name;
                _age = age;
            }

            public string GetInfo()
            {
                return _name + " " + _age;
            }
        }

        class Doctor : People
        {
            private string _speciality;

            // para poder enviarle los valores por herencia al padre
            public Doctor(string name, int age, string speciality) : base(name, age)
            {
                _speciality = speciality;
            }

            public string GetData()
            {
                return GetInfo() + " " + _speciality;
            }
        }
    }
}
