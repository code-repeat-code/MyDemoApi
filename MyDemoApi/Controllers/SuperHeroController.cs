using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
       private static List<SuperHero> heros = new List<SuperHero>
            {
                new SuperHero { id = 1, Name = "Shatiman", FirstName = "Shakti", LastName = "Maan" , Place = "Delhi" },
                new SuperHero { id = 2, Name = "SuperMan", FirstName = "Luther", LastName = "Martin" , Place = "USA" },
                new SuperHero { id = 3, Name = "SpiderMan", FirstName = "Peter", LastName = "Parker" , Place = "Los Angeles" }

            };
        // GET: api/<SuperHeroController>
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get() {
            return Ok(heros);
        }

        // GET api/<SuperHeroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = heros.Find(_ => _.id == id);
            if (hero == null) {
                return BadRequest("Hero not found");
            }
            return Ok(hero);
        }

        // POST api/<SuperHeroController>
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Post([FromBody] SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }

        // PUT api/<SuperHeroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuperHeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
