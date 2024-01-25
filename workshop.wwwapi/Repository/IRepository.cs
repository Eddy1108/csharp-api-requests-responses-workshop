using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Car> GetCars();
        Car AddCar(Car car);
        Car UpdateCar(int id, CarPut carPut);
        Car GetACar(int id);

    }
}
