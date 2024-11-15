using AutoMapper;
using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using LearnExpress.Domain.Entities;
using LearnExpress.Domain.Interfaces;
using LearnExpress.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Categorium> _repository;
        private readonly IMapper _mapper;
        public CategoryService(IRepository<Categorium> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryResponseDTO>>(items);   
        }

        public async Task<CategoryResponseDTO> GetByIDAsync(int id)
        {
            var item = await _repository.GetAsync(c=>c.Id == id);  
            return _mapper.Map<CategoryResponseDTO>(item);
        }

        public async Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO requestDto)
        {
            var category = _mapper.Map<Categorium>(requestDto);
            await _repository.CreateAsync(category);
            return _mapper.Map<CategoryResponseDTO>(category);
        }

        public async Task<CategoryResponseDTO> DeleteAsync(int id)
        {
            var category = await _repository.GetAsync(c => c.Id == id);
            await _repository.DeleteAsync(category);
            return _mapper.Map<CategoryResponseDTO>(category);
        }

        public async Task<CategoryResponseDTO> UpdateAsync(int id, CategoryRequestDTO requestDto)
        {
            var category = _mapper.Map<Categorium>(requestDto);
            category.Id = id;
            await _repository.UpdateAsync(category);
            return _mapper.Map<CategoryResponseDTO>(category);
        }
    }
}