using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using School_Management_Template.Data;
using School_Management_Template.Database;

namespace School_Management_Template.Services.AuthenService
{
    public class AuthUser : IAuthUser
    {
        private readonly IDbContextFactory<DataContext> _context;
        private readonly NavigationManager _navMag;
        private readonly ILocalStorageService _lStorage;
        private readonly IJSRuntime _jSRuntime;

        public AuthUser(IDbContextFactory<DataContext> context, NavigationManager navMag, ILocalStorageService lStorage, IJSRuntime jSRuntime)
        {
            _context = context;
            _navMag = navMag;
            _lStorage = lStorage;
            _jSRuntime = jSRuntime;
        }

        public string errormsg { get; set ; } = "Wrong Password or email";

        public async Task AdminLogin(Login adminlogin)
        {
            if (adminlogin != null)
            {
                using var db = _context.CreateDbContextAsync();

                bool CheckAdmin = await db.Result.Admins.AnyAsync(u => u.Email == adminlogin.Email && u.Password == adminlogin.Password);
                if (CheckAdmin == true)
                {
                    await _lStorage.SetItemAsync<string>("email", adminlogin.Email!);
                    _navMag.NavigateTo("/");

                }
                else
                {
                    await _jSRuntime.InvokeAsync<object>("Alert", errormsg);
                }
            }
        }

        public async Task Login(Login login)
        {
            
            if (login != null)
            {
                using var db = _context.CreateDbContextAsync();
               
                bool CheckAdmin = await db.Result.Students.AnyAsync(u => u.Email == login.Email && u.Password == login.Password);
                if (CheckAdmin == true)
                {
                    await _lStorage.SetItemAsync<string>("email", login.Email!);
                    _navMag.NavigateTo("/");

                }
                else
                {
                    await _jSRuntime.InvokeAsync<object>("Alert", errormsg);
                }
            }
        }


    }
}
