namespace CitasMedicasNet.Repositories.Impl
{
    using CitasMedicasNet.Models;
    using global::CitasMedicasNet.Models;
    using Microsoft.EntityFrameworkCore;

        public class PacienteRepository : IRepository<Paciente>
        {
            private readonly AppDbContext _context;

            public PacienteRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Paciente>> GetAllAsync() => await _context.Pacientes.ToListAsync();

            public async Task<Paciente> GetByIdAsync(int id) => await _context.Pacientes.FindAsync(id);

            public async Task AddAsync(Paciente entity)
            {
                await _context.Pacientes.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Paciente entity)
            {
                _context.Pacientes.Update(entity);
                await _context.SaveChangesAsync();
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var paciente = await _context.Pacientes.FindAsync(id);
                if (paciente == null)
                {
                    return false;
                }

                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
                return true;
            }

        }

}

