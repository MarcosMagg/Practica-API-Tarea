using PracticaAPI.Domain.DTO;
using PracticaAPI.Domain.Entities;

namespace PracticaAPI.Service.Interface
{
    public interface ITareaService
    {
        public Task<List<Tarea>> GetAllTareasAsync();
        public Task<bool> AddTareaAsync(Tarea tarea);
        public Task<bool> UpdateTareaAsync(int id, TareaDTO tarea);
        public Task<bool> UpdateEstadoAsync(int id, TareaDTO tarea);
        public Task<bool> DeleteTareaAsync(int id);

    }
}
