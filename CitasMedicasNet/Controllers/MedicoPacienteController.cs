using AutoMapper;
using CitasMedicasNet.DTOs;
using CitasMedicasNet.Exceptions;
using CitasMedicasNet.Models;
using CitasMedicasNet.Models.CitasMedicasNet.Models;
using CitasMedicasNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicasNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicoPacienteController : ControllerBase
    {
        private readonly IMedicoPacienteService _medicoPacienteService;
        private readonly IMapper _mapper;
        private readonly ILogger<MedicoPacienteController> _logger;
        public MedicoPacienteController(IMedicoPacienteService medicoPacienteService, IMapper mapper, ILogger<MedicoPacienteController> logger)
        {
            _medicoPacienteService = medicoPacienteService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> getAllMedicoPacientes()
        {

            _logger.LogInformation("Obteniendo todos los MedicoPacientes");

            IEnumerable<MedicoPaciente> MedicoPacientes = await _medicoPacienteService.getMedicoPacientesAsync();
            IEnumerable<MedicoPacienteDTO> MedicoPacientesDTO = _mapper.Map<IEnumerable<MedicoPacienteDTO>>(MedicoPacientes);
            return Ok(MedicoPacientesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getMedicoPacienteById(int id)
        {

            _logger.LogInformation("Obteniendo MedicoPaciente con ID: {id}", id);

            MedicoPaciente medicoPaciente = await _medicoPacienteService.getMedicoPacienteByIdAsync(id);

            if (medicoPaciente == null)
            {
                throw new NotFoundException($"MedicoPaciente con id {id} no encontrado.");
            }

            MedicoPacienteDTO medicoPacienteDTO = _mapper.Map<MedicoPacienteDTO>(medicoPaciente);
            return Ok(medicoPacienteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> createMedicoPaciente([FromBody] MedicoPacienteDTO medicoPacienteDTO)
        {
            _logger.LogInformation("Creando un nuevo MedicoPaciente");
            MedicoPaciente medicoPaciente = _mapper.Map<MedicoPaciente>(medicoPacienteDTO);
            MedicoPaciente medicoPacienteCreado = await _medicoPacienteService.createMedicoPaciente(medicoPaciente);

            MedicoPacienteDTO medicoPacienteCreadoDTO = _mapper.Map<MedicoPacienteDTO>(medicoPacienteCreado);

            _logger.LogInformation("MedicoPaciente creado con ID: {Id}", medicoPacienteCreadoDTO.id);
            return Ok(medicoPacienteCreadoDTO);
        }

        [HttpPut]
        public async Task<IActionResult> updateMedicoPaciente([FromBody] MedicoPacienteDTO medicoPacienteDTO)
        {
            _logger.LogInformation("Actualizando MedicoPaciente con ID: {Id}", medicoPacienteDTO.id);
            MedicoPaciente medicoPaciente = _mapper.Map<MedicoPaciente>(medicoPacienteDTO);
            MedicoPaciente medicoPacienteActualizado = await _medicoPacienteService.updateMedicoPaciente(medicoPaciente);

            MedicoPacienteDTO medicoPacienteActualizadoDTO = _mapper.Map<MedicoPacienteDTO>(medicoPacienteActualizado);

            _logger.LogInformation("MedicoPaciente actualizado con ID: {Id}", medicoPacienteActualizadoDTO.id);

            return Ok(medicoPacienteActualizadoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteMedicoPaciente(int id)
        {

            _logger.LogInformation("Eliminando MedicoPaciente con ID: {Id}", id);

            bool result = await _medicoPacienteService.deleteMedicoPaciente(id);

            if (!result)
            {
                throw new NotFoundException($"MedicoPaciente con id {id} no encontrado.");
            }

            _logger.LogInformation("MedicoPaciente con ID {Id} eliminado exitosamente", id);

            return Ok();

        }
    }

}
