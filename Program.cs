<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using Frontend.Blazor.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/"); // Thay bằng URL backend
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
=======
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using StudentAttendanceMVC.Data;
using StudentAttendanceMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    // User settings
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Account/Login";  // Đường dẫn khi cần đăng nhập
    options.AccessDeniedPath = "/Account/AccessDenied";  // Đường dẫn khi bị từ chối quyền
    options.SlidingExpiration = true;
    options.LogoutPath = "/Account/Logout";  // Đảm bảo logout path khớp
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Đảm bảo gọi trước UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = { "Student", "Lecturer", "Admin" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var adminUser = new ApplicationUser { UserName = "admin@example.com", Email = "admin@example.com", FullName = "Admin", Role = "Admin" };
    if (await userManager.FindByEmailAsync(adminUser.Email) == null)
    {
        await userManager.CreateAsync(adminUser, "Admin@123");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    var studentUser = new ApplicationUser { UserName = "student@example.com", Email = "student@example.com", FullName = "Sinh Viên X", Role = "Student" };
    if (await userManager.FindByEmailAsync(studentUser.Email) == null)
    {
        await userManager.CreateAsync(studentUser, "Student@123");
        await userManager.AddToRoleAsync(studentUser, "Student");
    }

    var lecturerUser = new ApplicationUser { UserName = "lecturer@example.com", Email = "lecturer@example.com", FullName = "Giảng Viên A", Role = "Lecturer" };
    if (await userManager.FindByEmailAsync(lecturerUser.Email) == null)
    {
        await userManager.CreateAsync(lecturerUser, "Lecturer@123");
        await userManager.AddToRoleAsync(lecturerUser, "Lecturer");
    }
}
>>>>>>> master

app.Run();