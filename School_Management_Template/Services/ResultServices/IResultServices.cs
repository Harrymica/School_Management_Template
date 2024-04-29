using School_Management_Template.Data;

namespace School_Management_Template.Services.ResultServices
{
    public interface IResultServices
    {
        Task<List<Result>> GetAllResultAsync();
        Task<List<Result>> GetResultByIdAsync(int id);
        Task AddResultAsync(Result result);
        Task UpdateResultAsync(Result result);
        Task DeleteResultAsync(int id);
    }
}
