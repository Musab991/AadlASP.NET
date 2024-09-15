using Aadl.ApiController;
using BusinessLib.Bl;
using BusinessLib.Bl.Contract;
using BusinessLib.Data;
using Domains.Models;
using Domains.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
//.AddInterceptors(new SoftDeleteInterceptor()));

#region Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6; // or any desired length
    options.Password.RequiredUniqueChars = 1;

    // User settings
    options.User.RequireUniqueEmail = true; // Ensure the email is unique
})
.AddEntityFrameworkStores<AppDbContext>();
//.AddDefaultTokenProviders();
#endregion


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(ICRUD<>), typeof(clsGenericRepository<>));
builder.Services.AddScoped(typeof(ITransactionOperations<>), typeof(clsGenericRepository<>));
builder.Services.AddScoped<ISpecIncludeable, clsPractitionerSpecRepository>();
builder.Services.AddScoped<ISpecialServices<TbCaseType>, clsCaseType>();
builder.Services.AddScoped<IPractitionerCaseSpecialMethods<TbPractitionerCase>, clsPractitionerCase>();

builder.Services.AddScoped<IPractitionerTransactional<TbPractitioner>, clsPractitionerService<TbPractitioner>>();
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
