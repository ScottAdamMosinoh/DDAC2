using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DDAC2.Models
{
    public class ApplicationDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ApplicationDBContext() : base("name=DDAC2Context")
        {
        }

        public System.Data.Entity.DbSet<DDAC2.Models.Container> Containers { get; set; }

        public System.Data.Entity.DbSet<DDAC2.Models.Ship> Ships { get; set; }

        public System.Data.Entity.DbSet<DDAC2.Models.ShipYard> ShipYards { get; set; }

        public System.Data.Entity.DbSet<DDAC2.Models.Transport> Transports { get; set; }
    }
}
