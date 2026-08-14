using MediatR;
using Products.Application.Interfaces;
using Products.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Commands.Products
{
    public record UpdateProductCommands(ProductDto ProductDto): IRequest<string>;
    public class UpdateProductCommandHandler(IProductRepository productRepository): IRequestHandler<UpdateProductCommands, string>
    {
        public async Task<string> Handle(UpdateProductCommands request, CancellationToken cancellationToken)
        {
            return await productRepository.UpdateProducts(request.ProductDto);
        }
    }
}
