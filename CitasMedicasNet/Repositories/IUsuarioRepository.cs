using System.Collections.Generic;
using System.Threading.Tasks;
using CitasMedicasNet.Models;

namespace CitasMedicasNet.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetByNameAsync(string nombre);

        Task<IEnumerable<Usuario>> GetBySurNameAsync(string apellidos);
    }
}
