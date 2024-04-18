using data_and_repo_pattern.database;
using data_and_repo_pattern.uow;
using food_order_system.Services.MenuService;
using food_order_system.Services.OrderService;
using food_order_system.Services.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var contextOptions = new DbContextOptionsBuilder<FoodDbContext>()
//             .UseSqlServer("Data Source=localhost;Initial Catalog=food;TrustServerCertificate=True")
//             .Options;
//builder.Services.AddScoped<FoodDbContext>(s => new FoodDbContext(contextOptions));
builder.Services.AddDbContext<FoodDbContext>(options =>
{
    options.UseSqlServer("name=DefaultConnection",
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,  // Maximum number of retry attempts
                maxRetryDelay: TimeSpan.FromSeconds(30),  // Maximum delay between retries
                errorNumbersToAdd: null);  // List of SQL error codes to retry on, null means all errors
        });
});

builder.Services.AddScoped<IUnitOfWork>(s => new UnitOfWork(s.GetService<FoodDbContext>()));
builder.Services.AddScoped<IUserService>(s => new UserService(s.GetService<IUnitOfWork>()));
builder.Services.AddScoped<IMenuService>(s => new MenuService(s.GetService<IUnitOfWork>()));
builder.Services.AddScoped<IOrderService>(s => new OrderService(s.GetService<IUnitOfWork>()));

var app = builder.Build();



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
