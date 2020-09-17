using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("/")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly DataContext _context;
        public Controller(DataContext context)
        {
            _context = context;
        }

        // GET /
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            // var values = await _context.Values.ToListAsync();
            var hello = "hello 1";
             return Ok(hello);
        }
    }
}
