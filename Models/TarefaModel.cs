using PW45S.Enums;

namespace PW45S.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefas Concluida { get; set; }  
    }
}
