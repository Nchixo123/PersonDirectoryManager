using Db.Repository;
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
            builder.Services.AddScoped<IPersonRelationService, PersonRelationsService>();
            builder.Services.AddScoped<IPersonService,  PersonService>();
        }
    }
}
