using System.ComponentModel.DataAnnotations;

namespace School_Management_Template.Data
{

    public class Result
    {

        [Key]
        public int Id { get; set; }
        public string? Grade { get; set; }
       
        public Students? Student { get; set; }
        public int StudentId { get; set; }
      
        public Courses? Courses{ get; set; }
       
        public int CoursesId { get; set; }
        public int Score { get; set; }
    }
}
