using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAuth.Controllers
{
    [ApiController]
    [Route("usuarios")]
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


            var usuario = UsuarioRepository.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "usuarioADM")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public IActionResult GetUsuarioADM(int id)
        {
            var usuario = UsuarioRepository.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }
    }
}
