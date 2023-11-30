using RebusDotNet.Orders.Extensions;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

builder.AddBus(builder.Configuration);

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
