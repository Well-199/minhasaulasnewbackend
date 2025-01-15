using Microsoft.AspNetCore.Mvc;
using minhasaulasnewbackend.Models;

namespace minhasaulasnewbackend.Controllers
{
    [ApiController]
    public class CheckerController(MinhasaulasContext context) : Controller
    {
        private readonly MinhasaulasContext _context = context;

        /// <summary>
        /// Verifica se o servidor esta rodando e a conexão com o banco de dados
        /// </summary>
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
