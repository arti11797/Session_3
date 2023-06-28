using MediatR;
using Microsoft.EntityFrameworkCore;
using Session3.AppDbContext;
using Session3.Models;

namespace Session3.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly ProductDbContext _productDbContext;

        public CreateProductCommandHandler(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price                
            };

            _productDbContext.Products.Add(product);
            await _productDbContext.SaveChangesAsync(cancellationToken);

            return product;
        }
    }

}
