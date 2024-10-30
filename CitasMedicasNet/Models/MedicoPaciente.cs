using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models.CitasMedicasNet.Models
{
    [Table("MedicoPaciente")]
    public class MedicoPaciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Column("medico_id")]

        public int medico_id { get; set; }

        [Required]
        [Column("paciente_id")]

        public int paciente_id { get; set; }

        [ForeignKey("medico_id")]
        public Medico medico { get; set; }

        [ForeignKey("paciente_id")]
        public Paciente paciente { get; set; }
    }
}
