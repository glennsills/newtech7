using Newtech.Api.Features.Products.ListProducts;
using Newtech.Api.Features.Products.Repository;
using Ardalis.Result.AspNetCore;
using Newtech.Api.Features.Products.Dtos;
using System;

namespace Newtech.Api.Features.Products;

public static class ProductFeatureExtensions
{
    public static IServiceCollection AddProductServices(this IServiceCollection services)
    {
        RegisterProductListingsServices(services);

        return services;
    }

    public static WebApplication MapProductEndpoints(this WebApplication webApplication)
    {
        RegisterProductListingsEndpoint(webApplication);

        return webApplication;
    }

    private static void RegisterProductListingsEndpoint(WebApplication webApplication)
    {
        _ = webApplication.MapGet("/products", async (IListProductsService service) => {
            return (await service.GetProductListings()).ToMinimalApiResult();
        })
        .Produces(StatusCodes.Status200OK, typeof(ProductListingDto[]), "application/json")
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();
    }
    private static void RegisterProductListingsServices(IServiceCollection services)
    {
        services.AddScoped<IListProductsService, ListProductsService>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
