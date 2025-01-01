using Microsoft.AspNetCore.Mvc;
using minhasaulasnewbackend.Models;

namespace minhasaulasnewbackend.Controllers
{
    [ApiController]
    public class CheckerController(MinhasaulasContext context) : Controller
    {
        private readonly MinhasaulasContext _context = context;

        [HttpGet("checker")]
        public async Task<IActionResult> Checker()
        {
            try
            {
                var user = await _context.Usuarios.FindAsync(5);
                if (user == null) 
                {
                    return NotFound(new { data=false, server="server is not working" });
                }
                return Ok(new { data=true, server="server running successfully" });
            }
            catch (Exception error) 
            {
                BadRequest(error.Message);
            }
            
            return Ok(true);
        }
    }
}
