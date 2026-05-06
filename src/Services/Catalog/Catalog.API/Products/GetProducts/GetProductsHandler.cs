namespace Catalog.API.Products.GetProducts
{
    public record GetProudctsQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler (IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProudctsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProudctsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductsQuery called with request: {Request}", request);
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(products);
        }
    }
}
