# C# API Request Responses & Open API

dotnet new sln --name workshop
dotnet new webapi --name workshop.wwwapi
dotnet sln add **/*.csproj


 install-package microsoft.entityframeworkcore.inmemory

 ```cs
 public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
    }

 ```


 ```
 builder.Services.AddDbContext<CarContext>(opt => opt.UseInMemoryDatabase("CarDb"));
 ```
