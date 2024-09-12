using API.Repositories;
using API.Repositories.IRepositories;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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

        app.MapControllers();

        app.Run();
    }
}
