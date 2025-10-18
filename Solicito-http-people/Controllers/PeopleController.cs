using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("All")] // All regresa todas las personas
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public People Get(int id) => Repository.People.First(p => p.Id == id); // Función de primera clase
                                                                               // First invoca a todo el listado 
        [HttpGet("search/{search}")]
        public List<People> Get(string search) => 
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

    }

    public class Repository  // Para simular database, lista de personas 
    {
        public static List<People> People = new List<People>
        {
            new People ()
            {
                Id = 1,
                Name = "Mamita",
                Birthdate = new DateTime(1999, 12, 2)
            },
            new People ()
            {
                Id = 2,
                Name = "Teresita",
                Birthdate = new DateTime(2000, 12, 2)
            },
            new People ()
            {
                Id = 3,
                Name = "Messo",
                Birthdate = new DateTime(2021, 12, 2)
            },
            new People ()
            {
                Id = 4,
                Name = "Delegada",
                Birthdate = new DateTime(2022, 12, 2)
            }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
