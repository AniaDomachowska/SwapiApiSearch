using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarwarsApi.Controllers
{
    [Route("api/People")]
    [EnableCors("AllowAll")]
    public class PeopleController : Controller
    {
        private readonly IStarWarsProvider starwarsProvider;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PeopleController(IStarWarsProvider starWarsProvider, IHttpContextAccessor httpContextAccessor)
        {
            starwarsProvider = starWarsProvider;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IQueryable<Person> Get()
        {
            var search = httpContextAccessor.HttpContext.Request.Query["search"];
            var people = starwarsProvider.GetPeople(search);
            return people;
        }

        [HttpGet("{id}")]
        public Person Get([FromRoute]int id)
        {
            return starwarsProvider.GetPerson(id);
        }

        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            return BadRequest("You cannot delete people from StarWars!");
        }


        [HttpPut()]
        public IActionResult Put(Person person)
        {
            
            return BadRequest("Put is not supported.");
        }

        [HttpPost()]
        public IActionResult Post(Person person)
        {
            return BadRequest("Post is not supported.");
        }
    }
}