using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL;
using OnlineStore.DAL.Interfaces;
using OnlineStore.DAL.Repositories;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Implementations;
using OnlineStore.Domain.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
var dbConnection = builder.Configuration.GetConnectionString("dbConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
	options.UseSqlServer(dbConnection));

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
//    {
//        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("Account/Login");
//        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("Account/Login");
//	});


builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAccountService, AccountService>();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
