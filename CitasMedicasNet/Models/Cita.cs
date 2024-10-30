using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models
{
    [Table("Cita")]
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Column("fecha_hora")]

        public DateTime fecha_hora { get; set; }

        [Required]
        [StringLength(255)]
        [Column("motivo_cita")]

        public string motivo_cita { get; set; }

        [Required]
        [Column("paciente_id")]

        public int paciente_id { get; set; }

        [Required]
        [Column("medico_id")]

        public int medico_id { get; set; } 

        [ForeignKey("paciente_id")]
        public Paciente paciente { get; set; }

        [ForeignKey("medico_id")]
        public Medico medico { get; set; }

        public Diagnostico diagnostico { get; set; }

    }
}
