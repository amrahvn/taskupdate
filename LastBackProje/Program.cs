using LastBackProje.DataAccesLAyer;
using LastBackProje.Interfaces;
using LastBackProje.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    //options.Cookie.Expiration = TimeSpan.FromSeconds(10);
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILayoutService,LayoutService>();
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("area", "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");

app.Run();
