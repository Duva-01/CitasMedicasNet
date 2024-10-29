using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models.CitasMedicasNet.Models
{
    public class MedicoPaciente
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int medico_id { get; set; }

        [Required]
        public int paciente_id { get; set; }

        [ForeignKey("medico_id")]
        public Medico medico { get; set; }

        [ForeignKey("paciente_id")]
        public Paciente paciente { get; set; }
    }
}
