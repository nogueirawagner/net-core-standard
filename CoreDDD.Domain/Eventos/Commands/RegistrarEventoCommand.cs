using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Eventos.Commands
{
  public class RegistrarEventoCommand : BaseEventoCommand
  {
    public IncluirEnderecoCommand Endereco { get; private set; }

    public RegistrarEventoCommand(string nome, string descricao, string descricaoCurta, DateTime dataInicio, DateTime dataFim,
      bool gratuito, decimal valor, bool online, string nomeEmpresa, Guid organizadorId, 
      Guid categoriaId, IncluirEnderecoCommand endereco)
    {
      Nome = nome;
      Descricao = descricao;
      DescricaoCurta = descricaoCurta;
      DataInicio = dataInicio;
      Valor = valor;
      Gratuito = gratuito;
      Online = online;
      NomeEmpresa = nomeEmpresa;
      OrganizadorId = organizadorId;
      CategoriaId = categoriaId;
      Endereco = endereco;
    }
  }
}
