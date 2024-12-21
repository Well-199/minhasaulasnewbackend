using Microsoft.AspNetCore.Mvc;
using minhasaulasnewbackend.Models;

namespace minhasaulasnewbackend.Controllers
{
    [ApiController]
    public class CheckerController(MinhasaulasContext context) : Controller
    {
        private readonly MinhasaulasContext _context = context;

        [HttpGet("checker")]
        public IActionResult Checker()
        {
            try
            {
                var user = _context.Usuarios.Find(5);
                if (user == null) 
                {
                    return NotFound(new { data=false, server="server is not working" });
                }
                return Ok(new { data=true, server="server running successfully" });
            }
            catch (Exception ex) 
            {
                BadRequest(ex.Message);
            }
            
            return Ok(true);
        }
    }
}
