namespace API.Mapping;
public class GarageProfile : Profile
{
    public GarageProfile()
    {
        CreateMap<CreateCarDto, CarEntity>();
        CreateMap<UpdateCarDto, CarEntity>();

        CreateMap<CarServiceEntity, CarServiceDto>().ReverseMap();
        CreateMap<CarEntity, CarDto>();
    }
}