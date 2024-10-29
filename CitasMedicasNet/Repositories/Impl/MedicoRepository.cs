using CitasMedicasNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasNet.Repositories.Impl
{
    public class MedicoRepository : IRepository<Medico>
    {
        private readonly AppDbContext _context;

        public MedicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> GetAllAsync() => await _context.Medicos.ToListAsync();

        public async Task<Medico> GetByIdAsync(int id) => await _context.Medicos.FindAsync(id);

        public async Task AddAsync(Medico entity)
        {
            await _context.Medicos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medico entity)
        {
            _context.Medicos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return false;
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
