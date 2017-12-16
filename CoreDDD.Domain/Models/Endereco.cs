using Core.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Core.Domain.Models
{
  public class Endereco : Entity<Endereco>
  {
    public Endereco(Guid pId)
    {
      Id = pId;
    }

    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
    public string Complemento { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    public ICollection<Evento> Eventos { get; set; }
    public Guid EventoId { get; set; }

    public override bool EhValido()
    {
      throw new System.NotImplementedException();
    }
  }
}