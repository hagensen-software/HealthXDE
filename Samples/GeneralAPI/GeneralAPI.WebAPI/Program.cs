using GeneralPatientRegistry.Application;
using HealthXDE.API;
using HealthXDE.Infrastructure.Mediatr;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHealthXDE(cfg =>
    {
        cfg.RegisterApplication("patientregistry", new PatientRegistryApplication());
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
