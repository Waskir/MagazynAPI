 using System.Reflection;
 using System.Runtime.CompilerServices;
 using MagazynAPI;
 using MagazynAPI.Entities;
 using AutoMapper;
 using MagazynAPI.Service;

 internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        builder.Services.AddControllers(); 
 
        builder.Services.AddDbContext<StorageDbContext>();
        builder.Services.AddScoped<StorageSeeder>();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped<IStorageService, StorageService>();


        var app = builder.Build();

// Configure the HTTP request pipeline.
        var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<StorageSeeder>();
        seeder.Seed();


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
