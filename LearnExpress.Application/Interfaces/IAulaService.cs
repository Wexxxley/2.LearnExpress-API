using LearnExpress.Application.DTOs;
using LearnExpress.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Interfaces
{
    public interface IAulaService
    {
        Task<PagedList<AulaResponseDTO>> GetAllPaginadoAsync(int pageSize, int pageNumber);
        Task<AulaResponseDTO> GetByIDAsync(int id);
        Task<AulaResponseDTO> CreateAsync(AulaRequestDTO requestDto);
        Task<AulaResponseDTO> UpdateAsync(int id, AulaRequestDTO requestDto);
        Task<AulaResponseDTO> DeleteAsync(int id);
    }
}
