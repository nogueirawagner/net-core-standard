using Core.Domain.Models;
using Core.Domain.Models.Eventos;
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
      builder.Ignore(e => e.CascadeMode);

      builder.HasOne(e => e.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizadorId);

      builder.HasOne(e => e.Categoria)
          .WithMany(e => e.Eventos)
          .HasForeignKey(e => e.CategoriaId)
          .IsRequired(false);
    }
  }
}
