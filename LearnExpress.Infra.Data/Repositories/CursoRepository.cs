using LearnExpress.Domain.Entities;
using LearnExpress.Domain.Interfaces;
using LearnExpress.Domain.Pagination;
using LearnExpress.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Infra.Data.Repositories
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(LearnExpressContext context) : base(context)
        {
        }

        public async Task<PagedList<Curso>> GetCursosPaginadoAsync(int pageSize, int pageNumber)
        {
            var items = await GetAllAsync();
            var OrderedItems = items.OrderBy(x => x.Id).AsQueryable();
            return PagedList<Curso>.ToPagedList(OrderedItems, pageNumber, pageSize);
        }
    }
}
