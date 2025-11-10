using ApiEnCouches.DataAccess;
using ApiEnCouches.DataAccess.IDataAccess;
using ApiEnCouches.DataAccess.DataAccess;
using ApiEnCouches.Service.IService;
using ApiEnCouches.Service.Service;

// Import des seeders
using ApiEnCouches.DataAccess.Seed.ArticleSeeder;
using ApiEnCouches.DataAccess.Seed.DbSeeder;
using ApiEnCouches.DataAccess.Seed.IDbSeeder;

// Import des outils microsoft
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// Import microsoft JWT
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddScoped<IArticleDataAccess, ArticleDataAccess>();
builder.Services.AddScoped<IArticleService, ArticleService>();

builder.Services.AddScoped<IDbSeeder, ArticleSeeder>();
builder.Services.AddScoped<DbSeeder>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Builder pour DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// Builder pour Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();
    

    var isProduction = app.Environment.IsProduction();

    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Applique toutes les migrations manquantes
    db.Database.Migrate();

    await seeder.SeedAsync(context, app.Environment.IsProduction());
}

app.UseAuthorization();

app.MapControllers();

app.Run();
