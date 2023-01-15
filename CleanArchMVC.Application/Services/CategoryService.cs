using System;
using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;
        private IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _repository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }
        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }


        public async Task CreateAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _repository.CreateAsync(categoryEntity);
        }


        public async Task UpdateAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _repository.UpdateAsync(categoryEntity);
        }
        public async Task RemoveAsync(int? id)
        {
            var categoryEntity = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(categoryEntity);
        }
    }
}