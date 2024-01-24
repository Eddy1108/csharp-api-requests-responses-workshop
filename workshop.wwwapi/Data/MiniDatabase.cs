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
    }
}
