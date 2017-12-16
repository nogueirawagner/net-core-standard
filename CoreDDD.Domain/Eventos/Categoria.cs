using Core.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Core.Domain.Models.Eventos
{
  public class Categoria : Entity<Categoria>
  {
    public Categoria(Guid pId)
    {
      Id = pId;
    }

    public string Nome { get; private set; }

    // EF Propriedade de Navegação 
    public virtual ICollection<Evento> Eventos { get; set; }

    // Construtor para o EF
    protected Categoria() { }


    public override bool EhValido()
    {
      return true;
    }
  }
}
