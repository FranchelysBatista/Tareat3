using Microsoft.AspNetCore.Mvc;
using SportActivityTracking.Application.Services;
using SportActivityTracking.Domain.Entities;
using SportActivityTracking.Api.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivityTracking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActividadesDeportivasController : ControllerBase
    {
        private readonly ActividadesDeportivasService _service;

        public ActividadesDeportivasController(ActividadesDeportivasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActividadesDeportivasDtos>>> GetActividades()
        {
            var actividades = await _service.ObtenerTodas();
            var actividadesDto = actividades.Select(a => new ActividadesDeportivasDtos
            {
                Id = a.Id,
                Descripcion = a.Descripcion,
                Fecha = a.Fecha,
                DuracionMinutos = a.DuracionMinutos,
                Usuario = a.Usuario,
                TipoDeporte = a.TipoDeporte
            }).ToList();

            if (actividadesDto.Count == 0)
                return NotFound(new { message = "No se encontraron actividades deportivas." });

            return Ok(new { message = "Actividades obtenidas exitosamente.", data = actividadesDto });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadesDeportivasDtos>> GetActividad(int id)
        {
            var actividad = await _service.ObtenerPorId(id);
            if (actividad == null)
                return NotFound(new { message = "Actividad no encontrada." });

            var actividadDto = new ActividadesDeportivasDtos
            {
                Id = actividad.Id,
                Descripcion = actividad.Descripcion,
                Fecha = actividad.Fecha,
                DuracionMinutos = actividad.DuracionMinutos,
                Usuario = actividad.Usuario,
                TipoDeporte = actividad.TipoDeporte
            };

            return Ok(new { message = "Actividad obtenida exitosamente.", data = actividadDto });
        }

        [HttpPost]
        public async Task<IActionResult> PostActividad([FromBody] ActividadesDeportivasDtos actividadDto)
        {
            if (actividadDto == null)
                return BadRequest(new { message = "Los datos de la actividad no son válidos." });

            var actividad = new ActividadDeportiva
            {
                Descripcion = actividadDto.Descripcion,
                Fecha = actividadDto.Fecha,
                DuracionMinutos = actividadDto.DuracionMinutos,
                Usuario = actividadDto.Usuario,
                TipoDeporte = actividadDto.TipoDeporte
            };

            await _service.Agregar(actividad);
            return CreatedAtAction(nameof(GetActividad), new { id = actividad.Id }, new { message = "Actividad creada exitosamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(int id, [FromBody] ActividadesDeportivasDtos actividadDto)
        {
            if (id != actividadDto.Id)
                return BadRequest(new { message = "El ID de la actividad no coincide." });

            var actividad = new ActividadDeportiva
            {
                Id = actividadDto.Id,
                Descripcion = actividadDto.Descripcion,
                Fecha = actividadDto.Fecha,
                DuracionMinutos = actividadDto.DuracionMinutos,
                Usuario = actividadDto.Usuario,
                TipoDeporte = actividadDto.TipoDeporte
            };

            await _service.Actualizar(actividad);
            return Ok(new { message = "Actividad actualizada exitosamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            await _service.Eliminar(id);
            return Ok(new { message = "Actividad eliminada exitosamente." });
        }
    }
}
