using BookStore.Bll.Contracts.Repositories;
using BookStore.Dal.Context;
using BookStore.Dal.Repositoies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Dal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(connectionString, mg => mg.MigrationsAssembly("BookStore.Dal"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            return services;
        }
    }
}
