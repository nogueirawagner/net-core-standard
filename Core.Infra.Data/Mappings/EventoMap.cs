using Core.Domain.Models;
using Core.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings
{
  public class EventoMap : EntityTypeConfiguration<Evento>
  {
    public override void Map(EntityTypeBuilder<Evento> builder)
    {
      builder.ToTable("Eventos");

      builder.Property(e => e.Nome)
       .HasColumnType("varchar(150)")
       .IsRequired();

      builder.Property(e => e.DescricaoCurta)
      .HasColumnType("varchar(150)");

      builder.Property(e => e.Descricao)
      .HasColumnType("varchar(max)");

      builder.Property(e => e.NomeEmpresa)
      .HasColumnType("varchar(150)")
      .IsRequired();

      builder.Property(e => e.Gratuito)
      .IsRequired();

      builder.Ignore(e => e.ValidationResult);
      //builder.Ignore(e => e.Endereco);
      //builder.Ignore(e => e.Organizador);
      //builder.Ignore(e => e.Categoria);
      builder.Ignore(e => e.CascadeMode);

      //builder.HasOne(e => e.Organizador) //Evento tem 1 organizador
      //  .WithMany(o => o.Eventos)  // Organizador tem n eventos
      //  .HasForeignKey(e => e.OrganizadorId);

      //// Evento pode ter ou não uma categoria
      //builder.HasOne(e => e.Categoria) // Evento tem 1 categoria
      //  .WithMany(c => c.Eventos) // Categoria tem n eventos
      //  .HasForeignKey(e => e.CategoriaId) // FK categoriaId que pertence ao evento
      //  .IsRequired(false); // Não é um relacionamento requirido

      // Evento pode ter ou nao endereco
      //builder.HasOne(e => e.Endereco)
      //  .WithMany(c => c.Eventos)
      //  .HasForeignKey(e => e.EnderecoId)
      //  .IsRequired(false);
    }
  }
}
