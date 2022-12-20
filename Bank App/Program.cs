// using Bank_App.Repositories.Implementations;
using Bank_App.Repositories.Interfaces;
using Bank_App.Services.Implementations;
using Bank_App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Repositories;
using MVC_MobileBankApp.Repositories.Implementations;
using MVC_MobileBankApp.Services.Implementations;
using MVC_MobileBankApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));   
// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql("Server=localhost;port=3306;Database=LegitbankappMVC;Uid=root;Pwd=Adebayo58641999", serverVersion));
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseMySql(
  builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
  ));
    builder.Services.AddScoped<IAdminRepository , AdminRepository>();
    builder.Services.AddScoped<IAdminService , AdminService>();
    builder.Services.AddScoped<IManagerRepository , ManagerRepository>();
    builder.Services.AddScoped<IManagerService , ManagerService>();
    builder.Services.AddScoped<ICEORepository , CEORepository>();
    builder.Services.AddScoped<ICEOService , CEOService>();
    builder.Services.AddScoped<ICustomerRepository , CustomerRepository>();
    builder.Services.AddScoped<ICustomerService , CustomerService>();
    builder.Services.AddScoped<ITransactionRepository , TransactionRepository>();
    builder.Services.AddScoped<ITransactionService , TransactionService>();
    builder.Services.AddScoped<IUserRepository , UserRepository>();
    builder.Services.AddScoped<IUserService , UserService>();
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config => {
    config.LoginPath = "/Home/Index";
    config.LogoutPath = "/Home/Index";
    config.Cookie.Name = "bankApplication";
           
    });
    builder.Services.AddAuthorization();

    // //session

    // builder.Services.AddSession(options => {
    // options.Cookie.Name = "BankApp.Session";
    // options.IdleTimeout = TimeSpan.FromSeconds(10);
    // });
  
  
  // builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
  builder.Services.AddRazorPages();



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
// app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
