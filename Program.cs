using Microsoft.EntityFrameworkCore;

using webapp_net8_database.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//Create DbContext
builder.Services.AddDbContext<MyDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
//app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();