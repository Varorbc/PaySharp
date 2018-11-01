using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PaySharp.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySharp.AspNetCore.Internal
{
    public class PaySharpBuilder : IPaySharpBuilder
    {
        private readonly IServiceCollection _services;

        public PaySharpBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public void AddOption<T>(T option) where T : class, IPaySharpOption
        {
            _services.AddScoped<IPaySharpOption>(s => option);
            _services.AddScoped<T>(s => option);
        }


        public void TryAddService<T>(T service) where T : class
        {
            _services.TryAddScoped<T>(s => service);
        }

        public void TryAddService<T, TImplementation>() where T:class where TImplementation :class, T
        {
            _services.TryAddScoped<T, TImplementation>();
        }
    }
}
