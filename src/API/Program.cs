using API.Repositories;
using API.Repositories.IRepositories;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API;

public static class Program
{
    public static void Main()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        builder.Services.AddControllers();
        builder.Services.AddSingleton<INotesRepository, NotesRepository>();
        builder.Services.AddScoped<NotesService>();

        WebApplication app = builder.Build();

        if (app.Environment.IsProduction())
            app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
