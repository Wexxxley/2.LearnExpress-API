using LearnExpress.API.Models;
using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LearnExpress.API.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CursoResponseDTO>>> GetCursosAsync([FromQuery] QueryParameters parameters)
        {
            var items = await _cursoService.GetAllPaginadoAsync(parameters.PageSize, parameters.PageNumber);
            var paginationHeader = new PaginationHeader(items.TotalCount, items.PageSize, items.CurrentPage, items.TotalPages, items.HasPrevious, items.HasNext);
            Response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader));
            return Ok(items);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CursoResponseDTO>> GetCursoByIdAsync(int id)
        {
            var item = await _cursoService.GetByIDAsync(id);
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CursoResponseDTO>> CreateCursoAsync(CursoRequestDTO requestDto)
        {
            var item = await _cursoService.CreateAsync(requestDto);
            return Ok(item);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CursoResponseDTO>> UpdateCursoAsync(int id, CursoRequestDTO requestDto)
        {
            var item = await _cursoService.UpdateAsync(id, requestDto);
            return Ok(item);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<CursoResponseDTO>> DeleteCursoAsync(int id)
        {
            var item = await _cursoService.DeleteAsync(id);
            return Ok(item);
        }
    }
}