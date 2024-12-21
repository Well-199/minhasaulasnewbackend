using Microsoft.AspNetCore.Mvc;
using minhasaulasnewbackend.Models;

namespace minhasaulasnewbackend.Controllers
{
    [ApiController]
    public class AulasController(MinhasaulasContext context) : Controller
    {
        private readonly MinhasaulasContext _context = context;

        [HttpGet("all/class/{userid}")]
        public IActionResult GetAulasById([FromRoute] int userid)
        {
            try
            {
                var aulas = _context.Aulas.Where(a => a.UserId == userid);
                return Ok(aulas);

            } catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
