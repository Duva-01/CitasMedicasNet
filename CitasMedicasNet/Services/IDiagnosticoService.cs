using CitasMedicasNet.Models;

namespace CitasMedicasNet.Services
{
    public interface IDiagnosticoService
    {
        public abstract Task<IEnumerable<Diagnostico>> getDiagnosticosAsync();

        public abstract Task<Diagnostico> getDiagnosticoByIdAsync(int id);

        public abstract Task<Diagnostico> createDiagnostico(Diagnostico diagnostico);

        public abstract Task<Diagnostico> updateDiagnostico(Diagnostico diagnostico);

        public abstract Task<bool> deleteDiagnostico(int id);
    }
}
