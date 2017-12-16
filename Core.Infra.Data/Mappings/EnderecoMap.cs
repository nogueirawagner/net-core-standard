using Core.Domain.Models;
using Core.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings
{
  public class EnderecoMap : EntityTypeConfiguration<Endereco>
  {
    public override void Map(EntityTypeBuilder<Endereco> builder)
    {
      builder.ToTable("Enderecos");

      builder.Property(e => e.Bairro)
        .HasMaxLength(150)
        .HasColumnType("varchar(150)");

      builder.Property(e => e.Numero)
        .HasColumnType("varchar(20)");

      builder.Property(e => e.Bairro)
        .HasColumnType("varchar(150)");

      builder.Property(e => e.CEP)
        .HasColumnType("varchar(20)");

      builder.Ignore(e => e.Eventos);
      builder.Ignore(e => e.ValidationResult);
      builder.Ignore(e => e.CascadeMode);
    }
  }
}
