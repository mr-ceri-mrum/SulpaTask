namespace SulpakTask.Models;

public class Product
{
    
    public int Id { get; set; }
    public int Price { get; set; }
    public bool InStock { get; set; } = true;
}