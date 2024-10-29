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
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;
        private readonly ILogger<MedicoController> _logger;
        public MedicoController(IMedicoService medicoService, IMapper mapper, ILogger<MedicoController> logger)
        {
            _medicoService = medicoService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> getAllMedicos()
        {

            _logger.LogInformation("Obteniendo todos los medicos");

            IEnumerable<Medico> medicos = await _medicoService.getMedicosAsync();
            IEnumerable<MedicoDTO> medicosDTO = _mapper.Map<IEnumerable<MedicoDTO>>(medicos);
            return Ok(medicosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getMedicoById(int id)
        {

            _logger.LogInformation("Obteniendo medico con ID: {id}", id);

            Medico medico = await _medicoService.getMedicoByIdAsync(id);

            if (medico == null)
            {
                throw new NotFoundException($"Medico con id {id} no encontrado.");
            }

            MedicoDTO medicoDTO = _mapper.Map<MedicoDTO>(medico);
            return Ok(medicoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> createMedico([FromBody] MedicoDTO medicoDTO)
        {
            _logger.LogInformation("Creando un nuevo Medico");
            Medico medico = _mapper.Map<Medico>(medicoDTO);
            Medico medicoCreado = await _medicoService.createMedico(medico);

            MedicoDTO medicoCreadoDTO = _mapper.Map<MedicoDTO>(medicoCreado);

            _logger.LogInformation("Medico creado con ID: {Id}", medicoCreadoDTO.id);
            return Ok(medicoCreadoDTO);
        }

        [HttpPut]
        public async Task<IActionResult> updateMedico([FromBody] MedicoDTO medicoDTO)
        {
            _logger.LogInformation("Actualizando Medico con ID: {Id}", medicoDTO.id);
            Medico medico = _mapper.Map<Medico>(medicoDTO);
            Medico medicoActualizado = await _medicoService.updateMedico(medico);

            MedicoDTO medicoActualizadoDTO = _mapper.Map<MedicoDTO>(medicoActualizado);

            _logger.LogInformation("Medico actualizado con ID: {Id}", medicoActualizadoDTO.id);

            return Ok(medicoActualizadoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteMedico(int id)
        {

            _logger.LogInformation("Eliminando medico con ID: {Id}", id);

            bool result = await _medicoService.deleteMedico(id);

            if (!result)
            {
                throw new NotFoundException($"Medico con id {id} no encontrado.");
            }

            _logger.LogInformation("Medico con ID {Id} eliminado exitosamente", id);

            return Ok();

        }
    }

}
