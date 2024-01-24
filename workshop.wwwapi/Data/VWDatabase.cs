using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class VWDatabase : ICarData
    {
        private static List<Car> _cars = new List<Car>()
        {
            new Car(){ Id=1, Make="VW", Model="Up"},
            new Car(){ Id=2, Make="VW", Model="Down"},
            new Car(){ Id=3, Make="VW", Model="Beetle"}

        };
        public IEnumerable<Car> GetCars()
        {
            return _cars;
        }
    }
}
