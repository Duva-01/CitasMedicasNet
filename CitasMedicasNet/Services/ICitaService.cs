using CitasMedicasNet.Models;

namespace CitasMedicasNet.Services
{
    public interface ICitaService
    {
        public abstract Task<IEnumerable<Cita>> getCitasAsync();

        public abstract Task<Cita> getCitaByIdAsync(int id);

        public abstract Task<Cita> createCita(Cita cita);

        public abstract Task<Cita> updateCita(Cita cita);

        public abstract Task<bool> deleteCita(int id);
    }
}
