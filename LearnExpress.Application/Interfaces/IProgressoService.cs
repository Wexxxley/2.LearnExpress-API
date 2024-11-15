using LearnExpress.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Interfaces
{
    public interface IProgressoService
    {
        Task<IEnumerable<ProgressoResponseDTO>> GetProgressosFiltered(int idUser, int idUsuario);
        Task<ProgressoResponseDTO> UpdateProgresso(int idUser, int idCurso, ProgressoRequestDTO requestDto);
    }
}
