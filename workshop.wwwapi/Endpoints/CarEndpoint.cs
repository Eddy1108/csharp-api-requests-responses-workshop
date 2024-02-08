using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models.Cars;
using workshop.wwwapi.Models.DTO;
using workshop.wwwapi.Models.Motorbikes;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class CarEndpoint
    {
        public static void ConfigureCarEndpoint(this WebApplication app)
        {
            var carGroup = app.MapGroup("cars");

            carGroup.MapGet("/", GetCars);
            carGroup.MapPost("/", AddCar).AddEndpointFilter(async (invocationContext, next) =>
            {
                var car = invocationContext.GetArgument<CarPost>(1);

                if (string.IsNullOrEmpty(car.Make) || string.IsNullOrEmpty(car.Model))
                {
                    return Results.BadRequest("You must enter a Make AND Model");
                }
                return await next(invocationContext);
            }); ;
            carGroup.MapPut("/{id}", UpdateCar);
            carGroup.MapGet("/{id}", GetACars);
            carGroup.MapDelete("/{id}", DeleteCar);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCar(IRepository<Car> repository, int id)
        {
            var car = await repository.GetById(id);
            if (car==null)
            {
                return TypedResults.NotFound("Car not found.");
            }
            var result = repository.Delete(id);
            return result != null ? TypedResults.Ok(result) : Results.NotFound();
        }





        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCars(IRepository<Car> carRepository)
        {
            var results = await carRepository.Get();
            Payload<IEnumerable<Car>> payload = new Payload<IEnumerable<Car>>();
            payload.data = results;
            return TypedResults.Ok(payload);
        }













        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetACars(IRepository<Car> repository, int id)
        {
            return TypedResults.Ok(repository.GetById(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddCar(IRepository<Car> repository, CarPost model)
        {
            var cars = await repository.Get();
            
            if (cars.Any(x => x.Model.Equals(model.Model, StringComparison.OrdinalIgnoreCase)))
            {
                return Results.BadRequest("Product with provided name already exists");
            }
            
            var entity = new Car() { Make=model.Make, Model=model.Model};
            repository.Insert(entity);
            return TypedResults.Created($"/{entity.Id}", entity);
         
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> UpdateCar(IRepository<Car> repository, int id, CarPut model)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound("Product not found.");
            }
           
            var cars = await repository.Get();

            if (model.Model != null)
            {
                if (cars.Any(x => x.Model == model.Model))
                {
                    return Results.BadRequest("Product with provided name already exists");
                }
            }
            entity.Make = model.Make != null ? model.Make : entity.Make;
            entity.Model = model.Model != null ? model.Model : entity.Model;
            
            repository.Update(entity);

            return TypedResults.Created($"/{entity.Id}", entity);

        }

    }
}
