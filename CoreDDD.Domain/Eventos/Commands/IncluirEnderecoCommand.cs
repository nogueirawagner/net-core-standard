using Core.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Eventos.Commands
{
  public class IncluirEnderecoCommand : Command
  {
    public IncluirEnderecoCommand(Guid id, string logradouro, string numero, 
      string bairro, string cep, string complemento, string cidade, string estado, Guid? eventoId)
    {
      Id = id;
      Logradouro = logradouro;
      Numero = numero;
      Bairro = bairro;
      CEP = cep;
      Complemento = complemento;
      Cidade = cidade;
      Estado = estado;
      EventoId = EventoId;
    }

    public Guid Id { get; private set; }
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Bairro { get; private set; }
    public string CEP { get; private set; }
    public string Complemento { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public Guid? EventoId { get; private set; }
  }
}
