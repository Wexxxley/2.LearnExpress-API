using LearnExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Domain.Interfaces
{
    public interface IProgressoRepository : IRepository<PorcentConcluCurso>
    {
        Task<IEnumerable<PorcentConcluCurso>> GetFiltered(int idUser, int idCurso);
    }
}
