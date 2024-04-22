using EFLessonUnitTesting.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Install-Package Microsoft.EntityFrameworkCore.Tools
//Install-Package Microsoft.EntityFrameworkCore.SqlServer
//Scaffold-DbContext "Server=LAPTOP-IERTITV7;Database=Blogs;User Id=aufjaphetong; Password=Today@123; TrustServerCertificate=True;Encrypt=false;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
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
