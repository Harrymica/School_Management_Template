using Supabase.Gotrue;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace School_Management_Template.Data
{
    [Table ("messages")]
    public class Messages : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }
        [Column("message")]
        public string? Message { get; set; }
        [Column("dateTime")]
        public DateTime dateTime { get; set; }
       
       
    }
}
