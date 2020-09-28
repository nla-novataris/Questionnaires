using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly DataContext _context;
        public ApiController(DataContext context)
        {
            _context = context;
        }

        // GET /
        [HttpGet]
        public ActionResult<IEnumerable<Value>> Get()
        {
            // var values = await _context.Values.ToListAsync();
            var hello = "hello 2";
            return Ok(hello);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Value> Get(int id)
        {
            //var value = await _context.Values.FindAsync(id);
            //return Ok(value);
            var hello = "hello";
            return Ok(hello);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
