using Core.Domain.Core.Models;
using Core.Domain.Models.Eventos;
using System;
using System.Collections.Generic;

namespace Core.Domain.Models.Organizadores
{
  public class Organizador : Entity<Organizador>
  {
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public string Email { get; private set; }

    protected Organizador()
    {
    }

    public Organizador(Guid id, string nome, string cpf, string email)
    {
      Id = id;
      Nome = nome;
      CPF = cpf;
      Email = email;
    }

    // 1 organizador tem vários eventos : Na tabela de eventos terá vários organizadores do mesmo Id
    public virtual ICollection<Evento> Eventos { get; set; }

    public override bool EhValido()
    {
      return true;
    }
  }
}