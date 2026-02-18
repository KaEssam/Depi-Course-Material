using Day1.Models;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> 6637ba3848b8a5abbbf0993260116f21b21a1fa6
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

<<<<<<< HEAD
builder.Services.AddDbContext<AppDbContext>(options => 
                        options.UseInMemoryDatabase("TMS"));
=======
//builder.Services.AddDbContext<AppDbContext>(options => 
//                        options.UseInMemoryDatabase("TMS"));


builder.Services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//identity
builder.Services.AddIdentity<AppUser, IdentityRole>(Options =>
{
    Options.Password.RequiredLength = 5;
    Options.Password.RequireDigit = false;
    Options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
>>>>>>> 6637ba3848b8a5abbbf0993260116f21b21a1fa6

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

<<<<<<< HEAD
=======

app.UseAuthentication();
>>>>>>> 6637ba3848b8a5abbbf0993260116f21b21a1fa6
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
