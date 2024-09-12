using Aadl.ApiController;
using BusinessLib.Bl;
using BusinessLib.Bl.Contract;
using BusinessLib.Data;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;

var builder = WebApplication.CreateBuilder(args);



    // Add services to the container.
    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
//.AddInterceptors(new SoftDeleteInterceptor()));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(ICRUD<>), typeof(clsGenericRepository<>));
builder.Services.AddScoped(typeof(ITransactionOperations<>), typeof(clsGenericRepository<>));
builder.Services.AddScoped<ISpecialRetriveToData<TbCaseType>, clsCaseType>();
builder.Services.AddScoped<IPractitionerCaseSpecialMethods<TbPractitionerCase>, clsPractitionerCase>();
builder.Services.AddScoped<IPractitionerSpecialFeatures<TbPractitioner>, clsPractitionerService<TbPractitioner>>();
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
