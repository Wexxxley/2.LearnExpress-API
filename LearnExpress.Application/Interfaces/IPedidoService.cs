using LearnExpress.Application.DTOs;
using LearnExpress.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PagedList<PedidoResponseDTO>> GetPedidosPaginadoAsync(int pageNumber, int pageSize, int idUser, int idCurso);
        Task<PedidoResponseDTO> GetByIdAsync(int id);
        Task<PedidoResponseDTO> CreateAsync(PedidoRequestDTO requestDto);
        Task<PedidoResponseDTO> DeleteAsync(int id);
    }
}
