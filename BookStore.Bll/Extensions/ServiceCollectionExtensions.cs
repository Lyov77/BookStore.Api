using AutoMapper;
using BookStore.Bll.Contracts.Services;
using BookStore.Bll.Implementations.Services;
using BookStore.Core.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Bll.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();

            return services;
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new BookProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}