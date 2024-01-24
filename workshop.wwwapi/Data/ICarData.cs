using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public interface ICarData
    {
        IEnumerable<Car> GetCars();
    }
}
