using data_and_repo_pattern.database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var contextOptions = new DbContextOptionsBuilder<FoodDbContext>()
             .UseSqlServer("Server=localhost;Database=<dbname>;Trusted_Connection=True;")
             .Options;
builder.Services.AddScoped<FoodDbContext>(s => new FoodDbContext(contextOptions));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:7297")
        .AllowAnyHeader()
        .WithMethods("GET", "POST")
        .AllowCredentials();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
