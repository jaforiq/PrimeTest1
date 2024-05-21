using PrimeTechTest.Mapping;
using PrimeTechTest.Interfaces;
using PrimeTechTest.Repository;
using Microsoft.EntityFrameworkCore;
using PrimeTechTest.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyValueRepository, CompanyValueRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddDbContext<CompanyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PrimeConnectionString")));


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
