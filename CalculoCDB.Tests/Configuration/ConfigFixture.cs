using CalculoCDB.Application.Interfaces;
using CalculoCDB.Application.Service;
using CalculoCDB.Application.Validation;
using CalculoCDB.Domain.Interfaces.Service;
using CalculoCDB.Domain.Models;
using CalculoCDB.Domain.Service;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDB.Tests.Configuration
{
    public class ConfigFixture
    {
        public ServiceProvider ServiceProvider { get; }

        public ConfigFixture()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IValidator<Cdb>, CdbValidation>();           
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
