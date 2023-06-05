using Microsoft.EntityFrameworkCore;
using SulpakTask.Data;
using SulpakTask.Dtos;
using SulpakTask.Interfase;
using SulpakTask.Models;

namespace SulpakTask.Services;

public class ProductService : IProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public bool CheckPrice()
    {
        return true;
    }

    public async Task<Product> CreateProduct(ProductDto productDto)
    {
        var product = new Product()
        {
            Price = productDto.Price,
            InStock = productDto.InStock
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public Task<Product> UpdateProduct(ProductDto productDto)
    {
        throw new NotImplementedException();
    }
}