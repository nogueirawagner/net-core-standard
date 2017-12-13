using Core.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Core.Domain.Models
{
  public class Endereco : XEntity<Endereco>
  {
    public Endereco(Guid pId)
    {
      Id = pId;
    }

    public ICollection<Evento> Eventos { get; set; }
    public Guid EventoId { get; set; }

    public override bool EhValido()
    {
      throw new System.NotImplementedException();
    }
  }
}