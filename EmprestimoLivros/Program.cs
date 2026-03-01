using EmprestimoLivros.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cs = Environment.GetEnvironmentVariable("DATABASE_URL");
if (string.IsNullOrWhiteSpace(cs))
    throw new Exception("DATABASE_URL não foi encontrada no ambiente do Render.");

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseNpgsql(cs));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();