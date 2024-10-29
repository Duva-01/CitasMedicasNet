using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Repositories;
using Microsoft.Data.SqlClient;

namespace CitasMedicasNet.Services.Impl
{
    public class PacienteService : IPacienteService
    {

        private readonly IRepository<Paciente> _pacienteRepository;
        private readonly ILogger<PacienteService> _logger;

        public PacienteService(IRepository<Paciente> pacienteRepository, ILogger<PacienteService> logger)
        {
            _pacienteRepository = pacienteRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Paciente>> getPacientesAsync()
        {
            try
            {
                _logger.LogInformation("Intentando obtener todos los pacientes");
                return await _pacienteRepository.GetAllAsync();
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Error en la base de datos al obtener pacientes.");
                throw new NotFoundException("Error al obtener los pacientes debido a un problema en la base de datos.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error desconocido al obtener pacientes.");
                throw new Exception("Error desconocido: " + ex.Message);
            }
        }

        public async Task<Paciente> getPacienteByIdAsync(int id)
        {
            try
            {
                var paciente = await _pacienteRepository.GetByIdAsync(id);
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Paciente> createPaciente(Paciente paciente)
        {
            try
            {
                await _pacienteRepository.AddAsync(paciente);
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Paciente> updatePaciente(Paciente paciente)
        {
            try
            {
                await _pacienteRepository.UpdateAsync(paciente);
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deletePaciente(int id)
        {
            try
            {
                bool result = await _pacienteRepository.DeleteAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al intentar eliminar un paciente: " + ex.Message);
            }
        }
    }
}
