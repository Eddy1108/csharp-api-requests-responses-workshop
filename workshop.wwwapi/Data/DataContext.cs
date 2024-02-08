using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using workshop.wwwapi.Models.Cars;
using workshop.wwwapi.Models.Motorbikes;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>().Navigation(x => x.Passengers).AutoInclude();
            
            modelBuilder.Entity<Motorbike>().HasData(
                new Motorbike { Id = 1, Make = "KTM", Model="390 Adventure" });
         
         
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorbike> Motorbikes { get; set; }
    }
}
