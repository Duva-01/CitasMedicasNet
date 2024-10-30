using CitasMedicasNet.Models.CitasMedicasNet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models
{
    [Table("Paciente")]
    public class Paciente : Usuario
    {

        [Required]
        [StringLength(50)]
        [Column("NSS")]
        public string NSS { get; set; }

        [Required]
        [StringLength(50)]
        [Column("num_tarjeta")]
        public string num_tarjeta { get; set; }

        [StringLength(50)]
        [Column("telefono")]
        public string telefono { get; set; }

        [StringLength(200)]
        [Column("direccion")]
        public string direccion { get; set; }

        public ICollection<MedicoPaciente> medicoPacientes { get; set; } = new List<MedicoPaciente>();

        public ICollection<Cita> citas { get; set; } = new List<Cita>();

    }
}
