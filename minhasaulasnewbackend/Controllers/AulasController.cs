using Microsoft.AspNetCore.Mvc;
using minhasaulasnewbackend.Models;
using System.Text.Json;

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
                    // NotFound indica que o recurso não foi encontrado status 404
                    return NotFound(new { data = false, message = "Id inválido" });
                }
            }
            catch (Exception error) 
            { 
                // BadRequest indica algo de errado na solicitação status 400
                return BadRequest(error.Message);
            }

            try
            {
                var aulas = _context.Aulas.Where(a => a.UserId == userid);

                // Imprimir uma nova instancia de um objeto no Console
                string json = JsonSerializer.Serialize(aulas);
                Console.WriteLine(json);

                return Ok(aulas);

            } catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
