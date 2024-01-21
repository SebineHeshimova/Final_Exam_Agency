using Agency.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Agency.Data;
using Agency.Business;
using Microsoft.AspNetCore.Identity;
using Agency.Core.Entity;
using Agency.MVC.LayoutService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AgencyDbContext>(option => { option.UseSqlServer("Server=DESKTOP-6EQ5FGI;Database=AgencyDb;Trusted_Connection=True;"); });
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddScoped<LayoutService>();
builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 8;
    option.Password.RequireUppercase = true;
    option.Password.RequireLowercase = true;
    option.Password.RequireDigit = true;
    option.Password.RequiredUniqueChars = 1;

    //  option.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AgencyDbContext>().AddDefaultTokenProviders();
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
