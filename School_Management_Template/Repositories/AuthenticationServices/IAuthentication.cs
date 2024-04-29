using School_Management_Template.Data;

namespace School_Management_Template.Repositories.AuthenticationServices
{
    public interface IAuthentication
    {
        Task Login(Login login);
        bool AuthenticateUser();
    }

}
