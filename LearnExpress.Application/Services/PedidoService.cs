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
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _repository;
        private IMapper _mapper;

        public PedidoService(IPedidoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedList<PedidoResponseDTO>> GetPedidosPaginadoAsync(int pageNumber, int pageSize, int idUser, int idCurso)
        {
            var items = await _repository.GetPedidosPaginadoAsync(pageSize, pageNumber, idUser, idCurso);
            var listDto = _mapper.Map<IEnumerable<PedidoResponseDTO>>(items);
            return new PagedList<PedidoResponseDTO>(listDto, pageNumber, pageSize, items.TotalPages, items.TotalCount);
        }

        public async Task<PedidoResponseDTO> GetByIdAsync(int id)
        {
            var item = await _repository.GetAsync(x => x.Id == id);
            return _mapper.Map<PedidoResponseDTO>(item);
        }

        public async Task<PedidoResponseDTO> CreateAsync(PedidoRequestDTO requestDto)
        {
            var pedido = _mapper.Map<Pedido>(requestDto);
            await _repository.CreateAsync(pedido);
            return _mapper.Map<PedidoResponseDTO>(pedido);
        }

        public async Task<PedidoResponseDTO> DeleteAsync(int id)
        {
            var pedido = await _repository.GetAsync(x => x.Id == id);
            await _repository.DeleteAsync(pedido);
            return _mapper.Map<PedidoResponseDTO>(pedido);
        }
    }
}
