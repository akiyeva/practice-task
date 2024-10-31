using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Task.Application.Dtos;
using Task.Domain.Entities;
using Task.Persistence.Repositories.Abstraction;

namespace Task.Application.Services;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductManager(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> AddAsync(ProductCreateDto createDto)
    {
        var productEntity = _mapper.Map<Product>(createDto);
        var createdProduct = await _productRepository.CreateAsync(productEntity);
        return _mapper.Map<ProductDto>(createdProduct);
    }

    public async Task<ProductDto> DeleteAsync(int id)
    {
        var existProduct = await _productRepository.GetAsync(id);

        if (existProduct == null) throw new Exception("Not found");

        var deletedProduct = await _productRepository.RemoveAsync(existProduct);

        return _mapper.Map<ProductDto>(deletedProduct);
    }

    public async Task<ProductDto?> GetAsync(int id)
    {
        var productEntity = await _productRepository.GetAsync(id);

        if (productEntity == null) throw new Exception("Not found");

        return _mapper.Map<ProductDto>(productEntity);
    }

    public async Task<ProductDto?> GetAsync(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        var productEntity = await _productRepository.GetAsync(predicate, include);

        if (productEntity == null) throw new Exception("Not found");

        return _mapper.Map<ProductDto>(productEntity);
    }

    public async Task<ProductListDto> GetListAsync(Expression<Func<Product, bool>>? predicate = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, 
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        var productListEntity = await _productRepository.GetListAsync(predicate, include, orderBy);

        if (productListEntity == null) throw new Exception("Not found");

        return _mapper.Map<ProductListDto>(productListEntity);
    }

    public async Task<ProductDto> UpdateAsync(int id, ProductUpdateDto updateDto)
    {
        var existProduct = await _productRepository.GetAsync(id);

        if (existProduct == null) throw new Exception("Not found");

        existProduct = _mapper.Map(updateDto, existProduct);

        var updatedProduct = await _productRepository.UpdateAsync(existProduct);

        return _mapper.Map<ProductDto>(updatedProduct);
    }
}