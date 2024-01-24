using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private ICarData _carDatabase;

        public Repository(ICarData carDatabase)
        {
            _carDatabase = carDatabase;
        }
        public Car UpdateCar(int id, CarPut carPut)
        {
            var found = _carDatabase.GetCar(id, out Car car);
            if (!found)
            {
                return null;
            }

            car.Make = carPut.Make;
            car.Model = carPut.Model;
            return car;
        }

        public Car AddCar(Car car)
        {
            return _carDatabase.AddCar(car);
        }

        public IEnumerable<Car> GetCars()
        {
            return _carDatabase.GetCars();
        }
    }
}
