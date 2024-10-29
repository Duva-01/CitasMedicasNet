using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models
{
    public class Cita
    {
        [Key]
        public int id { get; set; }

        [Required]
        public DateTime fecha_hora { get; set; }

        [Required]
        [StringLength(255)]
        public string motivo_cita { get; set; }

        [Required]
        public int paciente_id { get; set; }

        [Required]
        public int medico_id { get; set; } 

        [ForeignKey("paciente_id")]
        public Paciente paciente { get; set; }

        [ForeignKey("medico_id")]
        public Medico medico { get; set; }

        public Diagnostico diagnostico { get; set; }

    }
}
