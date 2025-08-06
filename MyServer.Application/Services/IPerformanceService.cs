using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

namespace MyServer.Application.Services
{
    public interface IPerformanceService
    {
        Task<int> RunPerformanceLoop();
    }
}
