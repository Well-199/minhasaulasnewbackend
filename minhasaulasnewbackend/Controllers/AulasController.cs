using Microsoft.AspNetCore.Mvc;
using minhasaulasnewbackend.Models;
using System.Text.Json;

namespace minhasaulasnewbackend.Controllers
{   
    [ApiController]
    public class AulasController(MinhasaulasContext context) : Controller
    {
        private readonly MinhasaulasContext _context = context;

        /// <summary>
        /// Lista de aulas.
        /// </summary>
        /// <remarks>
        /// Lista todas as aulas de um professor pelo id
        /// </remarks>
        /// <param name="userid">ID do registro do professor no banco de dados</param>
        /// <returns></returns>
        /// <response code="200">Lista retornada com sucesso mesmo que vazia</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="500">Retorna erros no servidor</response>
        [HttpGet("all/class/{userid}")]
        public async Task<IActionResult> GetAulasById([FromRoute] int userid)
        {
            try
            {
                var user = await _context.Usuarios.FindAsync(userid);
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
