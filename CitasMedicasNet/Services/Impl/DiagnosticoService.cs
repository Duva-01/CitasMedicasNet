using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Repositories;

namespace CitasMedicasNet.Services.Impl
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly IRepository<Diagnostico> _diagnosticoRepository;

        public DiagnosticoService(IRepository<Diagnostico> diagnosticoRepository)
        {
            _diagnosticoRepository = diagnosticoRepository;
        }

        public async Task<IEnumerable<Diagnostico>> getDiagnosticosAsync()
        {
            try
            {
                return await _diagnosticoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Error al obtener los Diagnosticos. Excepcion: " + ex.Message);
            }
        }

        public async Task<Diagnostico> getDiagnosticoByIdAsync(int id)
        {
            try
            {
                return await _diagnosticoRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Diagnostico> createDiagnostico(Diagnostico diagnostico)
        {
            try
            {
                await _diagnosticoRepository.AddAsync(diagnostico);
                return diagnostico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Diagnostico> updateDiagnostico(Diagnostico diagnostico)
        {
            try
            {
                await _diagnosticoRepository.UpdateAsync(diagnostico);
                return diagnostico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteDiagnostico(int id)
        {
            try
            {
                bool result = await _diagnosticoRepository.DeleteAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al intentar eliminar un Diagnostico: " + ex.Message);
            }
        }
    }
}
