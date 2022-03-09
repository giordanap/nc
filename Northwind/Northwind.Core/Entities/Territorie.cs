using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Northwind.Core.Entities
{
    public partial class Territorie
    {
        public Territorie()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritorie>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<EmployeeTerritorie> EmployeeTerritories { get; set; }
    }
}
