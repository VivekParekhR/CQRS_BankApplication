#region Using
using Bank.Core.Extention;
using Bank.Infrastructure.ServiceContainer; 
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Add Mediator
builder.Services.AddMediatorRegistrationGroup();

// Add repositories and context  
builder.Services.AddServices(builder.Configuration);
 
// behaviour
builder.Services.AddBehaviourDependencyGroup();

// Add MassTransit to publish/subscribe message from RabbitMQ server
builder.Services.AddMassTransitGroup();

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
