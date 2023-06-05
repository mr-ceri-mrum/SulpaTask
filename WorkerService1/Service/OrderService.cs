using SulpakTask.Interfase;

namespace WorkerService1.Service;

public class OrderService : BackgroundService, IOrderSevice
{
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }

    public bool CheckOrders()
    {
        throw new NotImplementedException();
    }
}