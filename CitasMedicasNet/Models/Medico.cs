using CitasMedicasNet.Models.CitasMedicasNet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models
{
    [Table("Medico")]
    public class Medico : Usuario
    {

        [Required]
        [StringLength(50)]
        [Column("num_colegiado")]

        public string num_colegiado { get; set; }

        public ICollection<MedicoPaciente> medicoPacientes { get; set; } = new List<MedicoPaciente>();

        public ICollection<Cita> citas { get; set; } = new List<Cita>();


    }
}
