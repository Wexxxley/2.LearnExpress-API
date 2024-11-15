using System.ComponentModel.DataAnnotations;

namespace LearnExpress.API.Models.Filters
{
    public class ProgressoFilter
    {
        public int idUser { get; set; } = 0;
        public int idCurso { get; set; } = 0;
    }
}
