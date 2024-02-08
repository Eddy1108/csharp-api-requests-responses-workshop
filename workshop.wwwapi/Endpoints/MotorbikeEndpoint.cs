using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.DTO;
using workshop.wwwapi.Models.Motorbikes;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class MotorbikeEndpoint
    {
        public static void ConfigureMotorbikeEndpoint(this WebApplication app)
        {
            var motorbikeGroup = app.MapGroup("motorbikes");

            motorbikeGroup.MapGet("/", GetMotorbikes);
            motorbikeGroup.MapGet("/{id}", GetAMotorbike);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetMotorbikes(IRepository<Motorbike> repository)
        {
            O
            return TypedResults.Ok(repository.Get());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAMotorbike(IRepository<Motorbike> repository, int id)
        {
            return TypedResults.Ok(repository.GetById(id));
        }

    }
}
