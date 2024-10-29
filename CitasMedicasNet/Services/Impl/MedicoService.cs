using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Repositories;
using Microsoft.Data.SqlClient;

namespace CitasMedicasNet.Services.Impl
{
    public class MedicoService : IMedicoService
    {

        private readonly IRepository<Medico> _medicoRepository;
        private readonly ILogger<MedicoService> _logger;

        public MedicoService(IRepository<Medico> medicoRepository, ILogger<MedicoService> logger)
        {
            _medicoRepository = medicoRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Medico>> getMedicosAsync()
        {
            try
            {
                _logger.LogInformation("Intentando obtener todos los medicos");
                return await _medicoRepository.GetAllAsync();
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Error en la base de datos al obtener medicos.");
                throw new NotFoundException("Error al obtener los medicos debido a un problema en la base de datos.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error desconocido al obtener medicos.");
                throw new Exception("Error desconocido: " + ex.Message);
            }
        }

        public async Task<Medico> getMedicoByIdAsync(int id)
        {
            try
            {
                var medico = await _medicoRepository.GetByIdAsync(id);
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Medico> createMedico(Medico medico)
        {
            try
            {
                await _medicoRepository.AddAsync(medico);
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Medico> updateMedico(Medico medico)
        {
            try
            {
                await _medicoRepository.UpdateAsync(medico);
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteMedico(int id)
        {
            try
            {
                bool result = await _medicoRepository.DeleteAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al intentar eliminar un medico: " + ex.Message);
            }
        }
    }
}
