using MediatR;
using Products.Application.Interfaces;
using Products.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Queries.Products
{
    public record GetProductByIdQueries(int id) : IRequest<ProductDto>;
    public class GetProductByIdQuerieHandler (IProductRepository productRepository) : IRequestHandler<GetProductByIdQueries,ProductDto>
    {
        public Task<ProductDto> Handle(GetProductByIdQueries request, CancellationToken cancellationToken)
        {
            return productRepository.GetProductById(request.id);
        }
    }
}
