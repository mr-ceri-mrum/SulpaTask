using SulpakTask.Dtos;
using SulpakTask.Models;

namespace SulpakTask.Interfase;

public interface IProductService
{
    bool CheckPrice();
    Task<Product> CreateProduct(ProductDto productDto);
    Task<bool> DeleteProduct(int productId);
    Task<Product> UpdateProduct(ProductDto productDto);
}