using CitasMedicasNet.Models.CitasMedicasNet.Models;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasNet.Models
{
    public class Medico : Usuario
    {

        [Required]
        [StringLength(50)]
        public string num_colegiado { get; set; }

        public ICollection<MedicoPaciente> medicoPacientes { get; set; } = new List<MedicoPaciente>();

        public ICollection<Cita> citas { get; set; } = new List<Cita>();


    }
}
