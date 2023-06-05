using Microsoft.AspNetCore.Mvc;
using SulpakTask.Dtos;
using SulpakTask.Interfase;


namespace SulpakTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("CreateOrders")]
        public async Task<IActionResult> CreateOrders([FromForm] OrderDto request)
        {
            Task checkOrder = Task.Run(() => _orderService.CheckInStock(request.ProductId));
            
            Task order = Task.Run((() => _orderService.CreateOrder(request)));
            await Task.WhenAll(checkOrder, order);
            if(checkOrder != null) return Ok(order);
        
            return BadRequest("Продукт не найден");
        }
        
        [HttpDelete("cancelOrders")]
        public async Task<ActionResult> CancelOrders(int id)
        {
           
            if ( await _orderService.CancelOrdersService(id) != null )
            {
                return BadRequest("Error");
            }

            return Ok("Заказ был отменён");
        }
    }
    
}