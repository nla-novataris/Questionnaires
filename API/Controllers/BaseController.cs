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
        public ActionResult Get()
        {
            var hello = "hello 1";
            return Ok(hello);
        }
    }
}
