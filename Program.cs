using Dotnet_6.Data;
using Dotnet_6.Domain;
using Dotnet_6.Exceptions;
using Dotnet_6.Exceptions.Interface;
using Dotnet_6.Interfaces;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IDriver, DriverDomain>();
        builder.Services.AddTransient<IDriverException, DriverException>();
        builder.Services.AddScoped<ITeam, TeamDomain>();
        builder.Services.AddScoped<IDriverMedia, DriverMediaDomain>();
        builder.Services.AddDbContext<ApiDbContext>(options =>
    {
        options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection"),
           assembly => assembly.MigrationsAssembly(typeof(ApiDbContext).Assembly.FullName));
    });
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}