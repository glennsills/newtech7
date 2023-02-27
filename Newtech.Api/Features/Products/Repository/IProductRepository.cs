using Newtech.Data.Entities;

namespace Newtech.Api.Features.Products.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
}
