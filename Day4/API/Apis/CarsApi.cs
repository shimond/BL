using API.EndpointFilters;
using API.Validation;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace API.Apis;

public static class CarsApi
{
    public static void MapCarsApis(this IEndpointRouteBuilder app)
    {
        var carsApi = app.MapGroup("cars").AddEndpointFilter<ValidationEndpointFilter>();


        carsApi.MapGet("", async Task<Ok<List<CarDto>>> (
            IServiceProvider services,
            IGarageService service, [AsParameters] PaginationRequest pagination) =>
        {
            //var d1 = services.GetRequiredKeyedService<DbContext>("us");
            //var d2 = services.GetRequiredKeyedService<DbContext>("eu");

            var result = await service.GetCarsAsync(pagination.PageIndex, pagination.PageSize);
            return TypedResults.Ok(result);
        }).MapToApiVersion(1.0);

        carsApi.MapGet("", async Task<Ok<List<CarDto>>> (IGarageService service, [AsParameters] PaginationRequest pagination) =>
        {
            var result = await service.GetCarsAsync(pagination.PageIndex, pagination.PageSize);
            return TypedResults.Ok(new List<CarDto> { new CarDto { Id = 1, Brand = "Opel", Model = "model", Year = 1999 } });
        }).MapToApiVersion(3.0);


        carsApi.MapGet("{id}", async Task<Results<Ok<CarDto>, NotFound>> (IGarageService service, int id) =>
       {
           var car = await service.GetCarByIdAsync(id);
           return car != null ? TypedResults.Ok(car) : TypedResults.NotFound();
       });

        carsApi.MapPost("", async Task<Results<BadRequest<List<ValidationResult>>, Created<CarDto>>> (IGarageService service, CreateCarDto carDto) =>
        {

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

        carsApi.MapPost("{carId}/carServices", async Task<Results<BadRequest<List<ValidationResult>>, Created<CarServiceDto>>> (IGarageService service, int carId, CreateCarServiceDto treatmentDto) =>
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(treatmentDto);
            if (!Validator.TryValidateObject(treatmentDto, validationContext, validationResults, true))
            {
                return TypedResults.BadRequest(validationResults);
            }

            var createdTreatment = await service.AddCarServiceAsync(carId, treatmentDto);
            return TypedResults.Created($"/v2/cars/{carId}/carServices/{createdTreatment.Id}", createdTreatment);

        });
    }
}
