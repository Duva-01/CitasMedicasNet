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
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoService _diagnosticoService;
        private readonly IMapper _mapper;
        private readonly ILogger<DiagnosticoController> _logger;
        public DiagnosticoController(IDiagnosticoService diagnosticoService, IMapper mapper, ILogger<DiagnosticoController> logger)
        {
            _diagnosticoService = diagnosticoService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> getAllDiagnosticos()
        {

            _logger.LogInformation("Obteniendo todos los Diagnosticos");

            IEnumerable<Diagnostico> diagnosticos = await _diagnosticoService.getDiagnosticosAsync();
            IEnumerable<DiagnosticoDTO> diagnosticosDTO = _mapper.Map<IEnumerable<DiagnosticoDTO>>(diagnosticos);
            return Ok(diagnosticosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getDiagnosticoById(int id)
        {

            _logger.LogInformation("Obteniendo Diagnostico con ID: {Id}", id);

            Diagnostico diagnostico = await _diagnosticoService.getDiagnosticoByIdAsync(id);

            if (diagnostico == null)
            {
                throw new NotFoundException($"Diagnostico con id {id} no encontrado.");
            }

            DiagnosticoDTO diagnosticoDTO = _mapper.Map<DiagnosticoDTO>(diagnostico);
            return Ok(diagnosticoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> createDiagnostico([FromBody] DiagnosticoDTO diagnosticoDTO)
        {
            _logger.LogInformation("Creando un nuevo Diagnostico");
            Diagnostico diagnostico = _mapper.Map<Diagnostico>(diagnosticoDTO);
            Diagnostico diagnosticoCreado = await _diagnosticoService.createDiagnostico(diagnostico);

            DiagnosticoDTO diagnosticoCreadoDTO = _mapper.Map<DiagnosticoDTO>(diagnosticoCreado);

            _logger.LogInformation("Diagnostico creado con ID: {Id}", diagnosticoCreadoDTO.id);
            return Ok(diagnosticoCreadoDTO);
        }

        [HttpPut]
        public async Task<IActionResult> updateDiagnostico([FromBody] DiagnosticoDTO diagnosticoDTO)
        {
            _logger.LogInformation("Actualizando Diagnostico con ID: {Id}", diagnosticoDTO.id);
            Diagnostico diagnostico = _mapper.Map<Diagnostico>(diagnosticoDTO);
            Diagnostico diagnosticoActualizado = await _diagnosticoService.updateDiagnostico(diagnostico);

            DiagnosticoDTO diagnosticoActualizadoDTO = _mapper.Map<DiagnosticoDTO>(diagnosticoActualizado);

            _logger.LogInformation("Diagnostico actualizado con ID: {Id}", diagnosticoActualizadoDTO.id);

            return Ok(diagnosticoActualizadoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteDiagnostico(int id)
        {

            _logger.LogInformation("Eliminando Diagnostico con ID: {Id}", id);

            bool result = await _diagnosticoService.deleteDiagnostico(id);

            if (!result)
            {
                throw new NotFoundException($"Diagnostico con id {id} no encontrado.");
            }

            _logger.LogInformation("Diagnostico con ID {Id} eliminado exitosamente", id);

            return Ok();

        }
    }

}
