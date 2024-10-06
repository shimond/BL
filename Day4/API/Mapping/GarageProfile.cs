namespace API.Mapping;
public class GarageProfile : Profile
{
    public GarageProfile()
    {
        CreateMap<CreateCarDto, Car>();
        CreateMap<UpdateCarDto, Car>();
        CreateMap<Car, CarDto>();
    }
}