using Microsoft.EntityFrameworkCore;
using Wonderlust.Application.Common.Interfaces;
using Wonderlust.Application.Tours;
using Wonderlust.Infrastructure.Persistence;
using Wonderlust.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Infrastructure
builder.Services.AddScoped<ITourPackageRepository, TourPackageRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Application
builder.Services.AddScoped<ITourPackageService, TourPackageService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed database on startup (dev-friendly)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();
    await AppDbSeeder.SeedAsync(dbContext);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

// optional redirect
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
