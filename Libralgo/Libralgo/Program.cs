using Libralgo.Business.Extensions;
using Libralgo.Data.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibralgoDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddServiceRegistrations();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/login";
        opt.LogoutPath = "/logout";
        opt.AccessDeniedPath = "/denied";
        opt.SlidingExpiration = true;
        opt.ExpireTimeSpan = TimeSpan.FromDays(7);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
