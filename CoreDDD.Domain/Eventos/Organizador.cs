  using Core.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Core.Domain.Models.Eventos
{
  public class Organizador : Entity<Organizador>
  {
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }

    protected Organizador()
    {
    }

    public Organizador(Guid pId, string pNome, string pCPF, string pEmail)
    {
      Id = pId;
      Nome = pNome;
      CPF = pCPF;
      Email = pEmail;
    }

    // 1 organizador tem vários eventos : Na tabela de eventos terá vários organizadores do mesmo Id
    public virtual ICollection<Evento> Eventos { get; set; }

    public override bool EhValido()
    {
      return true;
    }
  }
}