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
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;
        private readonly IMapper _mapper;
        private readonly ILogger<CitaController> _logger;
        public CitaController(ICitaService citaService, IMapper mapper, ILogger<CitaController> logger)
        {
            _citaService = citaService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCitas()
        {

            _logger.LogInformation("Obteniendo todos los Citas");

            IEnumerable<Cita> citas = await _citaService.getCitasAsync();
            IEnumerable<CitaDTO> citasDTO = _mapper.Map<IEnumerable<CitaDTO>>(citas);
            return Ok(citasDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCitaById(int id)
        {

            _logger.LogInformation("Obteniendo Cita con ID: {Id}", id);

            Cita cita = await _citaService.getCitaByIdAsync(id);

            if (cita == null)
            {
                throw new NotFoundException($"Cita con id {id} no encontrado.");
            }

            CitaDTO citaDTO = _mapper.Map<CitaDTO>(cita);
            return Ok(citaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> createCita([FromBody] CitaDTO citaDTO)
        {
            _logger.LogInformation("Creando un nuevo Cita");
            Cita cita = _mapper.Map<Cita>(citaDTO);
            Cita citaCreado = await _citaService.createCita(cita);

            CitaDTO citaCreadoDTO = _mapper.Map<CitaDTO>(citaCreado);

            _logger.LogInformation("Cita creado con ID: {Id}", citaCreadoDTO.id);
            return Ok(citaCreadoDTO);
        }

        [HttpPut]
        public async Task<IActionResult> updateCita([FromBody] CitaDTO citaDTO)
        {
            _logger.LogInformation("Actualizando Cita con ID: {Id}", citaDTO.id);
            Cita cita = _mapper.Map<Cita>(citaDTO);
            Cita citaActualizado = await _citaService.updateCita(cita);

            CitaDTO citaActualizadoDTO = _mapper.Map<CitaDTO>(citaActualizado);

            _logger.LogInformation("Cita actualizado con ID: {Id}", citaActualizadoDTO.id);

            return Ok(citaActualizadoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCita(int id)
        {

            _logger.LogInformation("Eliminando Cita con ID: {Id}", id);

            bool result = await _citaService.deleteCita(id);

            if (!result)
            {
                throw new NotFoundException($"Cita con id {id} no encontrado.");
            }

            _logger.LogInformation("Cita con ID {Id} eliminado exitosamente", id);

            return Ok();

        }
    }

}
