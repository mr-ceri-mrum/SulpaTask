using Microsoft.AspNetCore.Mvc;
using SulpakTask.Dtos;
using SulpakTask.Interfase;

namespace SulpakTask.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController: ControllerBase
{
   private readonly IProductService _productService;
   public ProductController(IProductService productService)
   {
      _productService = productService;
   }
   
   [HttpPost("CreateProduct")]
   public async Task<IActionResult> CreateProduct([FromForm] ProductDto request)
   {
      var order = await _productService.CreateProduct(request);
      
      return Ok(order);
      
   }
   [HttpDelete("DeleteProduct")]
   public async Task<IActionResult> DeleteProduct( int id)
   {
      if(await _productService.DeleteProduct(id)) return Ok("Продукт удолён");
      
      return BadRequest("продукт не найден");
      
   }
}