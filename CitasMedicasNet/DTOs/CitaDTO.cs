using CitasMedicasNet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasNet.DTOs
{
    public class CitaDTO
    {

        public int id { get; set; }

        public DateTime fecha_hora { get; set; }

        public string motivo_cita { get; set; }

        public int paciente_id { get; set; }

        public int medico_id { get; set; }

    }
}
