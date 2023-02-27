using Ardalis.Result;
using Newtech.Api.Features.Products.Dtos;

namespace Newtech.Api.Features.Products.ListProducts;

public interface IListProductsService
{
    Task<Result<IEnumerable<ProductListingDto>>> GetProductListings();
}
