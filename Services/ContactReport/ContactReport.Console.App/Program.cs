// See https://aka.ms/new-console-template for more information
using Common.Contracts.Core;
using ContactReport.Console.App;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceProvider = new ServiceCollection()
               .AddMassTransitConfiguration()
          .BuildServiceProvider();


var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("create-report", e =>
    {
        e.Consumer<CreateReportConsumer>();
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