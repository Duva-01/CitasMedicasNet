using AutoMapper;
using CitasMedicasNet.DTOs;
using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicasNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> getAllUsuarios()
        {

            _logger.LogInformation("Obteniendo todos los usuarios");

            IEnumerable<Usuario> usuarios = await _usuarioService.getUsuariosAsync();
            IEnumerable<UsuarioDTO> usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getUsuarioById(int id)
        {

            _logger.LogInformation("Obteniendo usuario con ID: {Id}", id);

            Usuario usuario = await _usuarioService.getUsuarioByIdAsync(id);

            if (usuario == null)
            {
                throw new NotFoundException($"Usuario con id {id} no encontrado.");
            }

            UsuarioDTO usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return Ok(usuarioDTO);
        }

        [HttpPost]
        public async Task<IActionResult> createUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            _logger.LogInformation("Creando un nuevo usuario");
            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            Usuario usuarioCreado = await _usuarioService.createUsuario(usuario);

            UsuarioDTO usuarioCreadoDTO = _mapper.Map<UsuarioDTO>(usuarioCreado);

            _logger.LogInformation("Usuario creado con ID: {Id}", usuarioCreadoDTO.id);
            return Ok(usuarioCreadoDTO);
        }

        [HttpPut]
        public async Task<IActionResult> updateUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            _logger.LogInformation("Actualizando usuario con ID: {Id}", usuarioDTO.id);
            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            Usuario usuarioActualizado = await _usuarioService.updateUsuario(usuario);

            UsuarioDTO usuarioActualizadoDTO = _mapper.Map<UsuarioDTO>(usuarioActualizado);

            _logger.LogInformation("Usuario actualizado con ID: {Id}", usuarioActualizadoDTO.id);

            return Ok(usuarioActualizadoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteUsuario(int id)
        {

            _logger.LogInformation("Eliminando usuario con ID: {Id}", id);

            bool result = await _usuarioService.deleteUsuario(id);

            if (!result)
            {
                throw new NotFoundException($"Usuario con id {id} no encontrado.");
            }

            _logger.LogInformation("Usuario con ID {Id} eliminado exitosamente", id);

            return Ok();

        }

        [HttpGet("searchByName")]
        public async Task<IActionResult> SearchByName(string nombre)
        {
            _logger.LogInformation("Buscando usuarios por nombre: {Nombre}", nombre);

            IEnumerable<Usuario> usuarios = await _usuarioService.getUsuariosByNameAsync(nombre);
            if (usuarios == null)
            {
                throw new NotFoundException($"No se encontraron usuarios con el nombre {nombre}.");
            }

            IEnumerable<UsuarioDTO> usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDTO);
        }

        [HttpGet("searchBySurName")]
        public async Task<IActionResult> SearchBySurName(string apellidos)
        {
            _logger.LogInformation("Buscando usuarios por apellidos: {Apellidos}", apellidos);

            IEnumerable<Usuario> usuarios = await _usuarioService.getUsuariosBySurNameAsync(apellidos);
            if (usuarios == null)
            {
                throw new NotFoundException($"No se encontraron usuarios con el apellido {apellidos}.");
            }

            IEnumerable<UsuarioDTO> usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDTO);
        }
    }

}
