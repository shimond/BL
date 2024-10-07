using Microsoft.AspNetCore.Cors.Infrastructure;

namespace API.Infrastructure;
public class GarageContext : DbContext
{
    public GarageContext(DbContextOptions<GarageContext> options) : base(options) { }
    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<CarServiceEntity> CarServices { get; set; }
}