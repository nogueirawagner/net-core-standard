using Core.Domain.Models;
using Core.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Models.Eventos;

namespace Core.Infra.Data.Mappings
{
  public class CategoriaMap : EntityTypeConfiguration<Categoria>
  {
    public override void Map(EntityTypeBuilder<Categoria> builder)
    {
      builder.ToTable("Categorias");

      builder.Property(e => e.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();

      builder.Ignore(e => e.ValidationResult);
      builder.Ignore(e => e.CascadeMode);
    }
  }
}
