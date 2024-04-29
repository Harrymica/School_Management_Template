using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using School_Management_Template.Data;

namespace School_Management_Template.Database
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Email = "Admin007@gmail.com",
                    FullName = "Hasan Jubil",
                    PhoneNumber = "08878399001",
                    Password = "Admin@007",
                    Role = "Admin"



                }
                );

            modelBuilder.Entity<Courses>().HasData(
               new Courses
               {
                   Id = 1,
                   Name = "Basic Science",
                   CourseCode = "Bsc 001",
                   Description = "Basic Sciences"


               },

               new Courses
               {
                   Id = 2,
                   Name = "Basic Tech",
                   CourseCode = "Bst 001",
                   Description = "Basic Technology"
                   


               },
               new Courses
               {
                   Id = 3,
                   Name = "Maths",
                   CourseCode = "Maths 101",
                   Description = "Mathematics",
                   


               },
               new Courses
               {
                   Id = 4,
                   Name = "English",
                   CourseCode = "Eng 012",
                   Description = "English Language"


               },
               new Courses
               {
                   Id = 5,
                   Name = "Chemistry",
                   CourseCode = "chem 101",
                   Description = "Chemistry for senior high school"


               },
               new Courses
               {
                   Id = 6,
                   Name = "Physics",
                   CourseCode = "Phy 124",
                   Description = "Basic Physics for senior high score"


               },
               new Courses
               {
                   Id = 7,
                   Name = "Biology",
                   CourseCode = "Bio 001",
                   Description = "Biological Sciences for senior high school"


               }

               );
            modelBuilder.Entity<ClassModel>().HasData(
                new ClassModel
                {
                    Id = 1,
                    Name = "Jss1"
                    


                },
                 new ClassModel
                 {
                     Id = 2,
                     Name = "Jss2"

                 },
                  new ClassModel
                  {
                      Id = 3,
                      Name = "Jss3"

                  },
                   new ClassModel
                   {
                       Id = 4,
                       Name = "ss1"

                   },
                    new ClassModel
                    {
                        Id = 5,
                        Name = "ss2"

                    },
                     new ClassModel
                     {
                         Id = 6,
                         Name = "ss3"

                     }
                     
                );

            modelBuilder.Entity<Courses>()
           .HasOne(e => e.Teachers)
           .WithOne()
           .HasForeignKey<Courses>(e => e.TeachersId);


            modelBuilder.Entity<Teachers>()
          .HasOne(e => e.Course)
          .WithOne()
          .HasForeignKey<Teachers>(e => e.CourseId);



        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ClassModel> ClassModels { get; set; }  
    }
}
