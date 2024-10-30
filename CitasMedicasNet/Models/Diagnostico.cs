using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models
{
    [Table("Diagnostico")]
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("valoracion_especialista")]
        public string valoracion_especialista { get; set; }

        [Required]
        [StringLength(255)]
        [Column("enfermedad")]
        public string enfermedad { get; set; }

        [Required]
        [Column("cita_id")]
        public int cita_id { get; set; }  

        [ForeignKey("cita_id")]
        public Cita cita { get; set; }
    }
}
