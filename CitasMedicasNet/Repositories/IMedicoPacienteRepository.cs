namespace CitasMedicasNet.Repositories
{
    using CitasMedicasNet.Models.CitasMedicasNet.Models;

    public interface IMedicoPacienteRepository : IRepository<MedicoPaciente>
    {
        Task<IEnumerable<MedicoPaciente>> GetAllWithRelationsAsync();
        Task<MedicoPaciente> GetByIdWithRelationsAsync(int id);
    }
}
