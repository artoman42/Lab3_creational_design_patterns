using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace UIL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent
            .Parent.Parent
            .FullName + "/appsettings")
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
            .Configure<UILConfiguration>(options => configuration.GetSection("UILConfiguration")
            .Bind(options))
           
            .AddServices()
            .BuildServiceProvider();
            serviceProvider.GetService<IRunner>().Run();
        }
    }
}