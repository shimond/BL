using API.Model.Dtos;

namespace API.Interfaces;

public interface IGarageService
{
    Task<List<CarDto>> GetCarsAsync(int pageNumber, int pageSize);
    Task<CarDto?> GetCarByIdAsync(int id);
    Task<CarDto> AddCarAsync(CreateCarDto carDto);
    Task<CarDto> UpdateCarAsync(int id, UpdateCarDto carDto);
    Task<CarDto> UpdateCarYearAsync(int id, int year);
    Task  DeleteCarAsync(int id);
    Task<CarServiceDto> AddCarServiceAsync(int carId, CreateCarServiceDto serviceDto);
}
