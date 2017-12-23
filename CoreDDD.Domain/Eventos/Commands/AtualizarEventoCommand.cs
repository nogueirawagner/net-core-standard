using Core.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Eventos.Commands
{
  public class AtualizarEventoCommand : BaseEventoCommand
  {
    public AtualizarEventoCommand(Guid id, string nome, string descricao, string descricaoCurta, DateTime dataInicio, DateTime dataFim,
      bool gratuito, decimal valor, bool online, string nomeEmpresa, Guid organizadorId, Guid categoriaId)
    {
      Id = id;
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
    }
  }
}
