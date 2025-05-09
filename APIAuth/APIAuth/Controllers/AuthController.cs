using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIAuth.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public IActionResult Token([FromForm] string email, [FromForm] string senha)
        {
            var usuario = UsuarioRepository.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
                return Unauthorized(new { mensagem = "Usuário ou senha inválidos" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("chave-super-secreta-para-desenvolvimento");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("sub", usuario.ID.ToString()),
                new Claim("name", usuario.Nome),
                new Claim("email", usuario.Email),
                new Claim("scope", "teste"),
                new Claim(ClaimTypes.Role, "usuario"),
                new Claim(ClaimTypes.Role, "admin"),
            }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(new { access_token = jwt });
        }
    }
}
