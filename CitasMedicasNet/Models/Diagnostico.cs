using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models
{
    public class Diagnostico
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string valoracion_especialista { get; set; }

        [Required]
        [StringLength(255)]
        public string enfermedad { get; set; }

        [Required]
        public int cita_id { get; set; }  

        [ForeignKey("cita_id")]
        public Cita cita { get; set; }
    }
}
