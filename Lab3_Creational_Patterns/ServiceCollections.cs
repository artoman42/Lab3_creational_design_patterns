using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using Microsoft.Extensions.DependencyInjection;
namespace UIL
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceDescriptors) { 
            serviceDescriptors.AddTransient<IRunner, Runner>();
            serviceDescriptors.AddTransient<IEntrantsInput, EntrantsInput>();
            serviceDescriptors.AddTransient<IOutput, Output>();
            return serviceDescriptors;

        }
    }
}
