using _27_FrontToBackSqlConnection;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

//builder.Services.AddScoped<IEmailService, TestService>();
//builder.Services.AddTransient<EmailService>();
//builder.Services.AddSingleton<EmailService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();