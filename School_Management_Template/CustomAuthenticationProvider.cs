using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using School_Management_Template.Database;
using System.Security.Claims;

namespace School_Management_Template
{
    public class CustomAuthenticationProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IDbContextFactory<DataContext> _context;
        

        public CustomAuthenticationProvider(ILocalStorageService localStorage, IDbContextFactory<DataContext> context)
        {
            _localStorage = localStorage;
            
            _context = context;
           
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Initialize with anonymous identity
            //await UpdateAuthenticationStateAsync();
            var identity = new ClaimsIdentity();
            return new AuthenticationState(new ClaimsPrincipal(identity));

            //var username = await _localStorage.GetItemAsStringAsync("email");

            //var state = new AuthenticationState(new ClaimsPrincipal());
            //if (!string.IsNullOrEmpty(username))
            //{
            //    username = username.Trim('"');
            //    var user = await _context.Students.FirstOrDefaultAsync(u => u.Email == username);

            //    if (user != null)
            //    {

            //        var identity = new ClaimsIdentity(new[]
            //        {
            //            new Claim(ClaimTypes.Email, username),
            //            //new Claim(ClaimTypes, user.RegisterationNumber!)

            //     }, "test authentication type");

            //        state = new AuthenticationState(new ClaimsPrincipal(identity));

            //    }


            //    NotifyAuthenticationStateChanged(Task.FromResult(state));
            //}


            //return state;
        }

        public async Task<AuthenticationState> UpdateAuthenticationStateAsync()
        {
            var username = await _localStorage.GetItemAsStringAsync("email");
            var state = new AuthenticationState(new ClaimsPrincipal());

            if (!string.IsNullOrEmpty(username))
            {
                using var db = _context.CreateDbContextAsync();
                username = username.Trim('"');
                var user = await db.Result.Students.FirstOrDefaultAsync(u => u.Email == username);

                if (user != null)
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Email, username)
                   
                    // Add other claims as necessary
                }, "test authentication type");

                    state = new AuthenticationState(new ClaimsPrincipal(identity));
                }

                NotifyAuthenticationStateChanged(Task.FromResult(state));
            }
            return state;
        }

        public async Task<AuthenticationState> UpdateAuthenticationADMIN()
        {
            var username = await _localStorage.GetItemAsStringAsync("email");
            var state = new AuthenticationState(new ClaimsPrincipal());

            if (!string.IsNullOrEmpty(username))
            {
                using var db = _context.CreateDbContextAsync();
                username = username.Trim('"');
                var user = await db.Result.Admins.FirstOrDefaultAsync(u => u.Email == username);

                if (user != null)
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Email, username),
                    new Claim(ClaimTypes.Role, user.Role!)
                   
                    // Add other claims as necessary
                }, "test authentication type");

                    state = new AuthenticationState(new ClaimsPrincipal(identity));
                }

                NotifyAuthenticationStateChanged(Task.FromResult(state));
            }
            return state;
        }
    }
}
