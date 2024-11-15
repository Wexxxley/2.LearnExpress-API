using LearnExpress.Domain.Entities;
using LearnExpress.Domain.Interfaces;
using LearnExpress.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Infra.Data.Repositories
{
    public class ProgressoRepository : Repository<PorcentConcluCurso>, IProgressoRepository
    {
        public ProgressoRepository(LearnExpressContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PorcentConcluCurso>> GetFiltered(int idUser, int idCurso)
        {
            var items = await GetAllAsync();
            var OrderedItems = items.OrderBy(p=> p.Idusuario).AsQueryable();    
            if(idUser != 0)
            {
                OrderedItems = OrderedItems.Where(p => p.Idusuario == idUser);
            }
            if(idCurso != 0)
            {
                OrderedItems = OrderedItems.Where(p => p.Idcurso == idCurso);
            }
            return OrderedItems;   
        }
    }
}
