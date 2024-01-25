using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorbike> Motorbikes { get; set; }
    }
}
