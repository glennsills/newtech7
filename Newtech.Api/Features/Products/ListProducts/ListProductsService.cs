using Ardalis.Result;
using AutoMapper;
using Newtech.Api.Features.Products.Dtos;
using Newtech.Api.Features.Products.Repository;
using System.Collections.Generic;

namespace Newtech.Api.Features.Products.ListProducts;

public class ListProductsService : IListProductsService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _autoMapper;
    private readonly ILogger<ListProductsService> _logger;

    public ListProductsService(IProductRepository repository, IMapper autoMapper, ILogger<ListProductsService> logger)
    {
        _repository = repository;
        _autoMapper = autoMapper;
        _logger = logger;
    }
    public async Task<Result<IEnumerable<ProductListingDto>>> GetProductListings()
    {
        try
        {
            var data = await _repository.GetProducts();
            var mappedData = _autoMapper.Map <IEnumerable<ProductListingDto>>(data);
            if (mappedData ==  null || mappedData.Count() == 0)
            { 
                return Result.NotFound();
            }
            return Result<IEnumerable<ProductListingDto>>.Success(mappedData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Result.Error(ex.Message);
        }
    }
}
