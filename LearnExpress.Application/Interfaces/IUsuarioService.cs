using LearnExpress.Application.DTOs;
using LearnExpress.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<PagedList<UsuarioResponseDTO>> GetAllPaginadoAsync(int pageSize, int pageNumber);
        Task<UsuarioResponseDTO> GetByIDAsync(int id);
        Task<UsuarioResponseDTO> CreateAsync(UsuarioRequestDTO requestDto);
        Task<UsuarioResponseDTO> UpdateAsync(int id, UsuarioRequestDTO requestDto);
        Task<UsuarioResponseDTO> DeleteAsync(int id);
    }
}
