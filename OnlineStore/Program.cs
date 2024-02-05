using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL;
using OnlineStore.DAL.Interfaces;
using OnlineStore.DAL.Repositories;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Implementations;
using OnlineStore.Domain.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
var dbConnection = builder.Configuration.GetConnectionString("dbConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
	options.UseSqlServer(dbConnection));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();


builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IEmailSenderService, EmailSenderService>();

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
