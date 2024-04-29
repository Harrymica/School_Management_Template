using Blazorise;
using School_Management_Template.Data;
using Supabase;
using static Supabase.Gotrue.Constants;

namespace School_Management_Template.Repositories.AuthenticationServices
{
    public class Authentication : IAuthentication
    {
        private readonly Client _client;

        public Authentication(Supabase.Client client)
        {
            _client = client;
        }

        public bool AuthenticateUser()
        {
            var supabase = new Supabase.Client("https://xbpfjissmlaulfmmdema.supabase.co",
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhicGZqaXNzbWxhdWxmbW1kZW1hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTEwODY2MzMsImV4cCI6MjAyNjY2MjYzM30.DbA3lh6tT5D_W819GVqvKtC1WDIchyCgXdHIKaqxJsA");


           
            return true;

            //supabase.Auth.AddStateChangedListener((sender, changed) =>
            //{
            //    switch (changed)
            //    {
            //        case AuthState.SignedIn:
            //            break;
            //        case AuthState.SignedOut:
            //            break;
            //        case AuthState.UserUpdated:
            //            break;
            //        case AuthState.PasswordRecovery:
            //            break;
            //        case AuthState.TokenRefreshed:
            //            break;
            //    }
            //});
        }

        public async Task Login(Login login)
        {
            //if(login != null)
            //{

            //var client = new Supabase.Client("https://xbpfjissmlaulfmmdema.supabase.co",
            //"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhicGZqaXNzbWxhdWxmbW1kZW1hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTEwODY2MzMsImV4cCI6MjAyNjY2MjYzM30.DbA3lh6tT5D_W819GVqvKtC1WDIchyCgXdHIKaqxJsA");

            //    var response = await client.From<Students>().Where(u => u.Email == login.Email && u.Password == login.Password).Single();
                
            //   if(response != null)
            //    {
            //        AuthenticateUser();
            //    }
            //}
        }

        
    }
}
