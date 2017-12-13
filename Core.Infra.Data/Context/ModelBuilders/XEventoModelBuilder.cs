using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infra.Data.Context.ModelBuilders
{
  public static class XEventoModelBuilder
  {
    public static void ModelBuilder(ModelBuilder pModelBuilder)
    {
      var mb = pModelBuilder.Entity<Evento>();
      mb.ToTable("Eventos");

      mb.Property(e => e.Nome)
       .HasColumnType("varchar(150)")
       .IsRequired();

      mb.Property(e => e.DescricaoCurta)
      .HasColumnType("varchar(150)");

      mb.Property(e => e.Descricao)
      .HasColumnType("varchar(max)");

      mb.Property(e => e.NomeEmpresa)
      .HasColumnType("varchar(150)")
      .IsRequired();

      mb.Property(e => e.Gratuito)
      .HasColumnType("boolean")
      .IsRequired();

      mb.Ignore(e => e.ValidationResult);
      mb.Ignore(e => e.Tags);
      mb.Ignore(e => e.CascadeMode);

      mb.HasOne(e => e.Organizador) //Evento tem 1 organizador
        .WithMany(o => o.Eventos)  // Organizador tem n eventos
        .HasForeignKey(e => e.OrganizadorId);

      // Evento pode ter ou não uma categoria
      mb.HasOne(e => e.Categoria) // Evento tem 1 categoria
        .WithMany(c => c.Eventos) // Categoria tem n eventos
        .HasForeignKey(e => e.CategoriaId) // FK categoriaId que pertence ao evento
        .IsRequired(false); // Não é um relacionamento requirido

      // Evento pode ter ou nao endereco
      mb.HasOne(e => e.Endereco)
        .WithMany(c => c.Eventos)
        .HasForeignKey(e => e.EnderecoId)
        .IsRequired(false);
    }
  }
}
