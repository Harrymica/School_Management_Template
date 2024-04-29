using School_Management_Template.Data;

namespace School_Management_Template.Services.TeacherService
{
    public interface ITeacherSercives
    {
        Task<List<Teachers>> GetAllTeacherAsync();
        Task<Teachers> GetTeacherByIdAsync(int id);
        Task AddTeacherAsync(Teachers teachers);
        Task UpdateTeacherAsync(Teachers teachers);
        Task DeleteTeacherAsync(int id);
    }
}
