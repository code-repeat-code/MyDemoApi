using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
       
       /*
        private static List<SuperHero> heros = new List<SuperHero>
            {
                new SuperHero { id = 1, Name = "Shatiman", FirstName = "Shakti", LastName = "Maan" , Place = "Delhi" },
                new SuperHero { id = 2, Name = "SuperMan", FirstName = "Luther", LastName = "Martin" , Place = "USA" },
                new SuperHero { id = 3, Name = "SpiderMan", FirstName = "Peter", LastName = "Parker" , Place = "Los Angeles" }

            };
       */
        

        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<SuperHeroController>
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get() {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        // GET api/<SuperHeroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null) {
                return BadRequest("Hero not found");
            }
            return Ok(hero);
        }

        // POST api/<SuperHeroController>
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Post([FromBody] SuperHero hero)
        {
            var addedHero = await _context.SuperHeroes.AddAsync(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        // PUT api/<SuperHeroController>/5
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Put(SuperHero superHero)
        {
            var hero = await _context.SuperHeroes.FindAsync(superHero.id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            hero.Name = superHero.Name;
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.Place = superHero.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        // DELETE api/<SuperHeroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null) {
                return BadRequest("You cannot deleted becuase hero does not exist");
            }
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
                
        }
    }
}
