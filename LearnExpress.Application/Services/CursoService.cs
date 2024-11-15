using AutoMapper;
using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using LearnExpress.Application.Parameters;
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
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;
        private readonly IMapper _mapper;
        public CursoService(ICursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedList<CursoResponseDTO>> GetAllPaginadoAsync(int pageSize, int pageNumber)
        {
            var items = await _repository.GetCursosPaginadoAsync(pageSize, pageNumber);
            var listDto = _mapper.Map<IEnumerable<CursoResponseDTO>>(items);
            return new PagedList<CursoResponseDTO>(listDto, pageNumber, pageSize, items.TotalPages, items.TotalCount);   
        }

        public async Task<CursoResponseDTO> GetByIDAsync(int id)
        {
            var item = await _repository.GetAsync(c => c.Id == id);
            return _mapper.Map<CursoResponseDTO>(item);
        }

        public async Task<CursoResponseDTO> CreateAsync(CursoRequestDTO requestDto)
        {
            var curso = _mapper.Map<Curso>(requestDto);
            await _repository.CreateAsync(curso);
            return _mapper.Map<CursoResponseDTO>(curso);
        }

        public async Task<CursoResponseDTO> UpdateAsync(int id, CursoRequestDTO requestDto)
        {
            var curso = _mapper.Map<Curso>(requestDto);
            curso.Id = id;
            await _repository.UpdateAsync(curso);
            return _mapper.Map<CursoResponseDTO>(curso);
        }

        public async Task<CursoResponseDTO> DeleteAsync(int id)
        {
            var curso = await _repository.GetAsync(c => c.Id==id);
            await _repository.DeleteAsync(curso);
            return _mapper.Map<CursoResponseDTO>(curso);
        }
    }
}
