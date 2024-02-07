
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models.Cars;
using workshop.wwwapi.Models.Motorbikes;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("CarDb"));
builder.Services.AddScoped<IRepository<Motorbike>,Repository<Motorbike>>();
builder.Services.AddScoped<IRepository<Car>,Repository<Car>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureCarEndpoint();
app.ConfigureMotorbikeEndpoint();
app.ConfigureBoth();
string ColorName(string color) => $"Color specified: {color}!";

app.MapGet("/colorSelector/{color}", ColorName)
    .AddEndpointFilter(async (invocationContext, next) =>
    {
        var color = invocationContext.GetArgument<string>(0);

        if (color == "Red")
        {
            return Results.Problem("Red not allowed!");
        }
        return await next(invocationContext);
    });
app.MapGet("/seed", (IRepository<Motorbike> bikeRepository, IRepository<Car> carRepository) =>
{
    List<Motorbike> bikes = new List<Motorbike>()
    {
        new Motorbike(){ Make="KTM", Model="390 Adventure"},
        new Motorbike(){ Make="Yamaha", Model="XT660Z Tenere"}
    };

    List<Car> cars = new List<Car>()
    {
        new Car() { Make="Mini", Model="Clubman" },
        new Car() { Make="Mini", Model="One" },
        new Car() { Make="Mini", Model="Countryman" }
    };
    bikes.ForEach(bike => { bikeRepository.Insert(bike); });
    cars.ForEach(car => { carRepository.Insert(car); });
    return Results.Ok("Seeded database");
});

app.Run();

