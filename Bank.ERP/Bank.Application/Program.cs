using Bank.Application.Behaviour;
using Bank.Application.Extention;
using Bank.Application.Container;
using Bank.Application.ServiceContainer;
using Bank.Application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MassTransit.MultiBus;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Add Mediator
builder.Services.AddMediatorRegistrationGroup(); 

// Add context  
builder.Services.AddContextGroup(builder.Configuration);

// Add repositories
builder.Services.AddRepositoryGroup();

// Add Validators
builder.Services.AddValidatorGroup();

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
