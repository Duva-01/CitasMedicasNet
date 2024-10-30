using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Repositories;

namespace CitasMedicasNet.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioService> _logger;


        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Usuario>> getUsuariosAsync()
        {
            try
            {
                return await _usuarioRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Error al obtener los usuarios. Excepcion: " + ex.Message);
            }
        }

        public async Task<Usuario> getUsuarioByIdAsync(int id)
        {
            try
            {
                return await _usuarioRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> createUsuario(Usuario usuario)
        {
            try
            {
                await _usuarioRepository.AddAsync(usuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> updateUsuario(Usuario usuario)
        {
            try
            {
                await _usuarioRepository.UpdateAsync(usuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteUsuario(int id)
        {
            try
            {
                bool result = await _usuarioRepository.DeleteAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al intentar eliminar un usuario: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Usuario>> getUsuariosByNameAsync(string nombre)
        {
            try
            {
                return await _usuarioRepository.GetByNameAsync(nombre);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al buscar usuarios por nombre: {Message}", ex.Message);
                throw new Exception("Error al buscar usuarios por nombre. Consulta los logs para más detalles.");
            }
        }


        public async Task<IEnumerable<Usuario>> getUsuariosBySurNameAsync(string apellidos)
        {
            try
            {
                return await _usuarioRepository.GetBySurNameAsync(apellidos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar usuarios por apellidos: " + ex.Message);
            }
        }
    }
}
