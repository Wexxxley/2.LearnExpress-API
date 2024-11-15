using LearnExpress.Application.DTOs;
using LearnExpress.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDTO>> GetAllAsync(); //sem paginacao
        Task<CategoryResponseDTO> GetByIDAsync(int id);
        Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO requestDto);
        Task<CategoryResponseDTO> UpdateAsync(int id, CategoryRequestDTO requestDto);
        Task<CategoryResponseDTO> DeleteAsync(int id);
    }
}
