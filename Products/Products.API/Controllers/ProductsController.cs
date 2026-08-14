using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Commands.Products;
using Products.Application.ProductsCommands;
using Products.Application.Queries.Products;
using Products.Core.Dto;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await mediator.Send(new GetAllProductQueries());
            if (result!=null)
            {
                return Ok(result);
            }
            return NotFound("no data found");
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> SaveProducts([FromBody] ProductDto productDto)
        {
            var result = await mediator.Send(new AddProductCommands(productDto));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("duplicate data");
        }
        [HttpPut("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProducts([FromRoute]int id)
        {
            var result = await mediator.Send(new DeleteProductCommands(id));

            if (result != null)
            {
                return Ok("Product deleted successfully");
            }
            return NotFound("duplicate data");
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var result = await mediator.Send(new GetProductByIdQueries(id));

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("Product not found");
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            var result = await mediator.Send(new UpdateProductCommands(productDto));

            if (result != null)
            {
                return Ok("update sucessfully");
            }

            return NotFound("Product not found");
        }
    }
}
