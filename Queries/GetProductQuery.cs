using MediatR;
using Session3.AppDbContext;
using Session3.Models;

namespace Session3.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }

    public class GetAllProducts : IRequest<List<Product>> { }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly ProductDbContext _productDbContext;

        public GetProductQueryHandler(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productDbContext.Products.FindAsync(request.Id);
        }
    }
}
