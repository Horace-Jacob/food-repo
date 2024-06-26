using data_and_repo_pattern.helper.MenuApiRequest;
using data_and_repo_pattern.helper.OrderApiRequest;
using data_and_repo_pattern.helper.UserApiRequest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("") });
builder.Services.AddHttpClient();

builder.Services.AddScoped<IMenuApiRequest, MenuApiRequest>();
builder.Services.AddScoped<IOrderApiRequest, OrderApiRequest>();
builder.Services.AddScoped<IUserApiRequest, UserApiRequest>();


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
