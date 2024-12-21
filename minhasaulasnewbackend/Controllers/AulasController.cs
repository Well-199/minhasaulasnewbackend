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
                var user = _context.Usuarios.Find(userid);
                if (user == null) 
                {
                    return Ok(new { data = false, message = "Id inválido" });
                }
            }
            catch (Exception error) 
            { 
                return BadRequest(error.Message);
            }

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
