using CitasMedicasNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasNet.Repositories.Impl
{
    public class CitaRepository : IRepository<Cita>
    {
        private readonly AppDbContext _context;

        public CitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cita>> GetAllAsync() => await _context.Citas.ToListAsync();

        public async Task<Cita> GetByIdAsync(int id) => await _context.Citas.FindAsync(id);

        public async Task AddAsync(Cita entity)
        {
            await _context.Citas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cita entity)
        {
            _context.Citas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return false;
            }

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
