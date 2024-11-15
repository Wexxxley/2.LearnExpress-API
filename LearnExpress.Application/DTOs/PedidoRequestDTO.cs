using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.DTOs
{
    public class PedidoRequestDTO
    {
        public int? Idcurso { get; set; }

        public int? Idusuario { get; set; }

        public DateOnly Data { get; set; }
    }
}
