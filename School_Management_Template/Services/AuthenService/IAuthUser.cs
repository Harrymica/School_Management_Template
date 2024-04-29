using School_Management_Template.Data;

namespace School_Management_Template.Services.AuthenService
{
    public interface IAuthUser
    {
        public string errormsg { get; set; }
        Task Login(Login login);
        Task AdminLogin(Login login);
    }
}
