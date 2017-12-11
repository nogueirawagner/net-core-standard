using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infra.Data.Context.ModelBuilders
{
  public class XCategoriaModelBuilder
  {
    public static void ModelBuilder(ModelBuilder pModelBuilder)
    {
      var mb = pModelBuilder.Entity<Categoria>();
      mb.ToTable("Categoria");

      mb.Ignore(e => e.ValidationResult);
      mb.Ignore(e => e.CascadeMode);
    }
  }
}
