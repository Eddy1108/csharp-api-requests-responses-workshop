using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public interface ICarData
    {
        IEnumerable<Car> GetCars();
        Car AddCar(Car car);
        Car UpdateCar(int id, CarPut car);
        bool GetCar(int id, out Car car);
       
    }
}
