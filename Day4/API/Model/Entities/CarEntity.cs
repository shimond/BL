using Microsoft.AspNetCore.Cors.Infrastructure;

namespace API.Model.Entities;

public record CarEntity
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public List<CarServiceEntity> CarServices { get; set; } = new();
}

public record CarServiceEntity
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
}