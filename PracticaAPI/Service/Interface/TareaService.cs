using Microsoft.EntityFrameworkCore;
using PracticaAPI.Domain.DTO;
using PracticaAPI.Domain.Entities;
using PracticaAPI.Repository;

namespace PracticaAPI.Service.Interface
{
    public class TareaService : ITareaService
    {
        private readonly ToDoContext _context;// el reandoly hace qu eno sufra modificaciones


        public TareaService(ToDoContext context)//instancia
        {
            _context = context;
        }



        public async Task<bool> AddTareaAsync(Tarea tarea)
        {
            await _context.Tareas.AddAsync(tarea);
            int rows = await _context.SaveChangesAsync();////devuelve el numero de filas que se escribieron
            return rows > 0;//devuelve true or false

        }

        public async Task<bool> DeleteTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FirstOrDefaultAsync(f=> f.Id == id);
            if (tarea == null) return false;

            tarea.Activo = false;
            int nuevo = await _context.SaveChangesAsync();

            return nuevo > 0;

        }



        public async Task<List<Tarea>> GetAllTareasAsync()
        {
            return await _context.Tareas.ToListAsync();
        }




        public async Task<bool> UpdateEstadoAsync(int id, TareaDTO tarea)
        {
            var estadoMatch = await _context.Tareas.FirstOrDefaultAsync(f => f.Id == id);
            if (estadoMatch is null) return false;
            estadoMatch.Estado = tarea.Estado;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;


        }




        public Task<bool> UpdateTareaAsync(int id, TareaDTO tarea)
        {
            throw new NotImplementedException();
        }






    }
}
