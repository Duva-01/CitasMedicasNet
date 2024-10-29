using CitasMedicasNet.Models;

namespace CitasMedicasNet.Services
{
    public interface IMedicoService
    {

        public abstract Task<IEnumerable<Medico>> getMedicosAsync();

        public abstract Task<Medico> getMedicoByIdAsync(int id);

        public abstract Task<Medico> createMedico(Medico medico);

        public abstract Task<Medico> updateMedico(Medico medico);

        public abstract Task<bool> deleteMedico(int id);
    }
}
