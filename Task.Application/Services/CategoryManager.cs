using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Task.Application.Dtos;
using Task.Domain.Entities;
using Task.Persistence.Repositories.Abstraction;

namespace Task.Application.Services
{
    public class CategoryManager : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CategoryCreateDto createDto)
        {
            var categoryEntity = _mapper.Map<Category>(createDto);
            var createdCategory = await _categoryRepository.CreateAsync(categoryEntity);
            return _mapper.Map<CategoryDto>(createdCategory);
        }

        public async Task<CategoryDto> DeleteAsync(int id)
        {
            var existCategory = await _categoryRepository.GetAsync(id);

            if (existCategory == null) throw new Exception("Not found");

            var deletedCategory = await _categoryRepository.RemoveAsync(existCategory);

            return _mapper.Map<CategoryDto>(deletedCategory);
        }

        public async Task<CategoryDto?> GetAsync(int id)
        {

            var categoryEntity = await _categoryRepository.GetAsync(id);

            if (categoryEntity == null) throw new Exception("Not found");

            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task<CategoryDto?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
        {
            var categoryEntity = await _categoryRepository.GetAsync(predicate, include);

            if (categoryEntity == null) throw new Exception("Not found");

            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task<CategoryListDto> GetListAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
        {
            var categoryListEntity = await _categoryRepository.GetListAsync(predicate, include, orderBy);

            if (categoryListEntity == null) throw new Exception("Not found");

            return _mapper.Map<CategoryListDto>(categoryListEntity);
        }

        public async Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto updateDto)
        {
            var existCategory = await _categoryRepository.GetAsync(id);

            if (existCategory == null) throw new Exception("Not found");

            existCategory = _mapper.Map(updateDto, existCategory);

            var updatedCategory = await _categoryRepository.UpdateAsync(existCategory);

            return _mapper.Map<CategoryDto>(updatedCategory);
        }
    }
}
