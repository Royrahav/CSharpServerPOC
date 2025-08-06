namespace MyServer.Application.Services
{
    public interface IPerformanceService
    {
        Task<int> RunPerformanceLoop();
        int RunPerformanceLoopSync();
    }
}
