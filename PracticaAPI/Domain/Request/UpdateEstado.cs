using PracticaAPI.Domain.DTO;

namespace PracticaAPI.Domain.Request
{
    public class UpdateEstado
    {
        public int Id { get; set; }
        public TareaDTO TareaEstado { get; set; }
    }
}
