using System.ComponentModel.DataAnnotations;

namespace API.Model.Dtos;

public record CreateCarDto
{
    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    [Range(1886, 2100)]
    public int Year { get; set; }
}

public record UpdateCarDto
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}


public record UpdateCarYearDto
{
    public int NewYear { get; set; }
}


public record CarDto
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

