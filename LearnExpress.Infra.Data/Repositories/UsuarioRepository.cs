using LearnExpress.Domain.Entities;
using LearnExpress.Domain.Interfaces;
using LearnExpress.Domain.Pagination;
using LearnExpress.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LearnExpressContext context) : base(context)
        {
        }

        public async Task<PagedList<Usuario>> GetUsuariosPaginadoAsync(int pageSize, int pageNumber)
        {
            var items = await GetAllAsync();
            var OrderedItems = items.OrderBy(x => x.Id).AsQueryable();
            return PagedList<Usuario>.ToPagedList(OrderedItems, pageNumber, pageSize);
        }
    }
}
