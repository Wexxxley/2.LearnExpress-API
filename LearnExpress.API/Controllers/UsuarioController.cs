using LearnExpress.API.Models;
using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using LearnExpress.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace LearnExpress.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService service)
        {
            _usuarioService = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetUsuariosAsync([FromQuery] QueryParameters parameters)
        {
            var items = await _usuarioService.GetAllPaginadoAsync(parameters.PageSize, parameters.PageNumber);
            var paginationHeader = new PaginationHeader(items.TotalCount, items.PageSize, items.CurrentPage, items.TotalPages, items.HasPrevious, items.HasNext);
            Response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader));
            return Ok(items);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<UsuarioResponseDTO>> GetUsuarioByIdAsync(int id)
        {
            var item = await _usuarioService.GetByIDAsync(id);
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UsuarioResponseDTO>> CreateUsuarioAsync(UsuarioRequestDTO requestDto)
        {
            var item = await _usuarioService.CreateAsync(requestDto);
            return Ok(item);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<UsuarioResponseDTO>> UpdateUsuarioAsync(int id, UsuarioRequestDTO requestDto)
        {
            var item = await _usuarioService.UpdateAsync(id, requestDto);
            return Ok(item);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<UsuarioResponseDTO>> DeleteUsuarioAsync(int id)
        {
            var item = await _usuarioService.DeleteAsync(id);
            return Ok(item);
        }
    }
}