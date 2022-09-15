using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Hello");
Console.WriteLine(builder.Configuration.GetConnectionString("DEFAULT_CONNECTION"));
Console.WriteLine("World");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorCrudChampionContext>(options =>
//builder.Configuration.GetConnectionString("RazorCrudChampionContext")
options.UseSqlServer(builder.Configuration.GetConnectionString("GENERATED") ?? throw new InvalidOperationException("Something Went Wrong")));
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
