using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Application.Interfaces;
using Microsoft.Extensions.Logging;
using MyServer.Domain.Entities;

namespace MyServer.Application.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly ILogger<PerformanceService> _logger;

        public PerformanceService(
            ILogger<PerformanceService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> RunPerformanceLoop()
        { 
            int n = 0;
            while (n < 100000000)
            {
                n++;
            }
            _logger.LogTrace("Performance loop ended!");
            return 0;
        }
    }
}
