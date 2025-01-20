using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Pricelists.Application.Services;
using Pricelists.DataAccess;
using Pricelists.DataAccess.Entites.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PricelistsDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IPricelistsRepository, PricelistsRepository>();
builder.Services.AddScoped<IPricelistsService, PricelistsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Pricelist/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseRouting();

app.UseSwagger()
    .UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pricelists}/{action=Index}/{id?}");

app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Run();
