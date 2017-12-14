using Core.Domain.Models;
using Core.Infra.Data.Context.ModelBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Infra.Data.Context
{
  public class XCoreContext : DbContext
  {
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Organizador> Organizadores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      XEventoModelBuilder.ModelBuilder(modelBuilder);
      XEnderecoModelBuilder.ModelBuilder(modelBuilder);
      XOrganizadorModelBuilder.ModelBuilder(modelBuilder);
      XCategoriaModelBuilder.ModelBuilder(modelBuilder);

      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

    }
  }
}
