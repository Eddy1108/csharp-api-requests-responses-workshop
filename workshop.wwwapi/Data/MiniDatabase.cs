using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class MiniDatabase : ICarData
    {
        private static List<Car> _cars = new List<Car>()
        {
            new Car(){ Id=1, Make="Mini", Model="Clubman"},
            new Car(){ Id=2, Make="Mini", Model="One"},
            new Car(){ Id=3, Make="Mini", Model="Countryman"}

        };

        public IEnumerable<Car> GetCars()
        {
            return _cars;
        }
        public Car AddCar(Car car)
        {
            car.Id = _cars.Max(car => car.Id) + 1;
            _cars.Add(car);
            return car;
        }

        public Car UpdateCar(int id, CarPut car)
        {
            var target = _cars.FirstOrDefault(car => car.Id == id);
            target.Make = car.Make;
            target.Model = car.Model;
            return target;
        }

        public bool GetCar(int id, out Car car)
        {
            car = _cars.FirstOrDefault(car => car.Id == id);
            
            if(car==null)
            {
                return false;
            }

            return true;
        }
    }
}
