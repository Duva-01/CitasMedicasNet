namespace CitasMedicasNet.DTOs
{
    public class PacienteDTO : UsuarioDTO
    {
        public string NSS { get; set; }
        public string num_tarjeta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
    }
}
