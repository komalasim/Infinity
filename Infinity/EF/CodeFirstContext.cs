using Infinity.Models;
using System.Data.Entity;

namespace Infinity.EF
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext():base("name=Infinity")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}