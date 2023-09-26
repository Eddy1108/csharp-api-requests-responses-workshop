using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    public class Pet
    {
        public int Id { get; set; }              
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        
    }
}
