using CustomPatientRegistry.Application;
using CustomPatientRegistry.Infrastructure;
using HealthXDE.API;
using HealthXDE.Infrastructure.Mediatr;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHealthXDE(cfg =>
    {
        cfg.RegisterApplication("patientregistry", new PatientRegistryApplication());
        cfg.RegisterInfrastructure(new PatientRegistryInfrastructure());
    })
    .AddMediatrInfrastructure()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHealthXDE();
app.Run();
