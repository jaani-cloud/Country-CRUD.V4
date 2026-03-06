
using App.Commons;
using App.Services.Classes;
using App.Services.Interfaces;
using Infra.Data;
using Infra.Repos.Classes;
using Infra.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddScoped<ICountryRepo, CountryRepo>();
        builder.Services.AddScoped<IStateRepo, StateRepo>();
        builder.Services.AddScoped<ICityRepo, CityRepo>();

        builder.Services.AddAutoMapper(typeof(Mapping));

        builder.Services.AddScoped<ICountryService, CountryService>();
        builder.Services.AddScoped<IStateService, StateService>();
        builder.Services.AddScoped<ICityService, CityService>();

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
