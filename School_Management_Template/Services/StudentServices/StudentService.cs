using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using School_Management_Template.Data;
using School_Management_Template.Database;

namespace School_Management_Template.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly List<Students> _students = new List<Students>();
        private readonly DataContext _context;
        private readonly NavigationManager _navigation;
        private readonly IDbContextFactory<DataContext> _factory;

        public StudentService(DataContext context, NavigationManager navigation, IDbContextFactory<DataContext> factory)
        {
            _context = context;
            _navigation = navigation;
            _factory = factory;
        }
        public async Task AddStudentAsync(Students student)
        {
            
            student.RegisterationNumber = GenerateRegistrationNumber(student);
            student.Password = student.RegisterationNumber;
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            _navigation.NavigateTo("studentPage");
        }

        public async Task DeleteStudentAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var student =  await db.Result.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student != null)
            {
                db.Result.Remove(student);
                await db.Result.SaveChangesAsync();
            }
        }

        public Task<List<Students>> GetAllStudentsAsync()
        {
            var result = _context.Students.ToListAsync();
            return result;
        }

        public async Task<Students> GetStudentByIdAsync(int id)
        {

            var result =  await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            
            return result!;
        }

        public async Task UpdateStudentAsync(Students student)
        {
            using var db = _factory.CreateDbContextAsync();
            var existingStudent = await db.Result.Students.FirstOrDefaultAsync(s => s.Id == student.Id);//_context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.Email = student.Email;
                existingStudent.State = student.State;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.LGA = student.LGA;
                existingStudent.Age = student.Age;
                existingStudent.Class = student.Class;
                existingStudent.LaststName = student.LaststName;
                existingStudent.MiddleName = student.MiddleName;
                existingStudent.Image = student.Image;
                
                db.Result.Update(existingStudent);
                await db.Result.SaveChangesAsync();
            }
        }

        public string GetNames(Students students)
        {
            string fullName = $"{students.FirstName}{students.LaststName}";
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
        public string GetTwoLettersFromName(Students students)
        {
            var result = "";
            var firstletter = students.FirstName;
            var last = students.LaststName;


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
        public string GenerateRegistrationNumber(Students student)
        {
            var random = new Random();
            DateTime currentAge = DateTime.Now;
            var twoLetters = GetTwoLettersFromName(student);
            return $"{twoLetters.ToUpper()}{student.Age.Year}/{currentAge.Year - student.Age.Year}";
            
        }
    }
}
