using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Task.Application.Dtos;
using Task.Domain.Entities;

namespace Task.Application.Services;

public interface ICategoryService
{
    Task<CategoryDto?> GetAsync(int id);

    Task<CategoryDto?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);

    Task<CategoryListDto> GetListAsync(Expression<Func<Category, bool>>? predicate = null,
                                    Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
                                    Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null
                                    );

    Task<CategoryDto> AddAsync(CategoryCreateDto createDto);
    Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto updateDto);
    Task<CategoryDto> DeleteAsync(int id);
}