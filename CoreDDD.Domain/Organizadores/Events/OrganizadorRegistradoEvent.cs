using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Organizadores.Events
{
  public class OrganizadorRegistradoEvent : BaseOrganizadorEvent
  {
    public OrganizadorRegistradoEvent(Guid id, string nome, string cpf, string email)
    {
      Id = id;
      Nome = nome;
      CPF = cpf;
      Email = email;

      AggregateId = id;
    }
  }
}
