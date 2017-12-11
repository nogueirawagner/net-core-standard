using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infra.Data.Context.ModelBuilders
{
  public class XOrganizadorModelBuilder
  {
    public static void ModelBuilder(ModelBuilder pModelBuilder)
    {
      var mb = pModelBuilder.Entity<Organizador>();
      mb.ToTable("Organizadores");

      mb.Ignore(e => e.ValidationResult);
      mb.Ignore(e => e.CascadeMode);

    }
  }
}
