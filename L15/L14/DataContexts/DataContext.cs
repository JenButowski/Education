using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using L15.DataModels;

namespace L15.DataContexts
{
    public class DataContext : DbContext
    {
        public DbSet<CarOwner> Owners { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Violation> Violations { get; set; }

        public DbSet<ViolationType> ViolationTypes { get; set; }

        public DataContext() : base("DbContext")
        { }
    }
}
