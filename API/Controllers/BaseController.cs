using Microsoft.AspNetCore.Mvc;
using Persistence;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            var hello = "Welcome. To use the api log in at \"/api/Users/login\" and make requests to \"/api/Questionnaires\" \n " +
                "Have a nice day!";
            return Ok(hello);
        }
    }
}
