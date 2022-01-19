using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL.LearningCS.VII.BaseDeDatos
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

        public Beer(int id, string name, int brandId)
        {
            this.Id = id;
            this.Name = name;
            this.BrandId = brandId;
        }

        // Como el Id se genera automaticamente en la BD
        // creamos otro constructor para poder insertar
        public Beer(string name, int brandId)
        {
            this.Name = name;
            this.BrandId = brandId;
        }

    }
}
