using Core.Domain.Models.Eventos;
using Core.Infra.Data.Extensions;
using Core.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Core.Infra.Data.Context
{
  public class CoreContext : DbContext
  {
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Organizador> Organizadores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.AddConfiguration(new EventoMap());
      modelBuilder.AddConfiguration(new CategoriaMap());
      modelBuilder.AddConfiguration(new OrganizadorMap());
      modelBuilder.AddConfiguration(new EnderecoMap());

      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      optionsBuilder.UseSqlServer(config.GetConnectionString("EphromConnection"));

    }
  }
}
