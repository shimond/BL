
using API.Interfaces;
using API.Model.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace API.Apis;

public static class CarsApi
{
    public static void MapCarsApis(this IEndpointRouteBuilder app)
    {
        var carsApi = app.MapGroup("cars");

        carsApi.MapGet("", async Task<Ok<List<CarDto>>> (IGarageService service, [AsParameters] PaginationRequest pagination) =>
        {
            var result = await service.GetCarsAsync(pagination.PageIndex, pagination.PageSize);
            return TypedResults.Ok(result);
        });

        carsApi.MapGet("{id}", async Task<Results<Ok<CarDto>, NotFound>> (IGarageService service, int id) =>
        {
            var car = await service.GetCarByIdAsync(id);
            return car != null ? TypedResults.Ok(car) : TypedResults.NotFound();
        });

        carsApi.MapPost("", async Task<Results<BadRequest<List<ValidationResult>>, Created<CarDto>>> (IGarageService service, CreateCarDto carDto) =>
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(carDto);
            if (!Validator.TryValidateObject(carDto, validationContext, validationResults, true))
            {
                return TypedResults.BadRequest(validationResults);
            }

            var createdCar = await service.AddCarAsync(carDto);
            return TypedResults.Created($"/cars/{createdCar.Id}", createdCar);
        });

        carsApi.MapPut("{id}", async Task<Ok<CarDto>> (IGarageService service, int id, UpdateCarDto carDto) =>
        {
            var updated = await service.UpdateCarAsync(id, carDto);
            return TypedResults.Ok(updated);
        });


        carsApi.MapPatch("{id}/year", async Task<Ok<CarDto>> (IGarageService service, int id, UpdateCarYearDto updateCarYearDto) =>
        {
            var updated = await service.UpdateCarYearAsync(id, updateCarYearDto.NewYear);
            return TypedResults.Ok(updated);
        });


        carsApi.MapDelete("{id}", async (IGarageService service, int id) =>
        {
            await service.DeleteCarAsync(id);
            return TypedResults.NoContent();
        });
    }
}
