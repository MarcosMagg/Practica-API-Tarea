using Microsoft.AspNetCore.Mvc;
using PracticaAPI.Domain.Entities;
using PracticaAPI.Domain.Request;
using PracticaAPI.Service.Interface;

namespace PracticaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class TareaController : ControllerBase
    {

        private ITareaService _tareaService;

        public TareaController(ITareaService tareaService)//inyeccion
        {
            _tareaService = tareaService;//con esto puedo manejarlo de manera global
        }


        [HttpGet]
        public async Task<IActionResult> GetTareas()//asincrono
        {
            var result = await _tareaService.GetAllTareasAsync();
            return Ok(result);
        }
        


        [HttpPost]//agrega
        public async Task<IActionResult> AddTarea([FromBody] Tarea tarea)
        {
            var result = await _tareaService.AddTareaAsync(tarea);
            if(tarea.Estado != "Pendiente" || tarea.Estado !=  "En curso" || tarea.Estado != "Finalizado") return BadRequest(new { Message = "No se pudo insertar la Tarea" });    
            if (!result) return BadRequest(new { Message = "No se pudo insertar la Tarea" });
            return Created("", new { Message = "Insertado correctamente..." });

        }

        [HttpPut("Cambiar Estado")]
        public async Task<IActionResult> UpdateEstado([FromBody] UpdateEstado request)
        {
            var result = await _tareaService.UpdateEstadoAsync(request.Id, request.TareaEstado);
            if (!result) return BadRequest(new { Message = "No se pudo actualizar el estado de la tarea" });
            return Ok( new { Message = "Actualizado correctamente..." });

        }

        [HttpDelete("Eliminar tarea")]
        public async Task<ActionResult<bool>> DeleteTareas(int id)
        {
            var result = await _tareaService.DeleteTareaAsync(id);
            if (!result) return BadRequest(new { Mesagge = "No se pudo eliminar la tarea" });
            return Ok(new { Message = "TareaEliminada" });

        }





    }
}

    
