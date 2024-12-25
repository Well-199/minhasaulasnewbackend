using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minhasaulasnewbackend.Models;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace minhasaulasnewbackend.Controllers
{
    [ApiController]
    public class LoginController(MinhasaulasContext context) : Controller
    {
        private readonly MinhasaulasContext _context = context;

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Usuario usuario)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);
                if (user == null)
                {
                    return NotFound(new { data=false, error="e-mail/ou senha inválidos" });
                }

                var hash = user.Senha;
                var password = usuario.Senha.ToString();

                // Dividir o hash em salt e chave armazenada
                var parts = hash.Split(':');
                if (parts.Length != 2)
                {
                    return NotFound(new { data = false, error = "e-mail/ou senha inválidos" });
                }

                string storedSalt = parts[0];
                string storedKey = parts[1];

                var saltKey = Environment.GetEnvironmentVariable("SALT_KEY");

                // Verificar se o salt do hash corresponde ao fornecido
                if (storedSalt != saltKey)
                {
                    throw new InvalidOperationException("Salt inválido.");
                }

                // Derivar a chave a partir da senha e do salt fixo
                var derivedKey = await Task.Run(() =>
                {
                    // Esse método pode ser usado para gerar o hash no cadastro
                    using var pbkdf2 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(saltKey), 1000, HashAlgorithmName.SHA512);
                    return BitConverter.ToString(pbkdf2.GetBytes(64)).Replace("-", "").ToLower(); // Retorna chave em hexadecimal
                });

                if(storedKey == derivedKey)
                {
                    int size = 32;
                    byte[] randomBytes = new byte[size];
                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(randomBytes);
                    }
                    string token = BitConverter.ToString(randomBytes).Replace("-", "").ToLower(CultureInfo.CurrentCulture);

                    user.Token = token; // Atualizar o token
                    await _context.SaveChangesAsync();

                    return Ok(new { data = true, userid = user.Id, token });
                }

                return Ok(new { data = false, error = "e-mail/ou senha inválidos" });

            } catch (Exception error)
            {
                return BadRequest(error.Message);
            }
  
        }
    }
}
