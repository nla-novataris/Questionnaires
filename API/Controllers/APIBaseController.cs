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

        [HttpGet]
        public ActionResult Get()
        {
            // var values = await _context.Values.ToListAsync();
            var hello = "hello 2";
            return Ok(hello);
        }
    }
}
