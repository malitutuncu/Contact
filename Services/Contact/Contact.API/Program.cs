using Common.Global.API.Middlewares;
using Contact.Business;
using Contact.Data;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddDataServices();
services.AddBusinessServices();

//services.AddMassTransit(x =>
//{
//    x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
//});

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
