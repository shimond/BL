
namespace API.Services;

public class GarageService(GarageContext context, IMapper mapper) : IGarageService
{

    public async Task<List<CarDto>> GetCarsAsync(int pageNumber, int pageSize)
    {
        return await context.Cars
            .OrderBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(c => mapper.Map<CarDto>(c))
            .ToListAsync();
    }

    public async Task<CarDto?> GetCarByIdAsync(int id)
    {
        var car = await context.Cars.FindAsync(id);    
        return mapper.Map<CarDto>(car);
    }

    public async Task<CarDto> AddCarAsync(CreateCarDto carDto)
    {
        var car = mapper.Map<Car>(carDto);
        context.Cars.Add(car);
        await context.SaveChangesAsync();
        return mapper.Map<CarDto>(car);
    }

    public async Task<CarDto> UpdateCarAsync(int id, UpdateCarDto carDto)
    {
        var car = await context.Cars.Where(x=>x.Id == id).FirstOrDefaultAsync();
        if (car == null)
        {
            throw new Exception();
        }

        mapper.Map(carDto, car);
        await context.SaveChangesAsync();
        return mapper.Map<CarDto>(car);
    }

    public async Task DeleteCarAsync(int id)
    {
        await context.Cars.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

 
    public async Task<CarDto> UpdateCarYearAsync(int id, int year)
    {
        await context.Cars.Where(x => x.Id == id).ExecuteUpdateAsync(x => x.SetProperty(o => o.Year , year));
        var item = await context.Cars.Where(x => x.Id == id).FirstOrDefaultAsync();
        return mapper.Map<CarDto>(item);
    }

 
}