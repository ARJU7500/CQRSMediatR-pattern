using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Core.Dto;
using Products.Core.Entities;
using Products.Infrastructure.Peristincy;

namespace Products.Infrastructure.Reposirties
{
    public class ProductsRepository (AppDbContext _appDbContext) : IProductRepository
    {
        public async Task<List<ProductDto>> GetAllProducts()
        {
            return await _appDbContext.products.Select(x=> new ProductDto
            {
                ProductId=x.ProductId,
                ProductName=x.ProductName,
                Quntity=x.Quntity,
                BatchNo=x.BatchNo,
                ManfactureDate=x.ManfactureDate,
                Rate=x.Rate,
                CreatedDate=x.CreatedDate,
                UpdatedDate=x.UpdatedDate
            }).ToListAsync();
        }
        public async Task<ProductDto> GetProductById(int id)
        {
            return await _appDbContext.products.Select(x=>
            new ProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Quntity = x.Quntity,
                BatchNo = x.BatchNo,
                ManfactureDate = x.ManfactureDate,
                Rate = x.Rate,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).FirstOrDefaultAsync(x => x.ProductId == id);
        }
        public async Task<string> AddProducts(ProductDto productDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Quntity = productDto.Quntity,
                BatchNo = productDto.BatchNo,
                ManfactureDate = productDto.ManfactureDate,
                Rate = productDto.Rate,
                CreatedDate = DateTime.Now
            };

            _appDbContext.products.Add(product);

            await _appDbContext.SaveChangesAsync();

            return "Data saved successfully";
        }
        public async Task<string> UpdateProducts(ProductDto productDto)
        {
            var product = await _appDbContext.products
                .FirstOrDefaultAsync(x => x.ProductId == productDto.ProductId);

            if (product == null)
            {
                return "not data found";
            }

            product.ProductName = string.IsNullOrWhiteSpace(productDto.ProductName)? product.ProductName : productDto.ProductName;
            product.Quntity = product.Quntity = product.Quntity = productDto.Quntity > 0? productDto.Quntity: product.Quntity;
            product.BatchNo = string.IsNullOrWhiteSpace(productDto.BatchNo) ? product.BatchNo : productDto.BatchNo;
            product.ManfactureDate = product.ManfactureDate = productDto.ManfactureDate ?? product.ManfactureDate;
            product.Rate = productDto.Rate;
            product.UpdatedDate = DateTime.Now;
            await _appDbContext.SaveChangesAsync();
            return "data update sucessfully";
        }

        public async Task<string> DeleteProducts(int id)
        {
            var product = await _appDbContext.products.FindAsync(id);

            if (product != null)
            {
                _appDbContext.products.Remove(product);
                await _appDbContext.SaveChangesAsync();
            }
            return "data deleted";
        }
    }
}
