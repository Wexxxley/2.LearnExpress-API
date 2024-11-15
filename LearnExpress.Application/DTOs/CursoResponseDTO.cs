using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.DTOs
{
    public class CursoResponseDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Professor { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int HorasTotais { get; set; }
        public double Preco { get; set; }
    }
}
