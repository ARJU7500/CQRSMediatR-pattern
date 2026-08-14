using MediatR;
using Products.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Commands.Products
{
    public record DeleteProductCommands(int id) : IRequest<string>;

    public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommands, string>
    {
        public Task<string> Handle(DeleteProductCommands request, CancellationToken cancellationToken)
        {
            return productRepository.DeleteProducts(request.id);
        }
    }
}
