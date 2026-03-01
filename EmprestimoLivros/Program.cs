using EmprestimoLivros.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 tenta pegar DATABASE_URL do Render
var cs = Environment.GetEnvironmentVariable("DATABASE_URL");

// 🔹 se não existir (no seu PC), usa appsettings.json
if (string.IsNullOrWhiteSpace(cs))
{
    cs = builder.Configuration.GetConnectionString("DefaultConnection");
}

// 🔹 se ainda não tiver nada, mostra erro claro
if (string.IsNullOrWhiteSpace(cs))
{
    throw new Exception("Connection string não encontrada.");
}

// 🔹 conecta no banco Postgres / Supabase
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