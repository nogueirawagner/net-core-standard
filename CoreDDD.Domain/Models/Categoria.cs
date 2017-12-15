using Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
  public class Categoria : XEntity<Categoria>
  {
    public Categoria(Guid pId)
    {
      Id = pId;
    }

    // Um evento tem n categoria : Na tabela de eventos a mesma categoria está para vários eventos
    public virtual ICollection<Evento> Eventos { get; set; }

    public override bool EhValido()
    {
      throw new NotImplementedException();
    }
  }
}
