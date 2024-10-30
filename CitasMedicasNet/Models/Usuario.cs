using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasNet.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(100)]
        [Required]
        [Column("nombre")]
        public string nombre { get; set; }

        [StringLength(100)]
        [Required]
        [Column("apellidos")]
        public string apellidos { get; set; }

        [StringLength(100)]
        [Required]
        [Column("usuario")]
        public string usuario { get; set; }

        [StringLength(100)]
        [Required]
        [Column("clave")]
        public string clave { get; set; }
    }

}
