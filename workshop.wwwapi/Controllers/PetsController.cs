using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private static List<Pet> _pets = new List<Pet>();
        public PetsController()
        {
            if(_pets.Count==0)
            {
                _pets.Add(new Pet() { Id = 1, Name = "Bella", Description = "A Fluffy Black Cat", Age = 1 });
                _pets.Add(new Pet() { Id = 2,Name = "Red", Description = "A Fluffy Black & White Cat", Age = 1 });
                _pets.Add(new Pet() { Id = 3, Name = "Stitch", Description = "A Fluffy Black Dog", Age = 5 });
                _pets.Add(new Pet() { Id = 4, Name = "Lola", Description = "A Fluffy White Dog", Age = 2 });
            }
            
        }
        //get
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetPets()
        {
            return Results.Ok(_pets);
        }


        //post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> AddPet(Pet pet)
        {
            //int id = _pets.Count + 1; //? 
            int id = _pets.Max(x => x.Id) +1;
            pet.Id = id;
            _pets.Add(pet);
            return Results.Ok(pet);
        }



        //get{id}
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> GetAPet(int id)
        {            
            var pet = _pets.Where(p => p.Id == id).FirstOrDefault();
            return pet!=null ? Results.Ok(pet) : Results.NotFound();
        }


        //delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> DeleteAPet(int id)
        {
            var pet = _pets.Where(p => p.Id == id).FirstOrDefault();
            int result = _pets.RemoveAll(p => p.Id == id);
            return result >= 0 && pet!=null ? Results.Ok(pet) : Results.NotFound();
        }

        //TODO: work in progress....
        //httpput
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> Update(int id, Pet pet)
        {
            //get item to update
            var item = _pets.Where(x => x.Id == id).FirstOrDefault();
            
            if (item == null) return Results.NotFound();

            item.Name           = string.IsNullOrEmpty(pet.Name) ? item.Name : pet.Name;
            item.Description    = string.IsNullOrEmpty(pet.Description)? item.Description : pet.Description;
            item.Age            = pet.Age == 0 ? item.Age : pet.Age;
                        
            return Results.Ok(item);
        }

    }
}
