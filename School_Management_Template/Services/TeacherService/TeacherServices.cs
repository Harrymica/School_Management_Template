using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using School_Management_Template.Data;
using School_Management_Template.Database;

namespace School_Management_Template.Services.TeacherService
{
    public class TeacherServices : ITeacherSercives
    {
        private readonly List<Teachers> _teachers = new List<Teachers>();
        private readonly DataContext _context;
        private readonly NavigationManager _navigation;
        private readonly IDbContextFactory<DataContext> _factory;

        public TeacherServices(DataContext context, NavigationManager navigation, IDbContextFactory<DataContext> factory)
        {
            _context = context;
            _navigation = navigation;
            _factory = factory;
        }
        public async Task AddTeacherAsync(Teachers teachers)
        {

           
           
            _context.Teachers.Add(teachers);
            await _context.SaveChangesAsync();
            _navigation.NavigateTo("TeacherPage");
        }

        public async Task DeleteTeacherAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var teacher = await db.Result.Teachers.FirstOrDefaultAsync(s => s.Id == id);
            if (teacher != null)
            {
                db.Result.Remove(teacher);
                await db.Result.SaveChangesAsync();
            }
        }

        public Task<List<Teachers>> GetAllTeacherAsync()
        {
            var result = _context.Teachers.ToListAsync();
            return result;
        }

        public async Task<Teachers> GetTeacherByIdAsync(int id)
        {

            var result = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == id);

            return result!;
        }

        public async Task UpdateTeacherAsync(Teachers teacher)
        {
            using var db = _factory.CreateDbContextAsync();
            var existingTeacher = await db.Result.Teachers.FirstOrDefaultAsync(s => s.Id == teacher.Id);//_context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (existingTeacher != null)
            {
                existingTeacher.FirstName = teacher.FirstName;
                existingTeacher.Email = teacher.Email;
                existingTeacher.State = teacher.State;
                existingTeacher.PhoneNumber = teacher.PhoneNumber;
                existingTeacher.LGA = teacher.LGA;
                existingTeacher.Age = teacher.Age;
                existingTeacher.LaststName = teacher.LaststName;
                existingTeacher.MiddleName = teacher.MiddleName;
                existingTeacher.Image = teacher.Image;
                existingTeacher.Password = teacher.Password;

                db.Result.Update(existingTeacher);
                await db.Result.SaveChangesAsync();
            }
        }

        public string GetNames(Teachers teacher)
        {
            string fullName = $"{teacher.FirstName}{teacher.LaststName}";
            string[] nameParts = fullName.Split(' '); // Split the full name into parts

            // Initialize an empty string to hold the result
            string initials = "";

            // Loop through each part of the name
            foreach (string part in nameParts)
            {
                if (part.Length > 0) // Check if the part is not empty
                {
                    // Add the first character of each part to the initials string
                    initials += part.Substring(0, 1);
                }
            }


            return fullName;
        }
        public string GetTwoLettersFromName(Teachers teacher)
        {
            var result = "";
            var firstletter = teacher.FirstName;
            var last = teacher.LaststName;


            var letters = $"{firstletter}{last}".ToList();//name.Where(char.IsLetter).ToList();
            if (letters.Count >= 2)
            {
                result += letters[0];
                result += letters[1];
            }
            else
            {
                // Handle case where name does not have enough letters
                // This could be throwing an exception, returning a default string, etc.
            }
            return result;
        }
        public string GenerateRegistrationNumber(Teachers teacher)
        {
            var random = new Random();
            DateTime currentAge = DateTime.Now;
            var twoLetters = GetTwoLettersFromName(teacher);
            return $"{twoLetters.ToUpper()}{teacher.Age.Year}/{currentAge.Year - teacher.Age.Year}";

        }
    }
}
