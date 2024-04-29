using School_Management_Template.Data;

namespace School_Management_Template.Services.CourseServices
{
    public interface ICourseServices
    {
        Task<List<Courses>> GetAllCoursesAsync();
        Task<List<Courses>> GetCourseByIdAsync(int id);
        Task AddCourseAsync(Courses course);
        Task UpdateCourseAsync(Courses course);
        Task DeleteCourseAsync(int id);

    }

}
