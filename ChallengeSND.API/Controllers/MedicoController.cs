using Microsoft.AspNetCore.Mvc;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Business.Servicies.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChallengeSND.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        private readonly ILogger<MedicosController> _logger;  // Añadido para logging

        public MedicosController(IMedicoService medicoService, ILogger<MedicosController> logger)
        {
            _medicoService = medicoService;
            _logger = logger;  // Inicialización del logger
        }

        // GET: api/medicos
        [HttpGet]
        public async Task<IActionResult> GetMedicos()
        {
            _logger.LogInformation("Iniciando la solicitud para obtener todos los médicos.");
            var medicos = await _medicoService.GetAllMedicos();
            if (medicos == null || !medicos.Any())
            {
                _logger.LogWarning("No se encontraron médicos.");
                return NotFound("No se encontraron médicos.");
            }

            _logger.LogInformation($"Se encontraron {medicos.Count()} médicos.");
            return Ok(medicos);
        }

        // GET: api/medicos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedico(int id)
        {
            _logger.LogInformation($"Iniciando la solicitud para obtener el médico con ID {id}.");
            var medico = await _medicoService.GetMedicoById(id);
            if (medico == null)
            {
                _logger.LogWarning($"No se encontró un médico con ID {id}.");
                return NotFound($"No se encontró un médico con ID {id}.");
            }

            _logger.LogInformation($"Se encontró el médico con ID {id}.");
            return Ok(medico);
        }

        // POST: api/medicos
        [HttpPost]
        public async Task<IActionResult> PostMedico([FromBody] MedicoDto medicoDto)
        {
            if (medicoDto == null)
            {
                _logger.LogWarning("El objeto MedicoDto recibido en el POST es nulo.");
                return BadRequest("MedicoDto no puede ser nulo.");
            }

            try
            {
                _logger.LogInformation("Iniciando la solicitud para crear un nuevo médico.");
                var nuevoMedico = await _medicoService.CreateMedico(medicoDto);
                _logger.LogInformation($"Médico creado con ID {nuevoMedico.Id}.");
                return CreatedAtAction(nameof(GetMedico), new { id = nuevoMedico.Id }, nuevoMedico);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al crear el médico.");
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al crear el médico: {ex.Message}",
                    Result = null
                });
            }
        }

        // PUT: api/medicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico(int id, [FromBody] MedicoDto medicoDto)
        {
            if (id != medicoDto.Id)
            {
                _logger.LogWarning("El ID del MedicoDto no coincide con el ID de la URL.");
                return BadRequest("El ID del MedicoDto no coincide con el ID de la URL.");
            }

            if (medicoDto == null)
            {
                _logger.LogWarning("El objeto MedicoDto recibido en el PUT es nulo.");
                return BadRequest("MedicoDto no puede ser nulo.");
            }

            try
            {
                _logger.LogInformation($"Iniciando la solicitud para actualizar el médico con ID {id}.");
                await _medicoService.UpdateMedico(medicoDto);
                _logger.LogInformation($"Médico con ID {id} actualizado exitosamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocurrió un error al actualizar el médico con ID {id}.");
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al actualizar el médico con ID {id}: {ex.Message}",
                    Result = null
                });
            }
        }

        // DELETE: api/medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            try
            {
                _logger.LogInformation($"Iniciando la solicitud para eliminar el médico con ID {id}.");
                await _medicoService.DeleteMedico(id);
                _logger.LogInformation($"Médico con ID {id} eliminado exitosamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocurrió un error al eliminar el médico con ID {id}.");
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al eliminar el médico con ID {id}: {ex.Message}",
                    Result = null
                });
            }
        }
    }
}
