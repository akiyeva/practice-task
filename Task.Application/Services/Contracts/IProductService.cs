using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Task.Application.Dtos;
using Task.Domain.Entities;

namespace Task.Application.Services;

public interface IProductService
{
    Task<ProductDto?> GetAsync(int id);

    Task<ProductDto?> GetAsync(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null);

    Task<ProductListDto> GetListAsync(Expression<Func<Product, bool>>? predicate = null,
                                    Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
                                    Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null
                                    );

    Task<ProductDto> AddAsync(ProductCreateDto createDto);
    Task<ProductDto> UpdateAsync(int id, ProductUpdateDto updateDto);
    Task<ProductDto> DeleteAsync(int id);
}