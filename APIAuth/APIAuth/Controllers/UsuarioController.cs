using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIAuth.Controllers
{
    [ApiController]
    [Route("usuarios")]
    [Authorize(Policy = "ApiScope")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "usuario")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public IActionResult GetUsuarioID(int id)
        {
            var usuario = UsuarioRepository.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpGet]
        [Authorize(Roles = "usuario")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public IActionResult GetUsuario()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
                return NotFound();

            var usuario = UsuarioRepository.Usuarios.FirstOrDefault(u => u.ID == id);
             
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }


        [HttpGet("all/{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public IActionResult GetUsuarioADM(int id)
        {
            var usuario = UsuarioRepository.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpGet("all")]
        [Authorize(Policy = "SomenteAdmin1")]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), StatusCodes.Status200OK)]
        public IActionResult GetUsuarioAll()
        {
            var usuarios = UsuarioRepository.Usuarios;

            if (usuarios == null)
                return NotFound();

            return Ok(usuarios);
        }
    }
}
