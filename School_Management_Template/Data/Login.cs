using Supabase.Postgrest.Models;

namespace School_Management_Template.Data
{

    public class Login 
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
