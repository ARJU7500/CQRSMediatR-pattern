using Products.Core.Dto;
using Products.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task<string> AddProducts(ProductDto productDto);
        Task<string> UpdateProducts(ProductDto productDto);
        Task<string> DeleteProducts(int id);
    }
}
