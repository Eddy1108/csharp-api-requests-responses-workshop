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
        public IEnumerable<Car> GetCars()
        {
            return _carDatabase.GetCars();
        }
    }
}
