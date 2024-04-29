using System.ComponentModel.DataAnnotations;

namespace School_Management_Template.Data
{
   
    public class Teachers
    {

       
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }
        
        public string? MiddleName { get; set; }
        
        public string? LaststName { get; set; }
        
        public string? Email { get; set; }
        
        public string? PhoneNumber { get; set; }

        public DateTime Age { get; set; } = DateTime.Now;
        public string? Password { get; set; }

        
        public string? State { get; set; }
        
        public string? LGA { get; set; }
        public string? Image { get; set; }

        public Courses? Course { get; set; }
        public int? CourseId { get; set; }
        public ClassModel? ClassModel { get; set; }
        public int? ClassModelId { get; set; }

    }
}
