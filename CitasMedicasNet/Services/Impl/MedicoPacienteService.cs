using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models.CitasMedicasNet.Models;
using CitasMedicasNet.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasNet.Services.Impl
{
    public class MedicoPacienteService : IMedicoPacienteService
    {

        private readonly IMedicoPacienteRepository _medicoPacienteRepository;
        private readonly ILogger<MedicoPacienteService> _logger;

        public MedicoPacienteService(IMedicoPacienteRepository medicoPacienteRepository, ILogger<MedicoPacienteService> logger)
        {
            _medicoPacienteRepository = medicoPacienteRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<MedicoPaciente>> getMedicoPacientesAsync()
        {
            try
            {
                _logger.LogInformation("Intentando obtener todos los MedicoPacientes");
                return await _medicoPacienteRepository.GetAllWithRelationsAsync();

            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Error en la base de datos al obtener MedicoPacientes.");
                throw new NotFoundException("Error al obtener los MedicoPacientes debido a un problema en la base de datos.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error desconocido al obtener MedicoPacientes.");
                throw new Exception("Error desconocido: " + ex.Message);
            }
        }

        public async Task<MedicoPaciente> getMedicoPacienteByIdAsync(int id)
        {
            try
            {
                var medicoPaciente = await _medicoPacienteRepository.GetByIdWithRelationsAsync(id);
                return medicoPaciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MedicoPaciente> createMedicoPaciente(MedicoPaciente medicoPaciente)
        {
            try
            {
                await _medicoPacienteRepository.AddAsync(medicoPaciente);
                return medicoPaciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MedicoPaciente> updateMedicoPaciente(MedicoPaciente medicoPaciente)
        {
            try
            {
                await _medicoPacienteRepository.UpdateAsync(medicoPaciente);
                return medicoPaciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteMedicoPaciente(int id)
        {
            try
            {
                bool result = await _medicoPacienteRepository.DeleteAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al intentar eliminar un MedicoPaciente: " + ex.Message);
            }
        }
    }
}
