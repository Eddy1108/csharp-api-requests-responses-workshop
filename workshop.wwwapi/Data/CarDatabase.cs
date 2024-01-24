using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class CarDatabase
    {
        private static List<Car> _cars = new List<Car>()
        {
            new Car(){ Id=1, Make="Mini", Model="Clubman"},
            new Car(){ Id=2, Make="Mini", Model="One"},
            new Car(){ Id=3, Make="Mini", Model="Countryman"}

        };

        public List<Car> GetCars()
        {
            return _cars;
        }
    }
}
