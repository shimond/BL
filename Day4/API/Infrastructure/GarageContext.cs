namespace API.Infrastructure;
public class GarageContext : DbContext
{
    public GarageContext(DbContextOptions<GarageContext> options) : base(options) { }
    public DbSet<Car> Cars { get; set; }
}