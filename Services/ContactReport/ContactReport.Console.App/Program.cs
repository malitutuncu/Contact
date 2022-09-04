// See https://aka.ms/new-console-template for more information
using Common.Contracts.Core;
using Common.Global.Core;
using Common.Global.DataService;
using Contact.Data;
using Contact.Data.Context;
using Contact.Data.Core;
using Contact.Data.Entities;
using ContactReport.Console.App;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
var serviceProvider = serviceCollection
           .AddMassTransitConfiguration()
           .AddDbContext<AppDbContext>(options =>
           {
               options.UseNpgsql(CoreConstants.contactDBconnectionString);
               AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
           }, ServiceLifetime.Transient)

             .AddTransient<IUnitOfWork, UnitOfWork>()
             .AddTransient(typeof(IRepository<>), typeof(GenericRepository<>))
       .BuildServiceProvider();

serviceCollection.AddScoped<CreateReportConsumer, CreateReportConsumer>();

using var serviceScope = serviceProvider.CreateScope();
var provider = serviceScope.ServiceProvider;



var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("create-report", e =>
    {
        //e.Consumer<CreateReportConsumer>(serviceProvider);
        e.Consumer(() => new CreateReportConsumer(serviceProvider.GetRequiredService<IRepository<UserReport>>(), serviceProvider.GetRequiredService<IUnitOfWork>()));
    });
});


await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("enter exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}