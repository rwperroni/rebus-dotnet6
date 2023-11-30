using Rebus.Bus;
using RebusDotNet.Core.Events;
using RebusDotNet.Stock.BusHandlers;
using RebusDotNet.Stock.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

builder.AddBus(builder.Configuration);

ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
var eventBus = serviceProvider.GetRequiredService<IBus>();
eventBus.Subscribe<OrderEvent>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
