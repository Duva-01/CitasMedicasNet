namespace CitasMedicasNet.DTOs
{
    public class DiagnosticoDTO
    {
        public int id { get; set; }
        public string valoracion_especialista { get; set; }
        public string enfermedad { get; set; }

        public int cita_id { get; set; }

    }
}
