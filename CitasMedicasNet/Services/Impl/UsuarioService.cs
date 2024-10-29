using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Repositories;

namespace CitasMedicasNet.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
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
    }
}
