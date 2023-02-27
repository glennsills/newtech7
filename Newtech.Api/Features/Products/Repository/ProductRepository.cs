using Microsoft.EntityFrameworkCore;
using Newtech.Data;
using Newtech.Data.Entities;

namespace Newtech.Api.Features.Products.Repository;

public class ProductRepository : IProductRepository
{
    private readonly NewTechDbContext _context;

    public ProductRepository(NewTechDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var result = await  _context.Products.Include(p=>p.ProductCategory).ToListAsync();
        return result;
    }
}
