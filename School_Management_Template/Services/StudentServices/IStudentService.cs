using School_Management_Template.Data;

namespace School_Management_Template.Services.StudentServices
{
    public interface IStudentService
    {
        Task<List<Students>> GetAllStudentsAsync();
        Task<Students> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Students student);
        Task UpdateStudentAsync(Students student);
        Task DeleteStudentAsync(int id);
    }
}
