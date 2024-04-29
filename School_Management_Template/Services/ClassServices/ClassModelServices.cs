using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using School_Management_Template.Data;
using School_Management_Template.Database;

namespace School_Management_Template.Services.ClassServices
{
    public class ClassModelServices : IClassServices
    {
        private readonly List<ClassModel> _classModel = new List<ClassModel>();
        private readonly DataContext _context;
        private readonly NavigationManager _navigation;
        private readonly IDbContextFactory<DataContext> _factory;

        public ClassModelServices(DataContext context, NavigationManager navigation, IDbContextFactory<DataContext> factory)
        {
            _context = context;
            _navigation = navigation;
            _factory = factory;
        }

        public async Task AddClassesAsync(ClassModel classModel)
        {
            _context.ClassModels.Add(classModel);
            await _context.SaveChangesAsync();
            _navigation.NavigateTo("coursePage"); 
        }

        // Assuming you want to keep the delete functionality, adjust it to work with Courses
        public async Task DeleteClassesAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var course = await db.Result.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course != null)
            {
                db.Result.Remove(course);
                await db.Result.SaveChangesAsync();
            }
        }

        public Task<List<ClassModel>> GetAllClassesAsync()
        {
            var result = _context.ClassModels.ToListAsync();
            return result;
        }

        public async Task<ClassModel> GetClassesByIdAsync(int id)
        {
            var result = await _context.ClassModels.FirstOrDefaultAsync(c => c.Id == id);
            return result!;
        }

        public async Task UpdateClassesAsync(ClassModel classModel)
        {
            using var db = _factory.CreateDbContextAsync();
            var existingCourse = await db.Result.ClassModels.FirstOrDefaultAsync(c => c.Id == classModel.Id);
            if (existingCourse != null)
            {
                existingCourse.Name = classModel.Name;
               

                db.Result.Update(existingCourse);
                await db.Result.SaveChangesAsync();
            }

        }
    }
}
