
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {

        private DataContext _db;
        public Repository(DataContext db)
        {
           _db = db;
        }
        public Car UpdateCar(int id, CarPut carPut)
        {
            throw new NotImplementedException();
        }

        public Car AddCar(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
            return car;

        }

        public IEnumerable<Car> GetCars()
        {
            return _db.Cars.ToList();
        }

        public Car GetACar(int id)
        {
            var car = _db.Cars.FirstOrDefault(x => x.Id == id);
            return car;
        }
    }
}
