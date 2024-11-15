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
    public class AulaService : IAulaService
    {
        private readonly IAulaRepository _repository;
        private readonly IMapper _mapper;
        public AulaService(IAulaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<AulaResponseDTO>> GetAllPaginadoAsync(int pageSize, int pageNumber)
        {
            var items = await _repository.GetAulasPaginadoAsync(pageSize, pageNumber);
            var listDto = _mapper.Map<IEnumerable<AulaResponseDTO>>(items);
            return new PagedList<AulaResponseDTO>(listDto, pageNumber, pageSize, items.TotalPages, items.TotalCount);
        }

        public async Task<AulaResponseDTO> GetByIDAsync(int id)
        {
            var item = await _repository.GetAsync(c => c.Id == id);
            return _mapper.Map<AulaResponseDTO>(item);
        }

        public async Task<AulaResponseDTO> CreateAsync(AulaRequestDTO requestDto)
        {
            var aula = _mapper.Map<Aula>(requestDto);
            await _repository.CreateAsync(aula);
            return _mapper.Map<AulaResponseDTO>(aula);
        }

        public async Task<AulaResponseDTO> DeleteAsync(int id)
        {
            var aula = await _repository.GetAsync(c => c.Id == id);
            await _repository.DeleteAsync(aula);
            return _mapper.Map<AulaResponseDTO>(aula);
        }

        public async Task<AulaResponseDTO> UpdateAsync(int id, AulaRequestDTO requestDto)
        {
            var aula = _mapper.Map<Aula>(requestDto);
            aula.Id = id;
            await _repository.UpdateAsync(aula);
            return _mapper.Map<AulaResponseDTO>(aula);
        }
    }
}
