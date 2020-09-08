using Rent.WebAPI.Persistence.Models;
using System.Data.Entity;

namespace Rent.WebAPI.Persistence
{
    public class RentContext : DbContext
    {
        public RentContext() : base("Server= (localdb)\\ProjectsV13;Database=Rent_DB;Integrated Security=True;")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Bill> Bills { get; set; }

    }
}