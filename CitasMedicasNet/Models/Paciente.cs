using CitasMedicasNet.Models.CitasMedicasNet.Models;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasNet.Models
{
    public class Paciente : Usuario
    {

        [Required]
        [StringLength(50)]
        public string NSS { get; set; }

        [Required]
        [StringLength(50)]
        public string num_tarjeta { get; set; }

        [StringLength(50)]
        public string telefono { get; set; }

        [StringLength(200)]
        public string direccion { get; set; }

        public ICollection<MedicoPaciente> medicoPacientes { get; set; } = new List<MedicoPaciente>();

        public ICollection<Cita> citas { get; set; } = new List<Cita>();

    }
}
