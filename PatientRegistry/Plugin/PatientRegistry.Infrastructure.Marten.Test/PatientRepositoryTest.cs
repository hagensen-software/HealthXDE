using HealthXDE.API;
using HealthXDE.Infrastructure.Abstractions;
using HealthXDE.Infrastructure.Marten;
using HealthXDE.Infrastructure.Mediatr;
using Microsoft.Extensions.DependencyInjection;
using HealthXDE.Domain.Patient;
using PatientRegistry.Domain.General;
using PatientRegistry.Infrastructure.Abstractions;
using Testcontainers.PostgreSql;
using HealthXDE.Domain.Gender;

namespace PatientRegistry.Infrastructure.Marten.Test;

public class PatientRepositoryTest : IAsyncLifetime
{
    private ServiceCollection services = new();

    private readonly PostgreSqlContainer postgreSqlContainer = new PostgreSqlBuilder().Build();

    public async Task InitializeAsync()
    {
        await postgreSqlContainer.StartAsync();

        services
            .AddHealthXDE(cfg =>
            {
                cfg.RegisterApplication("patientregistry", new PatientRegistryApplication());
            })
            .AddGeneralPatientRegistryDomain()
            .AddMartenInfrastructure(postgreSqlContainer.GetConnectionString())
            .AddMediatrInfrastructure()
            .AddScoped<IPatientRepository<Patient>, MartenPatientRepository<Patient>>();
    }

    public Task DisposeAsync()
    {
        return postgreSqlContainer.DisposeAsync().AsTask();
    }

    [Fact]
    public async Task Given_PatientId_When_PatientIsCreated_And_AddedToRepository_Then_SamePatientCanBeRetrieved()
    {
        var patientId = new PatientId(Guid.NewGuid());

        using var serviceProvider = services.BuildServiceProvider();
        using (var scope = serviceProvider.CreateScope())
        {
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var repository = scope.ServiceProvider.GetRequiredService<IPatientRepository<Patient>>();

            var patient = Patient.CreateNewPatient(patientId);
            await repository.Add(patient);
            await unitOfWork.SaveChangesAsync(CancellationToken.None);
        }

        using (var scope = serviceProvider.CreateScope())
        {
            var repository = scope.ServiceProvider.GetRequiredService<IPatientRepository<Patient>>();
            var retrievedPatient = await repository.Get(patientId);

            Assert.NotNull(retrievedPatient);
            Assert.Equal(patientId, retrievedPatient.Id);
        }
    }

    [Fact]
    public async Task Given_PatientId_When_PatientIsCreated_And_GenderIsChanged_And_AddedToRepository_Then_SamePatientCanBeRetrieved()
    {
        var patientId = new PatientId(Guid.NewGuid());

        using var serviceProvider = services.BuildServiceProvider();
        using (var scope = serviceProvider.CreateScope())
        {
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var repository = scope.ServiceProvider.GetRequiredService<IPatientRepository<Patient>>();

            var patient = Patient.CreateNewPatient(patientId);
            patient.ChangeGender(AdministrativeGenderCoding.ValueSet.Male);
            await repository.Add(patient);
            await unitOfWork.SaveChangesAsync(CancellationToken.None);
        }

        using (var scope = serviceProvider.CreateScope())
        {
            var repository = scope.ServiceProvider.GetRequiredService<IPatientRepository<Patient>>();
            var retrievedPatient = await repository.Get(patientId);

            Assert.NotNull(retrievedPatient);
            Assert.Equal(patientId, retrievedPatient.Id);
            Assert.Equal(AdministrativeGenderCoding.ValueSet.Male, retrievedPatient.Gender);
        }
    }
}