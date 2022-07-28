using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P129NLayerArchitectura.Service.DTOS.CategoryDTOs;
using P129NLayerArchitectura.Service.Exceptions;
using P129NLayerArchitectura.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129NLayerArchitectura.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CategoryPostDto categoryPostDto)
        {
            await _categoryService.PostAsync(categoryPostDto);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CategoryListDto> categoryListDtos = await _categoryService.GetAllAysnc();
            return Ok(categoryListDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] CategoryPutDto categoryPutDto)
        {
            await _categoryService.PutAsync(id, categoryPutDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
