using Microsoft.OpenApi.Models;
using MotorcycleWebShop.Application;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Infrastructure;
using MotorcycleWebShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
builder.Services.AddApplication();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new OpenApiInfo { Title = "Motorcycle Api", Version = "v1" });
});

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddControllersWithViews();


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

app.UseSwagger();
app.UseSwaggerUI(setup =>
{
    setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Motorcycle Api V1");
});

app.Run();
