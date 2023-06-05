namespace SulpakTask.Models;

public enum StatusOrder 
{
    Expectations,
    Accepted,
    Canceled
}

public class Order
{
    
    public int Id { get; set; }
    public DateTime OrderDateTime { get; set; }
    public string СustomerName { get; set; }
    public int ProductId { get; set; }
    public StatusOrder StatusOrder { get; set; }
    
}