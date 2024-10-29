using CitasMedicasNet.Models;
using CitasMedicasNet.Models.CitasMedicasNet.Models;

namespace CitasMedicasNet.Services
{
    public interface IMedicoPacienteService
    {

        public abstract Task<IEnumerable<MedicoPaciente>> getMedicoPacientesAsync();

        public abstract Task<MedicoPaciente> getMedicoPacienteByIdAsync(int id);

        public abstract Task<MedicoPaciente> createMedicoPaciente(MedicoPaciente medicoPaciente);

        public abstract Task<MedicoPaciente> updateMedicoPaciente(MedicoPaciente medicoPaciente);

        public abstract Task<bool> deleteMedicoPaciente(int id);

    }
}
