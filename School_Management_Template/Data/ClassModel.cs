using System.ComponentModel.DataAnnotations;

namespace School_Management_Template.Data
{
    public class ClassModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Courses? Courses { get; set; }
        public List<Students>? Students { get; set; }
        public List<Teachers>? Teachers { get; set; }
    }
}
