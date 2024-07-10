using Microsoft.AspNetCore.Mvc;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Business.Servicies.Interfaces;

namespace ChallengeSND.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicosController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        // GET: api/medicos
        [HttpGet]
        public async Task<IActionResult> GetMedicos()
        {
            var medicos = await _medicoService.GetAllMedicos();
            return Ok(medicos);
        }

        // GET: api/medicos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedico(int id)
        {
            var medico = await _medicoService.GetMedicoById(id);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        // POST: api/medicos
        [HttpPost]
        public async Task<IActionResult> PostMedico([FromBody] MedicoDto medicoDto)
        {
            if (medicoDto == null)
            {
                return BadRequest("MedicoDto no puede ser nulo.");
            }

            try
            {
                
                var nuevoMedico = await _medicoService.CreateMedico(medicoDto);

                return CreatedAtAction(nameof(GetMedico), new { id = nuevoMedico.Id }, nuevoMedico);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ocurrió un error al crear el medico: {ex.Message}",
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
                return BadRequest("El ID del MedicoDto no coincide con el ID de la URL.");
            }

            if (medicoDto == null)
            {
                return BadRequest("MedicoDto no puede ser nulo.");
            }

            await _medicoService.UpdateMedico(medicoDto);
            return NoContent();
        }

        // DELETE: api/medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            await _medicoService.DeleteMedico(id);
            return NoContent();
        }
    }
}
