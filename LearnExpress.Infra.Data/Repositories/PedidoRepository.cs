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
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(LearnExpressContext context) : base(context)
        {
        }

        public async Task<PagedList<Pedido>> GetPedidosPaginadoAsync(int pageSize, int pageNumber, int idUser, int idCurso)
        {
            var items = await GetAllAsync();
            var orderedItems = items.OrderBy(x => x.Id).AsQueryable();

            if (idUser != 0)
            {
                orderedItems = orderedItems.Where(p => p.Idusuario == idUser);
            }
            if (idCurso != 0)
            {
                orderedItems = orderedItems.Where(p => p.Idcurso == idCurso);
            }

            return PagedList<Pedido>.ToPagedList(orderedItems, pageNumber, pageSize);
        }
    }
}
