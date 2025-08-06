using Microsoft.EntityFrameworkCore;
using MyServer.Domain.Entities;
using MyServer.Infrastructure.Persistence;
using MyServer.Infrastructure.Repositories;

namespace MyServer.Application.Tests.Repositories
{
    public class PatientRepositoryTests
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + System.Guid.NewGuid())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task SearchPatientsByIdentifierAsync_ShouldReturnMatchingPatients()
        {
            // Arrange
            using var context = CreateInMemoryDbContext();

            var patient = new Patient { Code = 1, FirstName = "Alice" };
            var identifier = new PatientIdentifier
            {
                Iicode = 1,
                Iipid = "TEST-123",
                Patient = patient
            };

            context.Patients.Add(patient);
            context.PatientIdentifier.Add(identifier);
            await context.SaveChangesAsync();

            var repo = new PatientRepository(context);

            // Act
            var result = await repo.SearchPatientsByIdentifierAsync("TEST");

            // Assert
            Assert.Single(result);
            Assert.Equal("Alice", result.First().FirstName);
        }
    }
}
