using AutoMapper;
using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using LearnExpress.Domain.Entities;
using LearnExpress.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Services
{
    public class ProgressoService : IProgressoService
    {
        private readonly IProgressoRepository _repository;
        private readonly IMapper _mapper;

        public ProgressoService(IProgressoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgressoResponseDTO>> GetProgressosFiltered(int idUser, int idUsuario)
        {
            var items = await _repository.GetFiltered(idUser, idUsuario);
            return _mapper.Map<IEnumerable<ProgressoResponseDTO>>(items);
        }

        public async Task<ProgressoResponseDTO> UpdateProgresso(int idUser, int idCurso, ProgressoRequestDTO requestDto)
        {
            var progresso = _mapper.Map<PorcentConcluCurso>(requestDto);
            progresso.Idcurso = idCurso;
            progresso.Idusuario = idUser;
            await _repository.UpdateAsync(progresso);
            return _mapper.Map<ProgressoResponseDTO>(progresso);
        }
    }
}
