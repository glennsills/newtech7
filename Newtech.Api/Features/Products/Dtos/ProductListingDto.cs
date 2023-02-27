namespace Newtech.Api.Features.Products.Dtos;

public record ProductListingDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string ImageURL { get; init; }
    public decimal Price { get; init; }
    public int Qty { get; init; }

    public int ProductCategoryId { get; init; }
    public required string CategoryName { get; init; }
}
