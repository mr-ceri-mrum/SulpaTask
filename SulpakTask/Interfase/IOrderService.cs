using SulpakTask.Dtos;
using SulpakTask.Models;

namespace SulpakTask.Interfase;

public interface IOrderService
{
    Task<bool> CheckInStock(int productId);
    Task<Order> CreateOrder( OrderDto orderDto);
    Task<bool> DeleteOrder(int orderId);
    Task<Order?> CancelOrdersService(int id);
}