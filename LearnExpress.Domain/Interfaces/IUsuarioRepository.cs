using LearnExpress.Domain.Entities;
using LearnExpress.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public Task<PagedList<Usuario>> GetUsuariosPaginadoAsync(int pageSize, int pageNumber);
    }
}
