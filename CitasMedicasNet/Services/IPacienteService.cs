using CitasMedicasNet.Models;

namespace CitasMedicasNet.Services
{
    public interface IPacienteService
    {

        public abstract Task<IEnumerable<Paciente>> getPacientesAsync();

        public abstract Task<Paciente> getPacienteByIdAsync(int id);

        public abstract Task<Paciente> createPaciente(Paciente paciente);

        public abstract Task<Paciente> updatePaciente(Paciente paciente);

        public abstract Task<bool> deletePaciente(int id);
    }
}
