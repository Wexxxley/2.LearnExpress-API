using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.DTOs
{
    public class AulaRequestDTO
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int Duração { get; set; }

        public string Link { get; set; }

        public int Idcurso { get; set; }
    }
}
