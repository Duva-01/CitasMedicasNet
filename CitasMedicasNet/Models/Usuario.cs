using System.ComponentModel.DataAnnotations;

namespace CitasMedicasNet.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [StringLength(100)]
        [Required]
        public string nombre { get; set; }

        [StringLength(100)]
        [Required]
        public string apellidos { get; set; }

        [StringLength(100)]
        [Required]
        public string usuario { get; set; }

        [StringLength(100)]
        [Required]
        public string clave { get; set; }
    }

}
