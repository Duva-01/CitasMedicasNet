using CitasMedicasNet.Models;

namespace CitasMedicasNet.Services
{
    public interface IUsuarioService
    {
        public abstract Task<IEnumerable<Usuario>> getUsuariosAsync();

        public abstract Task<Usuario> getUsuarioByIdAsync(int id);

        public abstract Task<Usuario> createUsuario(Usuario usuario);

        public abstract Task<Usuario> updateUsuario(Usuario usuario);

        public abstract Task<bool> deleteUsuario(int id);
    }
}
