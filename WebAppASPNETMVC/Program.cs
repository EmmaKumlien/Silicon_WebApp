using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AccountService>();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<DataContext>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("WebApp_Database")));
builder.Services.AddIdentity<UserEntity, IdentityRole>(x=>
{
	x.SignIn.RequireConfirmedAccount = false;
	x.User.RequireUniqueEmail = true;
	x.Password.RequiredLength = 8;

}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
	x.LoginPath = "/signin";
	x.Cookie.HttpOnly = true;
	x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	x.ExpireTimeSpan = TimeSpan.FromHours(1);
	x.SlidingExpiration = true;
});


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Home}/{id?}");
app.Run();
