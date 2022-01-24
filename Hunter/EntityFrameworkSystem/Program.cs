using BD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // La desventaja principal de EF es que tarda con consultas masivas

            // Esto me permite entregar la cadena de conexion, así ya no sera
            // por defecto y no entrara en el condicional de la clase
            // CsharpDBContext
            DbContextOptionsBuilder<CsharpDBContext> optionsBuilder =
                new DbContextOptionsBuilder<CsharpDBContext>();
            optionsBuilder.UseSqlServer("Server=GIORDAN-PC; Database=CsharpDB; Trusted_Connection=True;");

            // Crea un universo unico de existencia de mis datos
            // Asi using crea el dispose por ti
            // Using solo trabaja con clases que implementen el
            // metodo dispose
            //using (CsharpDBContext context = new CsharpDBContext(optionsBuilder.Options))
            //{
            //    var beers = context.Beers.ToList();

            //    foreach (var beer in beers)
            //    {
            //        Console.WriteLine(beer.Name);
            //    }
            //}

            bool again = true;
            int op = 0;

            do
            {
                ShowMenu();

                Console.WriteLine("Elige una opcion: ");
                op = int.Parse(Console.ReadLine());

                switch (op) 
                {
                    case 1:
                        Show(optionsBuilder);
                        break;
                    case 2:
                        Add(optionsBuilder);
                        break;
                    case 3:
                        Edit(optionsBuilder);
                        break;
                    case 4:
                        Delete(optionsBuilder);
                        break;
                    case 5:
                        again = false;
                        break;
                }
            } while (again);
 
        }

        public static void Show(DbContextOptionsBuilder<CsharpDBContext> optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Cervezas de la base de datos:");
            using (var context = new CsharpDBContext(optionsBuilder.Options))
            {

                //List<Beer> beers = context.Beers.ToList();
                // Hacemos uso de la expresion Lamda
                // Include hace un join con la marca
                //List<Beer> beers = context.Beers.OrderBy(b=>b.Name).ToList();
                List<Beer> beers2 = (from b in context.Beers
                                     where b.BrandId == 2
                                     orderby b.Name
                                     select b).Include(b=>b.Brand).ToList();

                foreach (var beer in beers2)
                {
                    Console.WriteLine($"Id: {beer.Id} Nombre: {beer.Name} Marca: {beer.Brand}");
                }
            }
        }

        public static void Add(DbContextOptionsBuilder<CsharpDBContext> optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Agregar nueva cerveza");
            Console.WriteLine("Escriba el nombre:");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe el id de la marca:");
            int brandId = int.Parse(Console.ReadLine());

            using (var context = new CsharpDBContext(optionsBuilder.Options))
            {
                Beer beer = new Beer()
                {
                    Name = name,
                    BrandId = brandId
                };

                context.Add(beer);
                context.SaveChanges();
            }

        }

        public static void Edit(DbContextOptionsBuilder<CsharpDBContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Editar Cerveza");
            Console.WriteLine("Escribe el id de tu cerveza a editar: ");
            int id = int.Parse(Console.ReadLine());

            using (var context = new CsharpDBContext(optionsBuilder.Options))
            { 
           
                Beer beer = context.Beers.Find(id);
                if (beer != null)
                {
                    Console.WriteLine("Escribe el nombre: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Escribe el id de la marca: ");
                    int brandId = int.Parse(Console.ReadLine());

                    beer.Name = name;
                    beer.BrandId = brandId;
                    context.Entry(beer).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("La cerveza no existe");
                }
            }

        }

        public static void Delete(DbContextOptionsBuilder<CsharpDBContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Eliminar Cerveza");
            Console.WriteLine("Escribe el id de tu cerveza a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (var context = new CsharpDBContext(optionsBuilder.Options))
            { 
                Beer beer = context.Beers.Find(id);
                if (beer != null)
                {
                    context.Beers.Remove(beer);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("La cerveza no existe");
                }
            
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n-------Menu-------");
            Console.WriteLine("1.- Mostrar");
            Console.WriteLine("2.- Agregar");
            Console.WriteLine("3.- Editar");
            Console.WriteLine("4.- Eliminar");
            Console.WriteLine("5.- Salir");
        }
    }
}
