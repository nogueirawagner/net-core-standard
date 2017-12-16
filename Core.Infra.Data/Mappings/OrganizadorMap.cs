using Core.Domain.Models;
using Core.Domain.Models.Eventos;
using Core.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings
{
  public class OrganizadorMap : EntityTypeConfiguration<Organizador>
  {
    public override void Map(EntityTypeBuilder<Organizador> builder)
    {
      builder.ToTable("Organizadores");

      builder.Property(e => e.Nome)
        .HasColumnType("varchar(150)")
        .IsRequired();

      builder.Property(e => e.Email)
        .HasColumnType("varchar(150)")
        .IsRequired();

      builder.Property(e => e.CPF)
        .HasColumnType("varchar(11)")
        .HasMaxLength(11)
        .IsRequired();

      builder.Ignore(e => e.ValidationResult);
      builder.Ignore(e => e.CascadeMode);
    }
  }
}
