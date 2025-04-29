using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAuth.Controllers
{
    [ApiController]
    [Route("usuarios")]
    #region segredo 02
    //[Authorize(Policy = "ApiScope")]
    #endregion
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        #region segredo 01
        //[Authorize]
        #endregion
        #region segredo 03
        //[Authorize(Roles = "usuario")]
        #endregion
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
            if (!int.TryParse(User.FindFirst("sub")?.Value, out int id))
                return NotFound();

            var usuario = UsuarioRepository.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }


        [HttpGet("/usuario/{id}")]
        [Authorize(Roles = "usuarioADM")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public IActionResult GetUsuarioADM(int id)
        {
            var usuario = UsuarioRepository.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpGet("all")]
        [Authorize(Policy = "SomenteAdmin")]
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
