using LearnExpress.Application.DTOs;
using LearnExpress.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnExpress.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetAllAsync()
        {
            var items = await _categoryService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CursoResponseDTO>> GetAsync(int id)
        {
            var items = await _categoryService.GetByIDAsync(id);
            return Ok(items);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CursoResponseDTO>> CreateAsync(CategoryRequestDTO requestDTO)
        {
            var items = await _categoryService.CreateAsync(requestDTO);
            return Ok(items);
        }

        [HttpPut]
        public async Task<ActionResult<CursoResponseDTO>> UpdateAsync(int id , CategoryRequestDTO requestDTO)
        {
            var item = await _categoryService.UpdateAsync(id, requestDTO);   
            return Ok(item);
        }

        [HttpDelete]
        public async Task<ActionResult<CategoryResponseDTO>> DeleteAsync(int id)
        {
            var item = await _categoryService.DeleteAsync(id);
            return Ok(item);
        }
    }
}
