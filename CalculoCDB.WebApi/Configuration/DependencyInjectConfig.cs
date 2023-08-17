using CalculoCDB.Application.Interfaces;
using CalculoCDB.Application.Service;
using CalculoCDB.Application.Validation;
using CalculoCDB.Domain.Factory;
using CalculoCDB.Domain.Interfaces.Service;
using CalculoCDB.Domain.Models;
using CalculoCDB.Domain.Service;
using FluentValidation;

namespace CalculoCDB.WebApi.Configuration
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection ResolverDependencies(this IServiceCollection services)
        {
           
            services.AddScoped<ICalcularCdbService, CalcularCdbService>();
            services.AddScoped<ICalcularCdbAppService, CalcularCdbAppService>();
            services.AddScoped<ICalculateCdbFactory, CalculateCdbFactory>();            
            services.AddSingleton<IValidator<Cdb>, CdbValidation>();

            return services;
        }
    }
}
