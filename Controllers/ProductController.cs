using MediatR;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session3.Commands;
using Session3.Models;
using Session3.Queries;

namespace Session3.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var query = new GetAllProducts();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var query = new GetProductQuery { Id = id };
            var product = await _mediator.Send(query);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

    }
}
