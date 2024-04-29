using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using School_Management_Template.Data;
using School_Management_Template.Database;

namespace School_Management_Template.Services.ResultServices
{
    public class ResultService : IResultServices
    {
        private readonly List<Result> _result = new List<Result>();
       
        private readonly NavigationManager _navigation;
        private readonly IDbContextFactory<DataContext> _factory;

        public ResultService(NavigationManager navigation, IDbContextFactory<DataContext> factory)
        {
          
            _navigation = navigation;
            _factory = factory;
        }

        public async Task AddResultAsync(Result result)
        {
            using var db = _factory.CreateDbContextAsync();

            await db.Result.Results.AddAsync(result);
            await db.Result.SaveChangesAsync();
           
            _navigation.NavigateTo("ResultPage"); 
        }

        
        public async Task DeleteResultAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var result = await db.Result.Results.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                db.Result.Remove(result);
                await db.Result.SaveChangesAsync();
            }
        }

        public Task<List<Result>> GetAllResultAsync()
        {
            using var db = _factory.CreateDbContextAsync();
            var result = db.Result.Results.ToListAsync();
            return result;
        }

        public async Task<List<Result>> GetResultByIdAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var result = await db.Result.Results.Where(c => c.StudentId == id).ToListAsync();
            return result!;
        }

        public async Task UpdateResultAsync(Result result)
        {
            using var db = _factory.CreateDbContextAsync();
            var existingCourse = await db.Result.Results.FirstOrDefaultAsync(c => c.Id == result.Id);
            if (existingCourse != null)
            {
                //existingCourse.CoursesId = result.Courses.;
                //existingCourse.Description = result.Description;
                //existingCourse.CourseCode = result.CourseCode;

                db.Result.Update(existingCourse);
                await db.Result.SaveChangesAsync();
            }

        }

      
    }

}
