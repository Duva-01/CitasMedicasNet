using AutoMapper;
using CitasMedicasNet.DTOs;
using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicasNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;
        private readonly ILogger<PacienteController> _logger;
        public PacienteController(IPacienteService pacienteService, IMapper mapper, ILogger<PacienteController> logger)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> getAllPacientes()
        {

            _logger.LogInformation("Obteniendo todos los pacientes");

            IEnumerable<Paciente> pacientes = await _pacienteService.getPacientesAsync();
            IEnumerable<PacienteDTO> pacientesDTO = _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);
            return Ok(pacientesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getPacienteById(int id)
        {

            _logger.LogInformation("Obteniendo paciente con ID: {Id}", id);

            Paciente paciente = await _pacienteService.getPacienteByIdAsync(id);

            if (paciente == null)
            {
                throw new NotFoundException($"Paciente con id {id} no encontrado.");
            }

            PacienteDTO pacienteDTO = _mapper.Map<PacienteDTO>(paciente);
            return Ok(pacienteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> createPaciente([FromBody] PacienteDTO pacienteDTO)
        {
            _logger.LogInformation("Creando un nuevo paciente");
            Paciente paciente = _mapper.Map<Paciente>(pacienteDTO);
            Paciente pacienteCreado = await _pacienteService.createPaciente(paciente);

            PacienteDTO pacienteCreadoDTO = _mapper.Map<PacienteDTO>(pacienteCreado);

            _logger.LogInformation("Paciente creado con ID: {Id}", pacienteCreadoDTO.id);
            return Ok(pacienteCreadoDTO);
        }

        [HttpPut]
        public async Task<IActionResult> updatePaciente([FromBody] PacienteDTO pacienteDTO)
        {
            _logger.LogInformation("Actualizando paciente con ID: {Id}", pacienteDTO.id);
            Paciente paciente = _mapper.Map<Paciente>(pacienteDTO);
            Paciente pacienteActualizado = await _pacienteService.updatePaciente(paciente);

            PacienteDTO pacienteActualizadoDTO = _mapper.Map<PacienteDTO>(pacienteActualizado);

            _logger.LogInformation("paciente actualizado con ID: {Id}", pacienteActualizadoDTO.id);

            return Ok(pacienteActualizadoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletePaciente(int id)
        {

            _logger.LogInformation("Eliminando paciente con ID: {Id}", id);

            bool result = await _pacienteService.deletePaciente(id);

            if (!result)
            {
                throw new NotFoundException($"Paciente con id {id} no encontrado.");
            }

            _logger.LogInformation("Paciente con ID {Id} eliminado exitosamente", id);

            return Ok();

        }
    }

}
