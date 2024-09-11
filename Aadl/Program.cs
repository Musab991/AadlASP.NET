using Aadl.ApiController;
using BusinessLib.Bl;
using BusinessLib.Bl.Contract;
using BusinessLib.Data;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);



    // Add services to the container.
    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
    //.AddInterceptors(new SoftDeleteInterceptor()));


    // Add services to the container.
    builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICRUD<TbCountry>, clsCountry>();
builder.Services.AddScoped<ICRUD<TbPerson>, clsPerson>();
builder.Services.AddScoped<ICRUD<TbPractitioner>, clsPractitioner>();
builder.Services.AddScoped<IPractitionerService<TbCaseType>, clsPractitionerService>();

builder.Services.AddHttpClient<Aadl.Controllers.PractitionerController>();
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
