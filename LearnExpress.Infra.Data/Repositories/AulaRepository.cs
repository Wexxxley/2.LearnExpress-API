using LearnExpress.Domain.Entities;
using LearnExpress.Domain.Interfaces;
using LearnExpress.Domain.Pagination;
using LearnExpress.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Infra.Data.Repositories
{
    public class AulaRepository : Repository<Aula>, IAulaRepository
    {
        public AulaRepository(LearnExpressContext context) : base(context)
        {
        }

        public async Task<PagedList<Aula>> GetAulasPaginadoAsync(int pageSize, int pageNumber)
        {
            var items = await GetAllAsync();
            var OrderedItems = items.OrderBy(x => x.Id).AsQueryable();
            return PagedList<Aula>.ToPagedList(OrderedItems, pageNumber, pageSize);
        }
    }
}
