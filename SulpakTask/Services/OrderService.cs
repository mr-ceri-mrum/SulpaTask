using Microsoft.EntityFrameworkCore;
using SulpakTask.Data;
using SulpakTask.Dtos;
using SulpakTask.Interfase;
using SulpakTask.Models;

namespace SulpakTask.Services;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    public OrderService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> CheckInStock(int productId)
    {
       var cheks = await _context.Products.FirstOrDefaultAsync(p => p.InStock == true);
       if (cheks != null)
       {
           return true;
       }

       return false;
    }

    public async Task<Order> CreateOrder(OrderDto orderDto)
    {
        bool check = await CheckInStock(orderDto.ProductId);
        Task checkOrder = Task.Run(() => CheckInStock(orderDto.ProductId));
        await Task.WhenAll(checkOrder);
        if (check)
        {
            DateTime now = DateTime.Now;
            var productId = await _context.Products.FirstOrDefaultAsync(p => 
                p.Id == orderDto.ProductId && p.InStock == true);
            if (productId != null)
            {
                var order = new Order
                { 
                    СustomerName = orderDto.СustomerName, 
                    StatusOrder = StatusOrder.Expectations, 
                    ProductId = orderDto.ProductId, 
                    OrderDateTime = now
                };
                _context.Order.Add(order);
                await _context.SaveChangesAsync();
                return order;
            }
            return null!;
        }

        return null;
    }

    public async Task<Order?> CancelOrdersService(int id)
    {
        Task<bool> checkInStockTask = Task.Run(() => CheckInStock(id));
        await Task.WhenAll(checkInStockTask);
        bool isItemInStock = await checkInStockTask;
        
        if (!isItemInStock)
        {
            await DeleteOrder(id);
        }

        return null;
        
    }

    public async Task<bool> DeleteOrder(int orderId)
    {
        var order = await _context.Order.FirstOrDefaultAsync(o => o.Id == orderId);
        if (order == null || order.StatusOrder == StatusOrder.Accepted)
        {
            return false;
        }

        _context.Order.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}