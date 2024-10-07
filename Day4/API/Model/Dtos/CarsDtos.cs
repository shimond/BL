using API.Validation;
using System.ComponentModel.DataAnnotations;

namespace API.Model.Dtos;

public record CreateCarDto : IBackendValidation
{
    [Required]
    public string Brand { get; set; }
    [Required]
    public string Model { get; set; }
    [Range(1886, 2100)]
    public int Year { get; set; }
}

public record UpdateCarDto : IBackendValidation
{
    [Required]
    public string Brand { get; set; }
    [Required]
    public string Model { get; set; }
    [Range(1886, 2100)]
    public int Year { get; set; }
}


public record UpdateCarYearDto : IBackendValidation
{
    [Range(1886, 2100)]
    public int NewYear { get; set; }
}


public record CarDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

public record CarServiceDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
}

public record CreateCarServiceDto : IBackendValidation
{
    [Required]
    public string Description { get; set; } = "";
    [Required]
    public DateTime Date { get; set; }
}