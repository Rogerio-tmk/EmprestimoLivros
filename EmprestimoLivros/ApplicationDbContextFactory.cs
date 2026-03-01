using EmprestimoLivros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmprestimoLivros
{
    // Factory usada pelo "dotnet ef" (migrations). Mantém o projeto compilando.
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Lê appsettings.json (e env vars se tiver)
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var cs = config.GetConnectionString("DefaultConnection");

            // Se tiver ConnectionString, usa Postgres
            if (!string.IsNullOrWhiteSpace(cs))
            {
                optionsBuilder.UseNpgsql(cs);
            }
            else
            {
                // Fallback só pra não quebrar build se estiver vazio
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres;SSL Mode=Prefer;Trust Server Certificate=true");
            }

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}