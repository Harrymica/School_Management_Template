using System.ComponentModel.DataAnnotations;

namespace School_Management_Template.Data
{
   
    public class Courses
    {
        
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? CourseCode { get; set; }
        public List<Students>? Students { get; set; }
        public List<Result>? results { get; set; }
        public Teachers? Teachers { get; set; }
        public int? TeachersId { get; set; }
        public List<ClassModel>? ClassModel{ get; set; }
        public int? ClassModelId { get; set; }

    }
}
