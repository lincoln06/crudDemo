using crudDemo2.Interfaces;
using crudDemo2.Models;
using crudDemo2.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder().ConfigureServices(Configure).Build();
var app = ActivatorUtilities.CreateInstance<App>(host.Services);
app.Start();


partial class Program
{
    private static void Configure(IServiceCollection service)
    {
        service.AddTransient<IMenu, Menu>();
        service.AddTransient<IResponseProvider, ResponseProvider>();
        service.AddTransient<IViewer,Viewer>();
    }
}