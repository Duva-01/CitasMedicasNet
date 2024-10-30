using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasMedicasNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasNet.Repositories.Impl
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync() => await _context.Usuarios.ToListAsync();

        public async Task<Usuario> GetByIdAsync(int id) => await _context.Usuarios.FindAsync(id);

        public async Task AddAsync(Usuario entity)
        {
            await _context.Usuarios.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Usuario>> GetByNameAsync(string nombre)
        {
            return await _context.Usuarios
                .Where(u => u.nombre.Contains(nombre))
                .ToListAsync();

            /*
            
                return await _context.Usuarios
                    .FromSqlInterpolated($"SELECT * FROM Usuario WHERE nombre = {nombre}")
                    .ToListAsync();
        
             * */
        }

        public async Task<IEnumerable<Usuario>> GetBySurNameAsync(string apellidos)
        {
            return await _context.Usuarios
                .Where(u => u.apellidos.Contains(apellidos))
                .ToListAsync();
        }
    }
}
