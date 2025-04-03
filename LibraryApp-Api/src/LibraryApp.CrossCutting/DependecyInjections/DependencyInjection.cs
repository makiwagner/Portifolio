using LibraryApp.Application.Handlers;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.CrossCutting.DependecyInjections;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Application
        services.AddTransient<AddBookCommandHandler>();

        // Infrastructure
        services.AddScoped<IBookRepository, BookRepository>();

        // Configure DbContext
        services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}