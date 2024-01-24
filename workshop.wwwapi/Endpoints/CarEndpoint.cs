using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class CarEndpoint
    {
        public static void ConfigureCarEndpoint(this WebApplication app)
        {
            var carGroup = app.MapGroup("cars");

            carGroup.MapGet("/", GetCars);
            carGroup.MapPost("/", AddCar);
            carGroup.MapPut("/{id}", UpdateCar);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCars(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCars());
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddCar(IRepository repository, CarPost model)
        {
            //validate
            if(model == null)
            {
                
            }
            var newCar = new Car() { Make=model.Make, Model=model.Model};
            repository.AddCar(newCar);
            return TypedResults.Created($"/{newCar.Id}", newCar);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCar(IRepository repository, int id, CarPut model)
        {
            return TypedResults.Ok(repository.UpdateCar(id, model));
        }

    }
}
