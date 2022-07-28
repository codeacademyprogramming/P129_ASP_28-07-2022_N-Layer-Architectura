using AutoMapper;
using P129NLayerArchitectura.Core.Entities;
using P129NLayerArchitectura.Core.Repositories;
using P129NLayerArchitectura.Service.DTOS.CategoryDTOs;
using P129NLayerArchitectura.Service.Exceptions;
using P129NLayerArchitectura.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P129NLayerArchitectura.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id);

            if (category == null)
                throw new ItemtNoteFoundException($"Item Not Found By Id = {id}");

            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.CommitAsync();
        }

        public async Task<List<CategoryListDto>> GetAllAysnc()
        {
            List<CategoryListDto> categoryListDtos = _mapper.Map<List<CategoryListDto>>(await _categoryRepository.GetAllAsync(c => !c.IsDeleted));

            return categoryListDtos;
        }

        public async Task<CategoryGetDto> GetById(int id)
        {
            Category category = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id, "Parent", "Children");

            if (category == null)
                throw new ItemtNoteFoundException($"Item Not Found By Id = {id}");

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }

        public async Task PostAsync(CategoryPostDto categoryPostDto)
        {
            if(await _categoryRepository.IsExistAsync(c=>!c.IsDeleted && c.Name.ToLower() == categoryPostDto.Name.Trim().ToLower()))
                throw new AlreadeEcistException($"Category Already Exist By Name = {categoryPostDto.Name}");

            Category category = _mapper.Map<Category>(categoryPostDto);
            category.Image = "Test.jpg";

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.CommitAsync();
        }

        public async Task PutAsync(int id, CategoryPutDto categoryPutDto)
        {
            Category category = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id);

            if (category == null)
                throw new ItemtNoteFoundException($"Item Not Found By Id = {id}");

            if (await _categoryRepository.IsExistAsync(c => !c.IsDeleted && c.Name.ToLower() == categoryPutDto.Name.Trim().ToLower()))
                throw new AlreadeEcistException($"Category Already Exist By Name = {categoryPutDto.Name}");

            category.Name = categoryPutDto.Name;
            category.IsMain = categoryPutDto.IsMain;
            category.ParentId = categoryPutDto.ParentId;
            category.Image = "category-1.jpg";
            category.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.CommitAsync();
        }
    }
}
