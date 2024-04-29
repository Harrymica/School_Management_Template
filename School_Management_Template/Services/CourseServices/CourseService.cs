using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using School_Management_Template.Data;
using School_Management_Template.Database;

namespace School_Management_Template.Services.CourseServices
{
    public class CourseService : ICourseServices
    {
         private readonly List<Courses> _courses = new List<Courses>();
            private readonly DataContext _context;
            private readonly NavigationManager _navigation;
            private readonly IDbContextFactory<DataContext> _factory;

            public CourseService(DataContext context, NavigationManager navigation, IDbContextFactory<DataContext> factory)
            {
                _context = context;
                _navigation = navigation;
                _factory = factory;
            }

            public async Task AddCourseAsync(Courses course)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                _navigation.NavigateTo("coursePage"); // Assuming you have a page for courses
            }

            // Assuming you want to keep the delete functionality, adjust it to work with Courses
            public async Task DeleteCourseAsync(int id)
            {
                using var db = _factory.CreateDbContextAsync();
                var course = await db.Result.Courses.FirstOrDefaultAsync(c => c.Id == id);
                if (course != null)
                {
                    db.Result.Remove(course);
                    await db.Result.SaveChangesAsync();
                }
            }

            public Task<List<Courses>> GetAllCoursesAsync()
            {
            using var db = _factory.CreateDbContextAsync();
            var result = db.Result.Courses.ToListAsync();
                return result;
            }

            public async Task<List<Courses>> GetCourseByIdAsync(int id)
            {
                var result = await _context.Courses.Where(c => c.Id == id).ToListAsync();
            return result!;
            }

            public async Task UpdateCourseAsync(Courses course)
        {
            using var db = _factory.CreateDbContextAsync();
            var existingCourse = await db.Result.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);
            if (existingCourse != null)
            {
                existingCourse.Name = course.Name;
                existingCourse.Description = course.Description;
                existingCourse.CourseCode = course.CourseCode;

                db.Result.Update(existingCourse);
                await db.Result.SaveChangesAsync();
            }

        }

        // Update and other methods should also be adjusted to work with Courses
    }

    
}
