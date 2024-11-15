using LearnExpress.API.Models;
using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LearnExpress.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AulaController : Controller
    {
        private IAulaService _aulaService;

        public AulaController(IAulaService aulaService)
        {
            this._aulaService = aulaService;
        }

        [HttpGet("GetAllPaginado")]
        public async Task<ActionResult<IEnumerable<AulaResponseDTO>>> GetAllPaginadoAsync([FromQuery]QueryParameters parameters)
        {
            var items = await _aulaService.GetAllPaginadoAsync(parameters.PageSize, parameters.PageNumber);
            var paginationHeader = new PaginationHeader(items.TotalCount, items.PageSize, items.CurrentPage, items.TotalPages, items.HasPrevious, items.HasNext);
            Response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader));
            return Ok(items);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<AulaResponseDTO>> GetByIdAsync(int id)
        {
            var item = await _aulaService.GetByIDAsync(id);
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<AulaResponseDTO>> CreateAsync(AulaRequestDTO request)
        {
            var item = await _aulaService.CreateAsync(request);
            return Ok(item);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<AulaResponseDTO>> UpdateAsync(int id, AulaRequestDTO request)
        {
            var item = await _aulaService.UpdateAsync(id, request);
            return Ok(item);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<AulaResponseDTO>> DeleteAsync(int id)
        {
            var item = await _aulaService.DeleteAsync(id);
            return Ok(item);
        }
    }
}
