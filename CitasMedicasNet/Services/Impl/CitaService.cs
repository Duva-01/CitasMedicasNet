using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Repositories;

namespace CitasMedicasNet.Services.Impl
{
    public class CitaService : ICitaService
    {
        private readonly IRepository<Cita> _citaRepository;

        public CitaService(IRepository<Cita> citaRepository)
        {
            _citaRepository =  citaRepository;
        }

        public async Task<IEnumerable<Cita>> getCitasAsync()
        {
            try
            {
                return await _citaRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Error al obtener los Citas. Excepcion: " + ex.Message);
            }
        }

        public async Task<Cita> getCitaByIdAsync(int id)
        {
            try
            {
                return await _citaRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cita> createCita(Cita cita)
        {
            try
            {
                await _citaRepository.AddAsync(cita);
                return cita;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cita> updateCita(Cita cita)
        {
            try
            {
                await _citaRepository.UpdateAsync(cita);
                return cita;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteCita(int id)
        {
            try
            {
                bool result = await _citaRepository.DeleteAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al intentar eliminar un Cita: " + ex.Message);
            }
        }
    }
}
