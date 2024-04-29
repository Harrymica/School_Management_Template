using School_Management_Template.Data;

namespace School_Management_Template.Services.ClassServices
{
    public interface IClassServices
    {
        Task<List<ClassModel>> GetAllClassesAsync();
        Task<ClassModel> GetClassesByIdAsync(int id);
        Task AddClassesAsync(ClassModel course);
        Task UpdateClassesAsync(ClassModel classModel);
        Task DeleteClassesAsync(int id);
    }
}
