using AutoMapper;
using CitasMedicasNet.DTOs;
using CitasMedicasNet.Models;
using CitasMedicasNet.Models.CitasMedicasNet.Models;

namespace CitasMedicasNet.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTO, Paciente>();

            CreateMap<Medico, MedicoDTO>();
            CreateMap<MedicoDTO, Medico>();

            CreateMap<MedicoPaciente, MedicoPacienteDTO>();
            CreateMap<MedicoPacienteDTO, MedicoPaciente>();

            CreateMap<Cita, CitaDTO>();
            CreateMap<CitaDTO, Cita>();

            CreateMap<Diagnostico, DiagnosticoDTO>();
            CreateMap<DiagnosticoDTO, Diagnostico>();
        }
    }

}
