using SulpakTask.Models;

namespace SulpakTask.Dtos;

public class ProductDto
{
    public int Price { get; set; }
    public bool InStock { get; set; } = true;
}