using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infra.Data.Context.ModelBuilders
{
  public static class XEnderecoModelBuilder
  {
    public static void ModelBuilder(ModelBuilder pModelBuilder)
    {
      var mb = pModelBuilder.Entity<Endereco>();

      mb.ToTable("Enderecos");

      // 1:1
      mb.HasOne(c => c.Evento)
        .WithOne(e => e.Endereco)
        .HasForeignKey<Endereco>(c => c.EventoId)
        .IsRequired(false);

      mb.Ignore(e => e.ValidationResult);
      mb.Ignore(e => e.CascadeMode);

    }
  }
}
