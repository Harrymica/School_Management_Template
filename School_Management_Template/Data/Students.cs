using System.ComponentModel.DataAnnotations;

namespace School_Management_Template.Data
{
  
    public class Students 
    {
       
        [Key]
        public int Id { get; set; }

       
        public string? FirstName { get; set; }
        
        public string? MiddleName { get; set; }
      
        public string? LaststName { get; set; }
       
        public string? Email { get; set; }
      
        public string? PhoneNumber { get; set; }

        public DateTime Age { get; set; } = DateTime.Now;

        
        public string? State { get; set; }
       
        public string? LGA { get; set; }

      
        public string? RegisterationNumber { get; set; }
       
        public string? Password { get; set; }
      
        public string? Class { get; set; }
     
        public string? Image { get; set; }
       
        public virtual List<Courses>? Courses { get; set; } = new List<Courses>();
       
        public virtual List<Result>? Results { get; set; } = new List<Result>();
      
        public ClassModel? ClassModel { get; set; }
        public int ClassModelId { get; set; }


    }
}
