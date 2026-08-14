using MediatR;
using Products.Application.Interfaces;
using Products.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.ProductsCommands
{
    public record AddProductCommands(ProductDto ProductDto) : IRequest<string>;
    public class AddProductsCommandsHandler(IProductRepository productrepo): IRequestHandler<AddProductCommands,string>
    {
        public Task<string> Handle(AddProductCommands request, CancellationToken cancellationToken)
        {
            return productrepo.AddProducts(request.ProductDto);
        }
    }
}
