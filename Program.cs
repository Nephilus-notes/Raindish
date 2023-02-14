using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Raindish.Data;
using Raindish.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RaindishSongContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString
    ("RaindishSongContext") ?? throw new InvalidOperationException("Connection string 'RaindishSongContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Files}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
