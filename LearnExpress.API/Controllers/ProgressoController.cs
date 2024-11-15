using LearnExpress.API.Models.Filters;
using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnExpress.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgressoController : Controller
    {
        private IProgressoService _progressoService;
        public ProgressoController(IProgressoService progressoService)
        {
            _progressoService = progressoService;
        }

        [HttpGet("GetFiltered")]
        public async Task<ActionResult<IEnumerable<ProgressoResponseDTO>>> GetFiltered([FromQuery]ProgressoFilter filter)
        {
            var items = await _progressoService.GetProgressosFiltered(filter.idUser, filter.idCurso);
            return Ok(items);
        }

        [HttpPut("UpdateProgresso")]
        public async Task<ActionResult<ProgressoResponseDTO>> UpdateProgresso(int idUser, int idCurso, ProgressoRequestDTO requestDto)
        {
            var item = await _progressoService.UpdateProgresso(idUser, idCurso, requestDto);
            return Ok(item);
        }
    }
}
