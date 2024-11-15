using LearnExpress.API.Models;
using LearnExpress.API.Models.Filters;
using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LearnExpress.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("GetAllPaginado")]
        public async Task<ActionResult<IEnumerable<PedidoResponseDTO>>> GetAllAsync([FromQuery]QueryParameters parameters, [FromQuery]PedidoFilter filter )
        {
            var items = await _pedidoService.GetPedidosPaginadoAsync(parameters.PageNumber, parameters.PageSize, filter.idUser, filter.idCurso);
            var paginationHeader = new PaginationHeader(items.TotalCount, items.PageSize, items.CurrentPage, items.TotalPages, items.HasPrevious, items.HasNext);
            Response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader));
            return Ok(items);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<PedidoResponseDTO>> GetById(int id)
        {
            var item = await _pedidoService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<PedidoResponseDTO>> CreateAsync(PedidoRequestDTO request)
        {
            var item = await _pedidoService.CreateAsync(request);
            return Ok(item);

        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<PedidoResponseDTO>> DeleteAsync(int id)
        {
            var item = await _pedidoService.DeleteAsync(id);
            return Ok(item);
        }
    }
}
