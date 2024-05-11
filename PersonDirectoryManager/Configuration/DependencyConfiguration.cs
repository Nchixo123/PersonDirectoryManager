using Db.Repository;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.RepositoryInterfaces;
using Services.ServiceInterfaces;


namespace PersonDirectoryManager.Configuration
{
    public static class DependencyConfiguration
    {
        public static void ConfigureDependency(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IPersonService,  PersonService>();
            builder.Services.AddDbContext<PersonDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
