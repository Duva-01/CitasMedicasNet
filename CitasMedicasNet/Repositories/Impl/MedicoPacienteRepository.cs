using CitasMedicasNet.Models;
using CitasMedicasNet.Models.CitasMedicasNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasNet.Repositories.Impl
{
    public class MedicoPacienteRepository : IRepository<MedicoPaciente>, IMedicoPacienteRepository
    {
        private readonly AppDbContext _context;

        public MedicoPacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicoPaciente>> GetAllAsync() => await _context.MedicoPacientes
                .Include(mp => mp.medico)
                .Include(mp => mp.paciente)
                .ToListAsync();

        public async Task<MedicoPaciente> GetByIdAsync(int id) => await _context.MedicoPacientes.FindAsync(id);

        public async Task<IEnumerable<MedicoPaciente>> GetAllWithRelationsAsync()
        {
            return await _context.MedicoPacientes
                .Include(mp => mp.medico)
                .Include(mp => mp.paciente)
                .ToListAsync();
        }

        public async Task<MedicoPaciente> GetByIdWithRelationsAsync(int id)
        {
            return await _context.MedicoPacientes
                .Include(mp => mp.medico)
                .Include(mp => mp.paciente)
                .FirstOrDefaultAsync(mp => mp.id == id);
        }

        public async Task AddAsync(MedicoPaciente entity)
        {
            await _context.MedicoPacientes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MedicoPaciente entity)
        {
            _context.MedicoPacientes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var medicoPaciente = await _context.MedicoPacientes.FindAsync(id);
            if (medicoPaciente == null)
            {
                return false;
            }

            _context.MedicoPacientes.Remove(medicoPaciente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
