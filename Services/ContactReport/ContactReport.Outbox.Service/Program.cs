using Common.Contracts.Core;
using ContactReport.Outbox.Service;
using MassTransit;
using Quartz;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddQuartz(configurator =>
        {
            configurator.UseMicrosoftDependencyInjectionJobFactory();

             var jobKey = new JobKey("CreateReportPublishJob");
            configurator.AddJob<CreateReportPublishJob>(options => options.WithIdentity(jobKey));

            var triggerKey = new TriggerKey("CreateReportPublishTrigger");
            configurator.AddTrigger(options => options.ForJob(jobKey)
                        .WithIdentity(triggerKey)
                        .StartAt(DateTime.UtcNow)
                        .WithSimpleSchedule(builder => builder.WithIntervalInSeconds(10).RepeatForever()));

            services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

            services.AddMassTransitConfiguration();
        });
    })
    .Build();

await host.RunAsync();



