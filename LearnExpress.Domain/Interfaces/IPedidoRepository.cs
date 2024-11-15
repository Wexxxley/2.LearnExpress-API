using LearnExpress.Domain.Entities;
using LearnExpress.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        public Task<PagedList<Pedido>> GetPedidosPaginadoAsync(int pageSize, int pageNumber, int idUser, int idCurso);

    }
}
