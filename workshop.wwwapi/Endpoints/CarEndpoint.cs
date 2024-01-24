using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class CarEndpoint
    {
        public static void ConfigureCarEndpoint(this WebApplication app)
        {
            var carGroup = app.MapGroup("cars");

            carGroup.MapGet("/", GetCars);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCars(IRepository repository)
        {
            return TypedResults.Ok(repository.GetCars());
        }

    }
}
