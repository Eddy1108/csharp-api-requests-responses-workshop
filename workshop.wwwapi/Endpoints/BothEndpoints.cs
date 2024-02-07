using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.Cars;
using workshop.wwwapi.Models.DTO;
using workshop.wwwapi.Models.Motorbikes;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class BothEndpoints
    {
        public static void ConfigureBoth(this WebApplication app)
        {
            var bothGroup = app.MapGroup("both");
            bothGroup.MapGet("/", GetAll);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Car> carRepository, IRepository<Motorbike> bikeRepository)
        {
            DoublePayload<IEnumerable<Car>, IEnumerable<Motorbike>> result = new Models.DTO.DoublePayload<IEnumerable<Car>, IEnumerable<Motorbike>>();
            result.dataOne = await carRepository.Get();
            result.dataTwo = await bikeRepository.Get();
            return TypedResults.Ok(result);
        }
    }
}
