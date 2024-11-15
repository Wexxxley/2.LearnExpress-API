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
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;
        private IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }
        public async Task<PagedList<UsuarioResponseDTO>> GetAllPaginadoAsync(int pageSize, int pageNumber)
        {
            var items = await _repository.GetUsuariosPaginadoAsync(pageSize, pageNumber);
            var listDto = _mapper.Map<IEnumerable<UsuarioResponseDTO>>(items);
            return new PagedList<UsuarioResponseDTO>(listDto, pageNumber, pageSize, items.TotalPages, items.TotalCount);
        }

        public async Task<UsuarioResponseDTO> GetByIDAsync(int id)
        {
            var item = await _repository.GetAsync(c => c.Id == id);
            return _mapper.Map<UsuarioResponseDTO>(item);
        }

        public async Task<UsuarioResponseDTO> CreateAsync(UsuarioRequestDTO requestDto)
        {
            var user = _mapper.Map<Usuario>(requestDto);
            var item = await _repository.CreateAsync(user);
            return _mapper.Map<UsuarioResponseDTO>(user);
        }

        public async Task<UsuarioResponseDTO> DeleteAsync(int id)
        {
            var user = await _repository.GetAsync(u => u.Id == id);
            var item = _repository.DeleteAsync(user);
            return _mapper.Map<UsuarioResponseDTO>(user);
        }

        public async Task<UsuarioResponseDTO> UpdateAsync(int id, UsuarioRequestDTO requestDto)
        {
            var user = _mapper.Map<Usuario>(requestDto);
            user.Id = id;
            await _repository.UpdateAsync(user);
            return _mapper.Map<UsuarioResponseDTO>(user);
        }
    }
}