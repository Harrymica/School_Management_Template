using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School_Management_Template;
using School_Management_Template.Data;
using School_Management_Template.Database;
using School_Management_Template.Repositories.AuthenticationServices;
using School_Management_Template.Repositories.StudentRespository;
using School_Management_Template.Services.AuthenService;
using School_Management_Template.Services.ClassServices;
using School_Management_Template.Services.CourseServices;
using School_Management_Template.Services.ResultServices;
using School_Management_Template.Services.StudentServices;
using School_Management_Template.Services.TeacherService;
using Supabase;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAuthentication, Authentication>();
builder.Services.AddScoped<IAuthUser, AuthUser>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherSercives, TeacherServices>();
builder.Services.AddScoped<ICourseServices, CourseService>();
builder.Services.AddScoped<IResultServices, ResultService>();
builder.Services.AddScoped<IClassServices, ClassModelServices>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationProvider>();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("Role", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
});

var cs = builder.Configuration.GetConnectionString("DbConnectionString");

builder.Services.AddDbContextFactory<DataContext>(options =>
{
    options.UseSqlServer(cs);
});

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

//var url = Environment.GetEnvironmentVariable("Url");
//var key = Environment.GetEnvironmentVariable("Key");
var options = new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true

};

builder.Services.AddSingleton(provider => 
            new Supabase.Client("https://xbpfjissmlaulfmmdema.supabase.co", 
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhicGZqaXNzbWxhdWxmbW1kZW1hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTEwODY2MzMsImV4cCI6MjAyNjY2MjYzM30.DbA3lh6tT5D_W819GVqvKtC1WDIchyCgXdHIKaqxJsA", options));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
