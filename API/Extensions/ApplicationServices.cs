using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{

  public static class ApplicationServicesExtensions
  {

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {

      services.AddDbContext<DataContext>(options =>
      {
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddCors();
      services.AddScoped<ITokenSerivce, TokenService>();

      return services;
    }
  }
}