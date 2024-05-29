
using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProdcutByIdResult>;
public record GetProdcutByIdResult(Product Product);

internal class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProdcutByIdResult>
{
    public async Task<GetProdcutByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken)?? throw new ProductNotFoundException(request.Id);
        return new GetProdcutByIdResult(product);
    }
}

