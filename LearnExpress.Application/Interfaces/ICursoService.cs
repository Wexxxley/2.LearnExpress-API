using LearnExpress.Application.DTOs;
using LearnExpress.Application.Parameters;
using LearnExpress.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Interfaces
{
    public interface ICursoService
    {
        Task<PagedList<CursoResponseDTO>> GetAllPaginadoAsync(int pageSize, int pageNumber);
        Task<CursoResponseDTO> GetByIDAsync(int id);
        Task<CursoResponseDTO> CreateAsync(CursoRequestDTO requestDto);
        Task<CursoResponseDTO> UpdateAsync(int id, CursoRequestDTO requestDto);
        Task<CursoResponseDTO> DeleteAsync(int id);
    }
}
