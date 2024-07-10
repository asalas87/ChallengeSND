using Microsoft.AspNetCore.Mvc;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Business.Servicies.Interfaces;
using System.Threading.Tasks;

namespace ChallengeSND.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // GET: api/pacientes
        [HttpGet]
        public async Task<IActionResult> GetPacientes()
        {
            try
            {
                var pacientes = await _pacienteService.GetAllPacientes();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al obtener los pacientes: {ex.Message}",
                    Result = null
                });
            }
        }

        // GET: api/pacientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaciente(int id)
        {
            try
            {
                var paciente = await _pacienteService.GetPacienteById(id);
                if (paciente == null)
                {
                    return NotFound(new ResponseDto
                    {
                        IsSuccess = false,
                        Message = $"Paciente con ID {id} no encontrado.",
                        Result = null
                    });
                }
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al obtener el paciente con ID {id}: {ex.Message}",
                    Result = null
                });
            }
        }

        // POST: api/pacientes
        [HttpPost]
        public async Task<IActionResult> PostPaciente([FromBody] PacienteDto pacienteDto)
        {
            // Verifica que el objeto pacienteDto no sea nulo
            if (pacienteDto == null)
            {
                return BadRequest(new ResponseDto
                {
                    IsSuccess = false,
                    Message = "PacienteDto no puede ser nulo.",
                    Result = null
                });
            }

            try
            {
                // Crear el nuevo paciente y obtener el objeto PacienteDto creado
                var nuevoPaciente = await _pacienteService.CreatePaciente(pacienteDto);

                // Devolver una respuesta con el nuevo PacienteDto creado
                return CreatedAtAction(nameof(GetPaciente), new { id = nuevoPaciente.Id }, nuevoPaciente);
            }
            catch (Exception ex)
            {
                // Manejo de errores y devolver una respuesta adecuada
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al crear el paciente: {ex.Message}",
                    Result = null
                });
            }
        }


        // PUT: api/pacientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, [FromBody] PacienteDto pacienteDto)
        {
            if (id != pacienteDto.Id)
            {
                return BadRequest(new ResponseDto
                {
                    IsSuccess = false,
                    Message = "El ID del PacienteDto no coincide con el ID de la URL.",
                    Result = null
                });
            }

            if (pacienteDto == null)
            {
                return BadRequest(new ResponseDto
                {
                    IsSuccess = false,
                    Message = "PacienteDto no puede ser nulo.",
                    Result = null
                });
            }

            try
            {
                await _pacienteService.UpdatePaciente(pacienteDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al actualizar el paciente con ID {id}: {ex.Message}",
                    Result = null
                });
            }
        }

        // DELETE: api/pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            try
            {
                await _pacienteService.DeletePaciente(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al eliminar el paciente con ID {id}: {ex.Message}",
                    Result = null
                });
            }
        }
    }
}
