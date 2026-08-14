using MediatR;
using Products.Application.Interfaces;
using Products.Core.Dto;

namespace Products.Application.Queries.Products
{
    public record GetAllProductQueries() : IRequest<List<ProductDto>>;
    public class GetAllProductQuerieHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductQueries, List<ProductDto>>
    {
        public Task<List<ProductDto>> Handle(GetAllProductQueries request, CancellationToken cancellationToken)
        { 
            return productRepository.GetAllProducts();
        } 
    }

}
