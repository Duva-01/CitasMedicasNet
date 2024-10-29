using CitasMedicasNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasNet.Repositories.Impl
{
    public class DiagnosticoRepository : IRepository<Diagnostico>
    {
        private readonly AppDbContext _context;

        public DiagnosticoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Diagnostico>> GetAllAsync() => await _context.Diagnosticos.ToListAsync();

        public async Task<Diagnostico> GetByIdAsync(int id) => await _context.Diagnosticos.FindAsync(id);

        public async Task AddAsync(Diagnostico entity)
        {
            await _context.Diagnosticos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Diagnostico entity)
        {
            _context.Diagnosticos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(id);
            if (diagnostico == null)
            {
                return false;
            }

            _context.Diagnosticos.Remove(diagnostico);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
