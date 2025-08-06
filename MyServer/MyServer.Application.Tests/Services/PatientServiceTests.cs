using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MyServer.Application.Interfaces;
using MyServer.Application.Services;
using MyServer.Domain.Entities;

namespace MyServer.Application.Tests.Services
{
    public class PatientServiceTests
    {
        [Fact]
        public async Task SearchPatientsAsync_ShouldReturnPatientsFromRepository()
        {
            // Arrange
            var mockPatientRepo = new Mock<IPatientRepository>();
            var mockEpisodeRepo = new Mock<IEpisodeRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<PatientService>>();

            var patients = new List<Patient>
            {
                new Patient { Code = 1, FirstName = "Alice" },
                new Patient { Code = 2, FirstName = "Bob" }
            };

            mockPatientRepo.Setup(r => r.SearchPatientsByIdentifierAsync("Test"))
                           .ReturnsAsync(patients);

            var service = new PatientService(
                mockPatientRepo.Object,
                mockEpisodeRepo.Object,
                mockMapper.Object,
                mockLogger.Object
            );

            // Act
            var result = await service.SearchPatientsAsync("Test");

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.FirstName == "Alice");
            Assert.Contains(result, p => p.Code == 2);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task SearchPatientsAsync_ShouldReturnEmptyList_WhenSearchStringIsNullOrEmpty(string searchString)
        {
            // Arrange
            var mockPatientRepo = new Mock<IPatientRepository>();
            var mockEpisodeRepo = new Mock<IEpisodeRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<PatientService>>();

            // Defensive: return empty result no matter what
            mockPatientRepo.Setup(r => r.SearchPatientsByIdentifierAsync(It.IsAny<string>()))
                           .ReturnsAsync(new List<Patient>());

            var service = new PatientService(
                mockPatientRepo.Object,
                mockEpisodeRepo.Object,
                mockMapper.Object,
                mockLogger.Object
            );

            // Act
            var result = await service.SearchPatientsAsync(searchString);

            // Assert
            Assert.Empty(result);
        }
    }
}
